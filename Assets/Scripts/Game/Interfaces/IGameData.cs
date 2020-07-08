using System;

namespace PingPong.Game.Interfaces
{
    public interface IGameData
    {
        Tuple<IGate, IGate> Gates { get; }
        IBall Ball { get; }
        IGameFieldInfo GameFieldInfo { get; }
        IBallKicker<IBall> BallKicker { get; }
    }
}