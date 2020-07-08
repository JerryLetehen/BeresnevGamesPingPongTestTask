using UnityEngine;

namespace PingPong.Game.Interfaces
{
    public interface IBallKickData
    {
        Vector3 Direction { get; }
        float Impulse { get; }
    }
}