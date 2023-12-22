using UnityEditor;

namespace Template.Tools.Unity
{
    public interface IScenesBuild
    {
        bool Exist(SceneAsset asset);
        void Add(SceneAsset asset);
    }
}