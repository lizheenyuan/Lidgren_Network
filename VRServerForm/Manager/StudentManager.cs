using System;
using System.Collections.Generic;
using System.Text;
using DB.Model;

namespace VRServerForm.Manager
{
    public class StudentManager
    {
        public User LoginUsr { get; protected set; }

        public void UsrLogin(User u)
        {
            LoginUsr = u;
        }

        public void LogOutUsr()
        {
            LoginUsr = null;
        }
    }
}
