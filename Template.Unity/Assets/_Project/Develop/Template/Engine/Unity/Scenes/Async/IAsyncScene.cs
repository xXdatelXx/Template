using Cysharp.Threading.Tasks;

namespace Template.Engine.Unity
{
   public interface IAsyncScene : IScene
   {
      UniTask OpenAsync();
   }
}