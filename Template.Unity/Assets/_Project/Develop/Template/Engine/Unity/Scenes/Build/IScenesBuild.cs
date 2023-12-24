using UnityEditor;

namespace Template.Engine.Unity
{
#if UNITY_EDITOR
    public interface IScenesBuild
    {
        bool Exist(SceneAsset asset);
        void Add(SceneAsset asset);
        void Remove(SceneAsset asset);
    }
#endif
}