using Cysharp.Threading.Tasks;

namespace Template.Tools.Unity
{
    public interface IAsyncScene : IScene
    {
        UniTask OpenAsync();
    }
}