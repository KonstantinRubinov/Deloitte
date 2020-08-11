using SimpleInjector;
using System.Web.Http;
using System.Web.Mvc;

namespace DeloitteSystem
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		private void ConfigureApi()
		{
			var container = new Container();
			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.Register<IPersonsRepository, PersonsManager>();
			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			ConfigureApi();

			GlobalConfiguration.Configuration.MessageHandlers.Add(new MessageLoggingHandler());
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
