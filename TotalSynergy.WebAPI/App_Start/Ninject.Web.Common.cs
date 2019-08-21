using TotalSynergy.DAL;
using TotalSynergy.DAL.Repositories;
using TotalSynergy.Service;
using TotalSynergy.UI.BO;
using System.Data.Entity;
using AutoMapper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TotalSynergy.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TotalSynergy.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace TotalSynergy.WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
           
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<BODALMapperConfig>(); });
            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            
            kernel.Bind<DbContext, TotalSynergyEntities>().To<TotalSynergyEntities>().InRequestScope();
            kernel.Bind<IDbFactory>().To<DbFactory>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>)).InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<IContactRepository>().To<ContactRepository>().InRequestScope();
            kernel.Bind<IProjectRepository>().To<ProjectRepository>().InRequestScope();
            kernel.Bind<IProjectContactRepository>().To<ProjectContactRepository>().InRequestScope();
            kernel.Bind<IProjectService>().To<ProjectService>().InRequestScope();
            kernel.Bind<IContactService>().To<ContactService>().InRequestScope();
            kernel.Bind<IProjectContactService>().To<ProjectContactService>().InRequestScope();
            
        }
    }
}