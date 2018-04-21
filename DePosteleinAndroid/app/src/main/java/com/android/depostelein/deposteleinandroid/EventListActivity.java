package com.android.depostelein.deposteleinandroid;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.depostelein.deposteleinandroid.Models.Event;
import com.android.depostelein.deposteleinandroid.Models.User;
import com.android.depostelein.deposteleinandroid.Models.UserRole;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonParseException;
import com.google.gson.reflect.TypeToken;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.lang.reflect.Type;
import java.net.Authenticator;
import java.net.HttpURLConnection;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

/**
 * An activity representing a list of Events. This activity
 * has different presentations for handset and tablet-size devices. On
 * handsets, the activity presents a list of items, which when touched,
 * lead to a {@link EventDetailActivity} representing
 * item details. On tablets, the activity presents the list of items and
 * item details side-by-side using two vertical panes.
 */
public class EventListActivity extends AppCompatActivity {


    ArrayList<Event> eventList;
    MyCustomAdapter dataAdapter = null;
    String mEmail;
    String mPassword;
    User user;

    private static final DateFormat PARSING_PATTERN =
            new SimpleDateFormat("EEE MMM HH:mm:ss z yyyy");
    private static final DateFormat FORMATTING_PATTERN =
            new SimpleDateFormat("EEEE, MMMM dd, yyyy");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        user = (User) getIntent().getSerializableExtra("User");
        setContentView(R.layout.activity_event_list);

        mEmail = user.getLogin();
        mPassword = user.getPassword();
        new GrabURL().execute();
    }


    private class GrabURL extends AsyncTask<String, Void, String> {

        private boolean error = false;
        private ProgressDialog dialog =
                new ProgressDialog(EventListActivity.this);

        protected void onPreExecute() {
            dialog.setMessage("Getting your data... Please wait...");
            dialog.show();
        }

        protected String doInBackground(String... urls) {

            HttpURLConnection httpcon;
            String url = "http://10.0.2.2:8910/api/event/events";
            String result = null;
            try {
                Authenticator.setDefault(new Authenticator() {
                    protected PasswordAuthentication getPasswordAuthentication() {
                        return new PasswordAuthentication(mEmail, mPassword.toCharArray());
                    }
                });

                //Connect
                httpcon = (HttpURLConnection) ((new URL(url).openConnection()));
                httpcon.setRequestProperty("Content-Type", "application/json");
                httpcon.setRequestProperty("Accept", "application/json");


                httpcon.connect();

                //Read
                BufferedReader br = new BufferedReader(new InputStreamReader(httpcon.getInputStream(), "UTF-8"));

                String line = null;
                StringBuilder sb = new StringBuilder();

                while ((line = br.readLine()) != null) {
                    sb.append(line);
                }

                br.close();
                result = sb.toString();
        } catch (Exception e) {
            e.printStackTrace();
                error = true;
        }
            return result;
        }

        protected void onCancelled() {
            dialog.dismiss();
            Toast toast = Toast.makeText(EventListActivity.this,
                    "Error connecting to Server", Toast.LENGTH_LONG);
            toast.setGravity(Gravity.TOP, 25, 400);
            toast.show();

        }

        protected void onPostExecute(String content) {
            dialog.dismiss();
            Toast toast;
            if (error) {
                toast = Toast.makeText(EventListActivity.this,
                        content, Toast.LENGTH_LONG);
                toast.setGravity(Gravity.TOP, 25, 400);
                toast.show();
            } else {
                displayEventList(content);
            }
        }

    }

    private void displayEventList(String response){

        JSONObject responseObj = null;


            // Creates the json object which will manage the information received
            GsonBuilder builder = new GsonBuilder();

            // Register an adapter to manage the date types as long values
            builder.registerTypeAdapter(Date.class, new JsonDeserializer<Date>() {
                public Date deserialize(JsonElement json, Type typeOfT, JsonDeserializationContext context) throws JsonParseException {
                    return new Date(json.getAsJsonPrimitive().getAsLong());
                }
            });

            Gson gson = builder.create();
            Type listType = new TypeToken< ArrayList<Event> >(){}.getType();
            eventList = gson.fromJson(response, listType);

            for (Event event :eventList) {
                Calendar cal = Calendar.getInstance();
                cal.setTime(event.getDate());
                cal.add(Calendar.HOUR_OF_DAY, 3);
                event.setDate(cal.getTime());

            }


            //create an ArrayAdaptar from the String Array
            dataAdapter = new MyCustomAdapter(this,
                    R.layout.event_list_content, eventList);
            ListView listView = findViewById(R.id.event_list);
            // Assign adapter to ListView
            listView.setAdapter(dataAdapter);

            //enables filtering for the contents of the given ListView
            listView.setTextFilterEnabled(true);

            listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                public void onItemClick(AdapterView<?> parent, View view,
                                        int position, long id) {
                        if(user.getRole().equals("ROLE_ADMIN")){

                            Intent intent = new Intent(getApplicationContext(), EventDetailActivity.class);
                            Bundle extras = new Bundle();
                            extras.putSerializable("User", user);
                            extras.putSerializable("Event", eventList.get(position));
                            intent.putExtras(extras);
                            startActivity(intent);
                                }
                                else{
                            Intent intent = new Intent(getApplicationContext(), EventDetailCook.class);
                            Bundle extras = new Bundle();
                            extras.putSerializable("User", user);
                            extras.putSerializable("Event", eventList.get(position));
                            intent.putExtras(extras);
                            startActivity(intent);
                        }

                }
            });

    }

    private class MyCustomAdapter extends ArrayAdapter<Event> {

        private ArrayList<Event> eventList;

        public MyCustomAdapter(Context context, int textViewResourceId,
                               ArrayList<Event> eventList) {
            super(context, textViewResourceId, eventList);
            this.eventList = new ArrayList<Event>();
            this.eventList.addAll(eventList);
        }

        private class ViewHolder {
            TextView code;
            TextView name;
            TextView continent;
            TextView region;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {

            ViewHolder holder = null;
            if (convertView == null) {

                LayoutInflater vi = (LayoutInflater)getSystemService(
                        Context.LAYOUT_INFLATER_SERVICE);
                convertView = vi.inflate(R.layout.event_list_content, null);

                holder = new ViewHolder();
                holder.code = convertView.findViewById(R.id.id_text);
                holder.name = convertView.findViewById(R.id.content);
                convertView.setTag(holder);

            } else {
                holder = (ViewHolder) convertView.getTag();
            }

            Event event = eventList.get(position);

            String outputDate;
                //Date date = PARSING_PATTERN.parse();
                outputDate = FORMATTING_PATTERN.format(event.getDate());

            holder.code.setText(outputDate);
            holder.name.setText(event.getLocation());


            return convertView;

        }

    }
}