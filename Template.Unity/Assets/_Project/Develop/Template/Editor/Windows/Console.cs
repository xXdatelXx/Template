using UnityEditor;
using System;
using System.Reflection;
using static Template.Editor.WindowsCommandSettings;

namespace Template.Editor
{
    internal static class Console
    {
        [MenuItem(MenuParentItem + " Clear Console " + ClearConsoleKey)]
        static void Clear()
        {
            var logs = Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
            MethodInfo method = logs.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);

            method.Invoke(null, null);
        }
    }
}