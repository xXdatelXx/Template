using UnityEditor;
using UnityEngine;

namespace Template.Editor
{
   internal static class DebugCommands
   {
      [MenuItem("Template/Debug/DebugTimeScale &t")]
      private static void ToggleDebugTimeScale() =>
         Time.timeScale = Time.timeScale != 1 ? 1 : 0.1f;
   }
}