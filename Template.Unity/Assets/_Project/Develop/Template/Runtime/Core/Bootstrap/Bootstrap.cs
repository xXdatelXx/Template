using System.Threading;
using Cysharp.Threading.Tasks;
using Template.Engine.Unity;
using VContainer.Unity;

namespace Template.Runtime.Core
{
    public sealed class Bootstrap : IAsyncStartable
    {
        private readonly IScene _entry;
        private readonly Balancy.AppConfig _app;

        public Bootstrap(IScene entry, Balancy.AppConfig app)
        {
            _entry = entry;
            _app = app;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await LoadConfigs(cancellation);
            _entry.Open();
        }

        private async UniTask LoadConfigs(CancellationToken cancellation)
        {
            Balancy.Main.Init(_app);
            await UniTask.WaitUntil(() => Balancy.Storage.Initialized, cancellationToken: cancellation);
        }
    }
}