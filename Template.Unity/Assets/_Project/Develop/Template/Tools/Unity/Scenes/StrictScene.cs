using System;
using System.Linq;
using UnityEditor;

namespace Template.Tools.Unity
{
    public sealed class StrictScene : IScene
    {
        private readonly IScene _origin;

        public StrictScene(IScene origin) =>
            _origin = origin;

        public string Name => _origin.Name;

        public void Open()
        {
#if UNITY_EDITOR
            bool inBuild =
                EditorBuildSettings.scenes
                    .Any(scene => scene.enabled && scene.path.Contains("/" + Name + ".unity"));

            if (!inBuild)
                throw new NullReferenceException($"Scene {Name} not exists");
#endif
            _origin.Open();
        }
    }
}