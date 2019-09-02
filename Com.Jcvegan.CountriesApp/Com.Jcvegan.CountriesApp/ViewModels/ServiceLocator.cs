using System;
using Unity;

namespace Com.Jcvegan.CountriesApp.ViewModels
{
    public class ServiceLocator
    {
        private static readonly UnityContainer _unityContainer = null;
        static ServiceLocator()
        {
            _unityContainer = new UnityContainer();
        }
        public static void Initialize(Action<UnityContainer> containerBuilder)
        {
            containerBuilder(_unityContainer);
        }

        public static T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }
    }
}