using System;
using System.Collections.Generic;
using System.Linq;
using Models.DB;
using Models.DTO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using System.Web.Http;

namespace BookStoreSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			Mapper.Initialize(InitMapper);
			WebApiConfig.Register(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


		private void InitMapper(IMapperConfigurationExpression conf)
		{
			conf.CreateMap<purchases, PurchasesDTO>();
			conf.CreateMap<PurchasesDTO, purchases>();

			conf.CreateMap<books, BooksDTO>();
			conf.CreateMap<BooksDTO, books>();

			conf.CreateMap<discount, DiscountDTO>();
			conf.CreateMap<DiscountDTO, discount>();
		}

    }
}
