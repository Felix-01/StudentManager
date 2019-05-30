using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace StudentManager.CustomSecurity
{
    public class CustomPrincipal : IPrincipal
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        //Required for Authentication
        public IIdentity Identity { get; private set; }

        //Required for Authorisation
        public bool IsInRole(string role)
        {
            if (role == RoleName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}