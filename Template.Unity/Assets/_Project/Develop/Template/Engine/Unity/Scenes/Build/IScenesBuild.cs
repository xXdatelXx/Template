#if UNITY_EDITOR
using UnityEditor;

namespace Template.Engine.Unity
{
   /// <summary>
   /// Add, Remove scenes in Build menu
   /// </summary>
   public interface IScenesBuild
   {
      bool Exist(SceneAsset asset);
      void Add(SceneAsset asset);
      void Remove(SceneAsset asset);
   }
}
#endif