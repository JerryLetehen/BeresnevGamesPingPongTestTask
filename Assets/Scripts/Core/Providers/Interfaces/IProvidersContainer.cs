namespace PingPong.Core.Providers
{
    public interface IProvidersContainer
    {
        T GetProvider<T>();
        void AddProvider<T>(T provider);
    }
}