using StudentManager.CustomSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace StudentManager
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //This method is to decrypt the cookie(FormsAuthentication.FormsCookieName)
        //which was encrypted in the accounts controller and persist to httpcontext
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie httpCookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (httpCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);

                string[] UserDetail = ticket.UserData.Split('|');

                CustomPrincipal myUser = new CustomPrincipal(UserDetail[0]);
                myUser.Name = UserDetail[1];
                myUser.Email = UserDetail[2];
                myUser.RoleName = UserDetail[3];

                //Here we persist the user object to HttpContext
                //This makes the user details available in the application
                HttpContext.Current.User = myUser;
            }
        }
    }
}
