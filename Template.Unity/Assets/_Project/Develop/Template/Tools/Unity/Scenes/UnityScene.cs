using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Tools.Unity
{
    [CreateAssetMenu(menuName = nameof(UnityScene), fileName = nameof(UnityScene))]
    public sealed class UnityScene : ScriptableObject, ISerializationCallbackReceiver, IScene
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _asset;
        [SerializeField] private bool _forBuild;
#endif

        public UnityScene(string name) =>
            Name = name;

        [field: SerializeField] public string Name { get; private set; }

        public void Open()
        {
            if (SceneManager.GetActiveScene().name == Name)
                throw new InvalidOperationException("Scene already opened");

            SceneManager.LoadScene(Name);
        }

        #region Serialize

        public void OnAfterDeserialize()
        { }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            if (_asset != null)
                Name = _asset.name;
#endif
        }

        private void OnValidate()
        {
#if UNITY_EDITOR
            if (!_forBuild)
                return;

            var build = new ScenesBuild();
            if (!build.Exist(_asset))
                build.Add(_asset);
#endif
        }

        #endregion
    }
}