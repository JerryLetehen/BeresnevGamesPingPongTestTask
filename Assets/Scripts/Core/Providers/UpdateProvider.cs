using System;
using UnityEngine;

namespace PingPong.Core.Providers
{
    public class UpdateProvider : MonoBehaviour, IUpdateProvider
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}