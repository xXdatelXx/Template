using Cysharp.Threading.Tasks;

namespace Template.Engine.Unity
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