using Cysharp.Threading.Tasks;

namespace Template.Tools.Unity
{
    public sealed class UnitySceneWithMemoryAllocate : IScene
    {
        private readonly IScene _origin;
        private readonly IScene _empty;

        public UnitySceneWithMemoryAllocate(IScene origin, IScene empty)
        {
            _origin = origin;
            _empty = empty;
        }

        public string Name => _origin.Name;

        public void Open()
        {
            Async().Forget();
            return;

            async UniTaskVoid Async()
            {
                _empty.Open();
                await UniTask.NextFrame();
                _origin.Open();
            }
        }
    }
}