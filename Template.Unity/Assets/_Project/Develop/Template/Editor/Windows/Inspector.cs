using System;
using System.Reflection;
using UnityEditor;

namespace Template.Editor
{
   internal sealed class Inspector
   {
      private readonly Type _assembly;
      private readonly EditorWindow _window;

      public Inspector(Type assembly, EditorWindow window)
      {
         _assembly = assembly;
         _window = window;
      }

      public Inspector()
      {
         _assembly = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");
         _window = EditorWindow.GetWindow(_assembly);
      }

      public void ToggleLockMode()
      {
         PropertyInfo property = _assembly.GetProperty("isLocked");
         property.SetValue(_window, !(bool)property.GetValue(_window));

         _window.Repaint();
      }

      public void ToggleDebugMode()
      {
         FieldInfo field = _assembly.GetField("m_InspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

         InspectorMode mode = (InspectorMode)field.GetValue(_window) == InspectorMode.Normal
            ? InspectorMode.Debug
            : InspectorMode.Normal;

         MethodInfo toggle = _assembly.GetMethod("SetMode", BindingFlags.NonPublic | BindingFlags.Instance);
         toggle.Invoke(_window, new object[] { mode });

         _window.Repaint();
      }
   }
}