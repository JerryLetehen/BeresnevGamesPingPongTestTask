using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong
{
    public class PingPongBallBehavior : MonoBehaviour, IBall
    {
        [SerializeField] private Rigidbody2D rb;

        public IBall Place(IBallSettings settings)
        {
            transform.position = settings.StartPosition;
            return this;
        }

        public IBall Kick(IBallKickData kickData)
        {
            rb.velocity = kickData.Direction * kickData.Impulse;
            return this;
        }
    }
}