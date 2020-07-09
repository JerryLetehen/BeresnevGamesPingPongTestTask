using System;
using System.Collections.Generic;
using Redbus;
using Redbus.Interfaces;

namespace PingPong.Core.Providers
{
    public class ProvidersContainer : IProvidersContainer
    {
        private Dictionary<Type, object> providers = new Dictionary<Type, object>();

        public ProvidersContainer()
        {
            AddProvider(new EventBus() as IEventBus);
        }

        public T GetProvider<T>()
        {
            if (providers.TryGetValue(typeof(T), out var result))
            {
                return (T) result;
            }

            return default;
        }

        public bool AddProvider<T>(T provider)
        {
            if (providers.ContainsKey(typeof(T)))
            {
                return false;
            }

            providers.Add(typeof(T), provider);
            return true;
        }
    }
}