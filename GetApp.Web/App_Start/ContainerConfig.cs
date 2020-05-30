using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using GetApp.Data.Services;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace GetApp.Web
{
    public class ContainerConfig
    {
        public ContainerConfig()
        {
        }

        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(Global).Assembly);
            builder.RegisterApiControllers(typeof(Global).Assembly);

            builder.RegisterType<SqlStudentData>()
                   .As<IStudentData>()
                   .InstancePerRequest();

            builder.RegisterType<SqlExamData>()
                   .As<IExamData>()
                   .InstancePerRequest();

            builder.RegisterType<SqlSubjectData>()
                   .As<ISubjectData>()
                   .InstancePerRequest();

            builder.RegisterType<GetAppDbContext>().InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
