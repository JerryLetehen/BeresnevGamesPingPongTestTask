using Redbus.Events;
using UnityEngine;

namespace PingPong.Events
{
    public class AreaSizeChangedEvent : EventBase
    {
        public Vector2 Size { get; private set; }
        public Vector3[] AreaCorners { get; private set; } = new Vector3[4];

        public void SetSize(Vector2 value)
        {
            Size = value;
        }
    }
}