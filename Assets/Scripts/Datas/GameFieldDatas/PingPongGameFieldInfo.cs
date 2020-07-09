using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong.Datas
{
    public class PingPongGameFieldInfo : IGameFieldInfo
    {
        public Vector3 BallStartPosition { get; }

        public PingPongGameFieldInfo(Vector3 ballStartPosition)
        {
            BallStartPosition = ballStartPosition;
        }
    }
}