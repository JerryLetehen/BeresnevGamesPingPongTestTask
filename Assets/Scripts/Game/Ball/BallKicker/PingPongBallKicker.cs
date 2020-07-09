using PingPong.Datas.PingPingBallKickDatas;
using PingPong.Game.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PingPong
{
    [CreateAssetMenu(fileName = "PingPongBallKicker", menuName = "Settings/PingPongBallKicker", order = 1)]
    public class PingPongBallKicker : ScriptableObject, IBallKicker<IBall>
    {
        [SerializeField] private float defaultBallImpulse;
        [SerializeField, Range(30f, 89f)] private float deniedKickAngle = 45f;

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
            while (Vector3.Angle(Vector3.right, new Vector3(Mathf.Abs(result.x), Mathf.Abs(result.y))) < deniedKickAngle)
            {
                result = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            }

            return result.normalized;
        }
    }
}