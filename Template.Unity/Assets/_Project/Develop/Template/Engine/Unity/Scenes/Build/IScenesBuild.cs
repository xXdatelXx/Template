#if UNITY_EDITOR
using UnityEditor;

namespace Template.Engine.Unity
{
    public interface IScenesBuild
    {
        bool Exist(SceneAsset asset);
        void Add(SceneAsset asset);
        void Remove(SceneAsset asset);
    }
}
#endif