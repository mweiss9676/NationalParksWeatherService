﻿using Ninject;
using Ninject.Web.Common.WebHost;
using NPGeek.Web.Models.DALS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NPGeek.Web
{
    public class MvcApplication : NinjectHttpApplication
    {


        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Map Interfaces to Classes
            //kernel.Bind<interface>().To<class>();
            kernel.Bind<IParkDAL>().To<ParkDAL>();
            kernel.Bind<ISurveyDAL>().To<SurveyDAL>();

            return kernel;
        }
    }
}
