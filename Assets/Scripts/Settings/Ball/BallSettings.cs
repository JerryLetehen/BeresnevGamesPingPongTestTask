using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong.Game
{
    public class BallSettings : IBallSettings
    {
        public Vector3 StartPosition { get; }

        public BallSettings(Vector3 startPosition)
        {
            StartPosition = startPosition;
        }
    }
}