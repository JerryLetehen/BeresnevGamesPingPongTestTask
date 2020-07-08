namespace PingPong.Core.Providers
{
    public interface IProvidersContainer
    {
        T GetProvider<T>();
        bool AddProvider<T>(T provider);
    }
}