using System;

namespace PingPong.Game.Interfaces
{
    public interface IGate
    {
        event Action OnConcedeGoal;
    }
}