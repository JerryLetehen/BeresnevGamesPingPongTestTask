using System;

namespace PingPong.Core.Providers
{
    public interface IUpdateProvider
    {
        event Action OnUpdate;
    }
}