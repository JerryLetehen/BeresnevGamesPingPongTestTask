using PingPong.Datas.PingPingBallKickDatas;
using PingPong.Game.Interfaces;
using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu(fileName = "PingPongBallKicker", menuName = "Settings/PingPongBallKicker", order = 1)]
    public class PingPongBallKicker : ScriptableObject, IBallKicker<IBall>
    {
        [SerializeField] private float defaultBallImpulse;
        
        private PingPongBallKickData BallKickData => ballKickData ?? (ballKickData = new PingPongBallKickData());

        private PingPongBallKickData ballKickData;

        public void KickBall(IBall ball)
        {
            BallKickData.SetDirection(GetRandomDirection());
            BallKickData.SetImpulse(defaultBallImpulse);
            ball.Kick(BallKickData);
        }
        
        private Vector3 GetRandomDirection()
        {
            var result = Vector3.zero;
            while (result.Equals(Vector3.zero) || result.Equals(Vector3.right) || result.Equals(Vector3.left) || result.Equals(Vector3.up) || result.Equals(Vector3.down))
            {
                result = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            }

            return result.normalized;
        }
    }
}