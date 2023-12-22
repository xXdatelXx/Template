using System.Linq;
using UnityEditor;
using System;
using System.Collections.Generic;

namespace Template.Tools.Unity
{
    public sealed class ScenesBuild : IScenesBuild
    {
        private readonly List<EditorBuildSettingsScene> _scenes;

        public ScenesBuild(List<EditorBuildSettingsScene> scenes) =>
            _scenes = scenes;

        public ScenesBuild() : this(EditorBuildSettings.scenes.ToList())
        { }

        public bool Exist(SceneAsset asset)
        {
            return EditorBuildSettings.scenes
                .Any(scene => scene.enabled && scene.path.Contains("/" + asset.name + ".unity"));
        }

        public void Add(SceneAsset asset)
        {
            if (asset is null)
                throw new ArgumentNullException("Scene asset is null");

            _scenes.Add(new EditorBuildSettingsScene(AssetDatabase.GetAssetPath(asset), true));
            EditorBuildSettings.scenes = _scenes.ToArray();
        }
    }
}