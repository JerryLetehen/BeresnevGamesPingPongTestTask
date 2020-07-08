using PingPong.Core;
using PingPong.Core.Providers;
using PingPong.Events;
using Redbus;
using Redbus.Interfaces;
using UnityEngine;

namespace PingPong
{
    public class PadBehavior : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;

        private IUpdateProvider updateProvider;
        private Limits<float> xPosLimits = new Limits<float>(0, 0);
        private Vector3[] padCorners = new Vector3[4];
        private float halfWidth;
        private IEventBus eventBus;
        private SubscriptionToken areaSizeChangedEventSubscritpion;

        public void Init(IProvidersContainer providersContainer)
        {
            eventBus = providersContainer.GetProvider<IEventBus>();
            areaSizeChangedEventSubscritpion = eventBus.Subscribe<AreaSizeChangedEvent>(OnAreaSizeChanged);
            updateProvider = providersContainer.GetProvider<IUpdateProvider>();
            if (updateProvider != null)
            {
                updateProvider.OnLateUpdate += OnLateUpdate;
            }
        }

        private void Start()
        {
            AssignPadCorners();
            AssignHalfWidth();
        }

        public void Move(float xDelta)
        {
            var newPos = rectTransform.anchoredPosition;
            newPos.x += xDelta;
            rectTransform.anchoredPosition = newPos;
        }

        private void OnLateUpdate()
        {
            ClampPosition();
        }

        private void AssignHalfWidth()
        {
            halfWidth = (padCorners[3].x - padCorners[0].x) / 2f;
        }

        private void AssignPadCorners()
        {
            rectTransform.GetWorldCorners(padCorners);
        }

        private void ClampPosition()
        {
            AssignPadCorners();
            var currentPos = rectTransform.position;
            if (padCorners[0].x < xPosLimits.Min)
            {
                currentPos.x = xPosLimits.Min + halfWidth;
            }
            else if (padCorners[3].x > xPosLimits.Max)
            {
                currentPos.x = xPosLimits.Max - halfWidth;
            }

            rectTransform.position = currentPos;
        }

        private void OnAreaSizeChanged(AreaSizeChangedEvent areaSizeChangedEvent)
        {
            SetArea(areaSizeChangedEvent.AreaCorners);
        }

        private void SetArea(Vector3[] corners)
        {
            xPosLimits.SetLimits(corners[0].x, corners[3].x);
        }

        private void OnDestroy()
        {
            if (areaSizeChangedEventSubscritpion != null)
            {
                eventBus.Unsubscribe(areaSizeChangedEventSubscritpion);
            }
        }
    }
}