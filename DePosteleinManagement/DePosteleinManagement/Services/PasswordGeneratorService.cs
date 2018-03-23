using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DePosteleinManagement.Services
{
    public class PasswordGeneratorService
    {
        public string GeneratePassword()
        {
            int lengthOfPassword = 8;
            string guid = Guid.NewGuid().ToString().Replace("-", "");

            return guid.Substring(0, lengthOfPassword);
        }
    }
}
