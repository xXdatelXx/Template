using UnityEditor;

namespace Template.Editor
{
   internal static class WindowsCommands
   {
      private static readonly Console Console = new();
      private static readonly Inspector Inspector = new();
      private static readonly Project Project = new();

      [MenuItem("Template/Console/Clear &q")]
      private static void ClearConsole() =>
         Console.Clear();

      [MenuItem("Template/Inspector/ToggleLockMode &w")]
      private static void LockInspector() =>
         Inspector.ToggleLockMode();

      [MenuItem("Template/Inspector/ToggleDebugMode &e")]
      private static void ToggleDebugMode() =>
         Inspector.ToggleDebugMode();

      [MenuItem("Template/Project/SearchAllScenes &r")]
      private static void SearchAllScenes() =>
         Project.Filtrate("t:Scene");
   }
}