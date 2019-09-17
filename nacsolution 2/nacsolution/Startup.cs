using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(nacsolution.Startup))]

namespace nacsolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }

        // In this method we will create default User roles and Admin user for login

      

    }
}
