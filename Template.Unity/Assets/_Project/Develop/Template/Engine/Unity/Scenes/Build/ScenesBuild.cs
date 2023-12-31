#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Template.Engine.Unity
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
            if (asset == null)
                throw new ArgumentNullException(nameof(asset));

            return EditorBuildSettings.scenes.Any(s => s.path == AssetDatabase.GetAssetPath(asset));
        }

        public void Add(SceneAsset asset)
        {
            if (Exist(asset))
                throw new InvalidOperationException($"Scene {asset.name} already exists in build set");

            var scene = new EditorBuildSettingsScene(AssetDatabase.GetAssetPath(asset), true);
            _scenes.Add(scene);

            EditorBuildSettings.scenes = _scenes.ToArray();
        }

        public void Remove(SceneAsset asset)
        {
            if (!Exist(asset))
                throw new InvalidOperationException($"Scene {asset.name} dont exists in build set");

            var scene = _scenes.First(s => s.path == AssetDatabase.GetAssetPath(asset));
            _scenes.Remove(scene);

            EditorBuildSettings.scenes = _scenes.ToArray();
        }
    }
}
#endif