using System;
using PingPong.Core.Providers;
using PingPong.Datas;
using PingPong.Events;
using PingPong.Game.Interfaces;
using Redbus.Interfaces;
using UnityEngine;

namespace PingPong
{
    public class PingPongGameField : MonoBehaviour
    {
        [SerializeField] private Transform centerTr;
        [SerializeField] private RectTransform area;
        [SerializeField] private PingPongGate firstGate;
        [SerializeField] private PingPongGate secondGate;
        [SerializeField] private WallBase[] walls;

        public Tuple<IGate, IGate> Gates { get; private set; }
        public IGameFieldInfo FieldInfo { get; private set; }

        private IEventBus eventBus;
        private AreaSizeChangedEvent areaSizeChangedEvent = new AreaSizeChangedEvent();
        private IUpdateProvider updateProvider;
        private Vector2 areaSize;

        public void Init(IProvidersContainer providersContainer)
        {
            Gates = new Tuple<IGate, IGate>(firstGate, secondGate);

            FieldInfo = new PingPongGameFieldInfo(centerTr.position);

            eventBus = providersContainer.GetProvider<IEventBus>();

            updateProvider = providersContainer.GetProvider<IUpdateProvider>();
            updateProvider.OnUpdate += OnUpdate;

            InitWalls(providersContainer);
        }

        private void InitWalls(IProvidersContainer providersContainer)
        {
            foreach (var wall in walls)
            {
                wall.Init(providersContainer);
            }
        }

        private void OnUpdate()
        {
            CheckAreaSizeChanged();
        }

        private void CheckAreaSizeChanged()
        {
            var size = area.rect.size;
            if (areaSize != size)
            {
                area.GetWorldCorners(areaSizeChangedEvent.AreaCorners);
                areaSizeChangedEvent.SetSize(size);
                eventBus.Publish(areaSizeChangedEvent);
            }

            areaSize = size;
        }
    }
}