using EJ02;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;

namespace EJ02.UI
{
    /// <summary>
    /// Acceso al contenedor de IoC.
    /// </summary>
    public static class IoCContainerLocator
    {

        /// <summary>
        /// Instancia lazy del contenedor de IoC.
        /// </summary>
        private static readonly Lazy<IUnityContainer> cInstance = new Lazy<IUnityContainer>(() =>
        {
            // Se crea la instancia del contenedor, configurando el mismo a través del archivo de configuración de la aplicación.

            IUnityContainer mUnityContainer = new UnityContainer();

            mUnityContainer.RegisterType(
                typeof(UnitOfWork),
                typeof(UnitOfWork),
                new ContainerControlledLifetimeManager());

            return mUnityContainer;
        });

        public static IUnityContainer Container
        {
            get { return cInstance.Value; }
        }

    }
}
