namespace PingPong.Game.Interfaces
{
    public interface IBallKicker<in T> where T: IBall
    {
        void KickBall(T ball);
    }
}