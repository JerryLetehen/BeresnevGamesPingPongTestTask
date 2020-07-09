namespace PingPong.Game.Interfaces
{
    public interface IBall
    {
        IBall Place(IBallSettings settings);
        IBall Kick(IBallKickData kickData);
    }
}