using System.Reflection;
using System.Web.Mvc;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WM.SisControleMvc.Infra.CrossCutting.IoC;

[assembly: WebActivator.PostApplicationStartMethod(typeof(WM.SisControleMvc.UI.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace WM.SisControleMvc.UI.Web.App_Start
{   

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectBootstraper.Register(container);
        }
    }
}