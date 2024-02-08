using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Engine.Unity
{
   [CreateAssetMenu(menuName = "Template/Scenes/Scene", fileName = nameof(UnityScene))]
   public sealed class UnityScene : ScriptableObject, IScene
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
         if (name == null)
            throw new NullReferenceException(nameof(name));
         if (SceneManager.GetActiveScene().name == Name)
            throw new InvalidOperationException($"Scene {Name} already opened");

         SceneManager.LoadScene(Name);
      }

#if UNITY_EDITOR
      private void OnValidate()
      {
         if (_asset == null)
            return;

         Name = _asset.name;

         var build = new ScenesBuild();

         if (_forBuild)
         {
            if (!build.Exist(_asset))
               build.Add(_asset);
         }
         else if (build.Exist(_asset))
            build.Remove(_asset);
      }
#endif

      public override bool Equals(object other)
      {
         if (other is UnityScene scene)
            return Name == scene.name;

         return base.Equals(other);
      }
   }
}