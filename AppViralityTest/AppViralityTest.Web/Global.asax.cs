using AppViralityTest.BLL;
using AppViralityTest.BLL.Configurations;
using AppViralityTest.DataModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace AppViralityTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.RegisterMappings();
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        var userid = Convert.ToInt32(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
                        string roles = string.Empty;

                        var userMan = new UserManager();
                        if (userMan.IsUserValid(new UserDTO { Id = userid }))
                        {
                            var user = userMan.GetUserDetails(userid);
                            user.Roles = "Admin";

                            //Let us set the Pricipal with our user specific details
                            e.User = new System.Security.Principal.GenericPrincipal(
                              new System.Security.Principal.GenericIdentity(userid.ToString(), "Forms"), user.Roles.Split(';'));
                        }
                        else { throw new HttpException(401, "Unauthorized access"); }

                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
