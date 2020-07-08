using System;
using UnityEngine;

namespace PingPong.Core.Providers
{
    public class UpdateProvider : MonoBehaviour, IUpdateProvider
    {
        public event Action OnUpdate;
        public event Action OnLateUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }
}