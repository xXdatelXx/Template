using System.Threading;
using Cysharp.Threading.Tasks;
using Template.Engine.Configs;
using Template.Engine.Unity;
using VContainer.Unity;
using Configs = Balancy.Main;

namespace Template.Runtime.Core
{
    public sealed class Bootstrap : IAsyncStartable
    {
        private readonly IScene _entry;
        private readonly IGameConfig _config;

        public Bootstrap(IScene entry, IGameConfig config)
        {
            _entry = entry;
            _config = config;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await UniTask.RunOnThreadPool(() => Configs.Init(_config), cancellationToken: cancellation);
            _entry.Open();
        }
    }
}