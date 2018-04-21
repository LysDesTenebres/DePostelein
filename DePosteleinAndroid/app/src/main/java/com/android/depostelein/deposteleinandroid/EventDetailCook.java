package com.android.depostelein.deposteleinandroid;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.NavUtils;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.depostelein.deposteleinandroid.Models.Deliverer;
import com.android.depostelein.deposteleinandroid.Models.Dish;
import com.android.depostelein.deposteleinandroid.Models.Event;
import com.android.depostelein.deposteleinandroid.Models.Ingredients;
import com.android.depostelein.deposteleinandroid.Models.User;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import org.json.JSONObject;
import org.w3c.dom.Text;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.InputStreamReader;
import java.lang.reflect.Type;
import java.net.Authenticator;
import java.net.HttpURLConnection;
import java.net.PasswordAuthentication;
import java.net.URL;
import java.util.ArrayList;

public class EventDetailCook extends AppCompatActivity {

        User user;
        Event event;

        ArrayList<Dish> dishes;
        ArrayList<Dish> dishesForRole;
        ArrayList<Ingredients> ingredients;
        String mEmail;
        String mPassword;

        MyCustomAdapter dataAdapter;


        @Override
        protected void onCreate (Bundle savedInstanceState){
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_event_detail_cook);

            user = (User) getIntent().getExtras().getSerializable("User");
            event = (Event) getIntent().getExtras().getSerializable("Event");


            mEmail = user.getLogin();
            mPassword = user.getPassword();

            TextView err = (TextView)findViewById(R.id.textView);
            err.setText("Uw functie: " + user.getUserRole().toLowerCase());

            // Show the Up button in the action bar.
            ActionBar actionBar = getSupportActionBar();
            if (actionBar != null) {
                actionBar.setDisplayHomeAsUpEnabled(true);
            }


