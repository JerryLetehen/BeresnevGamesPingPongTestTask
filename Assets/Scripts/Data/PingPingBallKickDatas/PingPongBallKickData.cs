using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong.Datas.PingPingBallKickDatas
{
    public class PingPongBallKickData : IBallKickData
    {
        public Vector3 Direction => direction;
        public float Impulse => impulse;

        private Vector3 direction;
        private float impulse;

        public void SetImpulse(float value)
        {
            impulse = value;
        }

        public void SetDirection(Vector3 value)
        {
            direction = value;
        }
    }
}