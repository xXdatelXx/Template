using System;
using Cysharp.Threading.Tasks;

namespace Template.Engine.Time
{
    public sealed class AsyncTimer : ITimer
    {
        private readonly float _time;

        public AsyncTimer(float time) =>
            _time = time;

        public bool Playing { get; private set; }

        public void Play() =>
            PlayAsync().Forget();

        private async UniTaskVoid PlayAsync()
        {
            if (Playing)
                throw new InvalidOperationException("Timer already playing");

            Playing = true;
            await UniTask.Delay(TimeSpan.FromSeconds(_time));
            Playing = false;
        }
    }
}