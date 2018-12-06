using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualLibrarity.Models;
using VirtualLibrarity.Models.Entities;

namespace VirtualLibrarity.DataWorkers
{
    public class UserToLoginResponseBuilder
    {
        public UserToLoginResponse BuildUserToSend(int id)
        {
            UserToLoginResponse user = new UserToLoginResponse();
            if (id < 0)
            {
                user.Exception = "Internal server exception has happened";
            }
            else if (id == 0)
            {
                user.Exception = "User not found";
            }
            else
            {
                //construct user there;
            }
            return user;
        }
        public UserToLoginResponse BuildUserToSend(LoginManualArgs loginManualArgs)
        {
            //implementation????
            return new UserToLoginResponse(); 
        }
    }
}