using System;
using System.Reflection;
using UnityEditor;

namespace Template.Editor
{
   public sealed class Project
   {
      private readonly EditorWindow _window;

      public Project(EditorWindow window) =>
         _window = window;

      public Project()
      {
         var assembly = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
         _window = EditorWindow.GetWindow(assembly);
      }

      public void Filtrate(string filter)
      {
         if (string.IsNullOrEmpty(filter))
            throw new ArgumentNullException(nameof(filter));

         MethodInfo result = _window.GetType().GetMethod("SetSearch", new[] { typeof(string) });
         result.Invoke(_window, new object[] { filter });
      }
   }
}