namespace PingPong.Game.Interfaces
{
    public interface IGame
    {
        IGame Init(IGameData data);
        IGame Start();
    }
}