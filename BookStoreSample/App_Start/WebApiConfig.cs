using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;

namespace BookStoreSample
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration configuration)
		{
			//configuration.MapHttpAttributeRoutes();
			configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
				new { id = RouteParameter.Optional });
			//configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);
		}
	}
}