            new GrabURL().execute();

        }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            // Respond to the action bar's Up/Home button
            case android.R.id.home:
                NavUtils.navigateUpFromSameTask(this);
                return true;
        }
        return super.onOptionsItemSelected(item);
    }


        private class GrabURL extends AsyncTask<String, Void, String[]> {

            private boolean error = false;
            private ProgressDialog dialog =
                    new ProgressDialog(EventDetailCook.this);

            protected void onPreExecute() {
                dialog.setMessage("Getting your data... Please wait...");
                dialog.show();
            }

            protected String[] doInBackground(String... urls) {

                HttpURLConnection httpcon;
                String urlMenu = "http://10.0.2.2:8910/api/eventMenu/cook";
                String[] results = null;
                String result;
                try {
                    Authenticator.setDefault(new Authenticator() {
                        protected PasswordAuthentication getPasswordAuthentication() {
                            return new PasswordAuthentication(mEmail, mPassword.toCharArray());
                        }
                    });

                    //Connect
                    httpcon = (HttpURLConnection) ((new URL(urlMenu).openConnection()));
                    httpcon.setDoOutput(true);
                    httpcon.setRequestProperty("Content-Type", "application/json");
                    httpcon.setRequestProperty("Accept", "application/json");
                    httpcon.setRequestMethod("POST");

                    JSONObject jsonParam = new JSONObject();
                    jsonParam.put("menuName", event.getMenu());

                    DataOutputStream os = new DataOutputStream(httpcon.getOutputStream());
                    os.writeBytes(jsonParam.toString());

                    os.flush();
                    os.close();

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
                    results = result.split("\\+");


                } catch (Exception e) {
                    e.printStackTrace();
                    error = true;
                }
                return results;
            }

            protected void onCancelled() {
                dialog.dismiss();
                Toast toast = Toast.makeText(EventDetailCook.this,
                        "Error connecting to Server", Toast.LENGTH_LONG);
                toast.setGravity(Gravity.TOP, 25, 400);
                toast.show();

            }

            protected void onPostExecute(String[] content) {
                dialog.dismiss();
                Toast toast;
                if (error) {
                    toast = Toast.makeText(EventDetailCook.this,
                            "", Toast.LENGTH_LONG);
                    toast.setGravity(Gravity.TOP, 25, 400);
                    toast.show();
                } else {
                    displayEventList(content);
                }
            }

        }

        private void displayEventList (String[]response){

            JSONObject responseObj = null;

            Gson gson = new Gson();
            Type listTypeIngredients = new TypeToken<ArrayList<Ingredients>>() {
            }.getType();

            ingredients = gson.fromJson(response[1], listTypeIngredients);

            Type listTypeDish = new TypeToken<ArrayList<Dish>>() {
            }.getType();
            dishes = gson.fromJson(response[0], listTypeDish);

            dishesForRole = new ArrayList<>();
            for (Dish dish : dishes){
                if (dish.getRole().equals(user.getUserRole())){
                    dishesForRole.add(dish);
                }
            }


            ExpandableListView listView = findViewById(R.id.expandableListView);
            //create an ArrayAdaptar from the String Array
            dataAdapter = new MyCustomAdapter(this, dishesForRole, ingredients);


            //Making Adapter instance and passing 3 params in it(Context, List , HashMAp):-

            // Setting List Adapter to Expandable ListView:-
            listView.setAdapter(dataAdapter);


        }

        private class MyCustomAdapter extends BaseExpandableListAdapter {

            private ArrayList<Dish> dishesList;
            private ArrayList<Ingredients> ingredientsList;
            private Context context;

            public MyCustomAdapter(Context context, ArrayList<Dish> dishesList, ArrayList<Ingredients> ingredientsList) {
                this.dishesList = new ArrayList<>();
                this.dishesList.addAll(dishesList);
                this.ingredientsList = new ArrayList<>();
                this.ingredientsList.addAll(ingredientsList);
                this.context = context;
            }


            @Override
            public Object getChild(int groupPosition, int childPosition) {
                ArrayList<Ingredients> ingredientsArrayList = new ArrayList<>();

                for (Ingredients ingredient : ingredientsList) {
                    if (dishesList.get(groupPosition).getId() == ingredient.getDishId()) {
                        ingredientsArrayList.add(ingredient);
                    }
                }
                return ingredientsArrayList.get(childPosition);
            }

            @Override
            public long getChildId(int groupPosition, int childPosition) {
                return childPosition;
            }

            @Override
            public View getChildView(int groupPosition, int childPosition, boolean isLastChild,
                                     View view, ViewGroup parent) {

                Ingredients ingredient = (Ingredients) getChild(groupPosition, childPosition);
                if (view == null) {
                    LayoutInflater infalInflater = (LayoutInflater)
                            context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                    view = infalInflater.inflate(R.layout.event_detail_child, null);
                }

                TextView sequence = (TextView) view.findViewById(R.id.expandedListItem);
                int amount = ingredient.getAmount() * event.getGuests();
                sequence.setText(ingredient.getName() + ": " + amount + " " + ingredient.getUnit());

                return view;
            }

            @Override
            public int getChildrenCount(int groupPosition) {
                ArrayList<Ingredients> ingredientsArrayList = new ArrayList<>();

                for (Ingredients ingredient : ingredients) {
                    if (dishesList.get(groupPosition).getId() == ingredient.getDishId()) {
                        ingredientsArrayList.add(ingredient);
                    }
                }
                return ingredientsArrayList.size();
            }

            @Override
            public Object getGroup(int groupPosition) {
                return dishesList.get(groupPosition);
            }

            @Override
            public int getGroupCount() {
                return dishesList.size();
            }

            @Override
            public long getGroupId(int groupPosition) {
                return groupPosition;
            }

            @Override
            public View getGroupView(int groupPosition, boolean isLastChild, View view,
                                     ViewGroup parent) {

                Dish dish = (Dish) getGroup(groupPosition);
                if (view == null) {
                    LayoutInflater inf = (LayoutInflater)
                            context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                    view = inf.inflate(R.layout.event_detail, null);
                }

                TextView heading = (TextView) view.findViewById(R.id.listTitle);
                heading.setText(dish.getName());

                return view;
            }

            @Override
            public boolean hasStableIds() {
                return true;
            }

            @Override
            public boolean isChildSelectable(int groupPosition, int childPosition) {
                return false;
            }

        }
    }

