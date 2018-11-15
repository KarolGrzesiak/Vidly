using IdentityManager;
using IdentityManager.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Vidly.Models;

[assembly: OwinStartupAttribute(typeof(Vidly.Startup))]
namespace Vidly
{

    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);


            app.Map("/idm", idm =>
             {
                 var factory = new IdentityManagerServiceFactory();
                 factory.IdentityManagerService = new Registration<IIdentityManagerService>(Create());
                 idm.UseIdentityManager(new IdentityManagerOptions
                 {
                     Factory = factory,
                     SecurityConfiguration = new HostSecurityConfiguration()
                     {
                         HostAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                         AdminRoleName = RoleName.Admin

                     }
                 });
             });


        }




        private IIdentityManagerService Create()
        {
            var context = new ApplicationDbContext();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var managerService =
                new ApplicationIdentityManagerService(userManager, roleManager);

            return managerService;
        }


    }






}
