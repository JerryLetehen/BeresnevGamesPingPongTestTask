using PingPong.Core.Providers;
using PingPong.Events;
using Redbus;
using Redbus.Interfaces;
using UnityEngine;

namespace PingPong
{
    public abstract class WallBase : MonoBehaviour
    {
        [SerializeField] protected BoxCollider2D boxCollider;

        private IEventBus eventBus;
        private SubscriptionToken areaSizeChangedEventSubscription;

        public void Init(IProvidersContainer providersContainer)
        {
            eventBus = providersContainer.GetProvider<IEventBus>();
            areaSizeChangedEventSubscription = eventBus.Subscribe<AreaSizeChangedEvent>(OnAreaSizeChanged);
        }

        private void OnAreaSizeChanged(AreaSizeChangedEvent areaSizeChangedEvent)
        {
            SetSize(areaSizeChangedEvent.Size);
        }

        private void OnDestroy()
        {
            if (areaSizeChangedEventSubscription != null)
            {
                eventBus.Unsubscribe(areaSizeChangedEventSubscription);
                areaSizeChangedEventSubscription = null;
            }
        }

        protected abstract void SetSize(Vector2 areaSize);
    }
}