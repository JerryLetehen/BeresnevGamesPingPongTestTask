using System;
using PingPong.Game.Interfaces;

namespace PingPong.Datas
{
    public class PingPongGameData : IGameData
    {
        public Tuple<IGate, IGate> Gates { get; }
        public IBall Ball { get; }
        public IGameFieldInfo GameFieldInfo { get; }
        public IBallKicker<IBall> BallKicker { get; }

        public PingPongGameData(Tuple<IGate, IGate> gates, IBall ball, IGameFieldInfo gameFieldInfo, IBallKicker<IBall> ballKicker)
        {
            Gates = gates;
            Ball = ball;
            GameFieldInfo = gameFieldInfo;
            BallKicker = ballKicker;
        }
    }
}