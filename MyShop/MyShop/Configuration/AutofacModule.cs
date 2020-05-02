using Autofac;
using MyShop.API.Controllers;
using MyShop.DB.Storages;
using MyShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.API
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderStorage>().As<IOrderStorage>();
            builder.RegisterType<ReportStorage>().As<IReportStorage>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<ReportRepository>().As<IReportRepository>();
            builder.RegisterType<OrderController>().As<IOrderController>();
            builder.RegisterType<ReportController>().As<IReportController>();
        }
    }
}
