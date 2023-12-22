using System;
using System.Reflection;
using UnityEditor;
using static Template.Editor.WindowsCommandSettings;

namespace Template.Editor
{
    internal static class Inspector
    {
        private static readonly Type Assembly =
            typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");

        private static readonly EditorWindow Window = EditorWindow.GetWindow(Assembly);

        [MenuItem(MenuParentItem + " Lock inspector " + InspectorLockKey)]
        private static void ToggleLockMode()
        {
            PropertyInfo property = Assembly.GetProperty("isLocked");
            property.SetValue(Window, !(bool)property.GetValue(Window));

            Window.Repaint();
        }

        [MenuItem(MenuParentItem + " Toggle Inspector Mode " + InspectorDebugKey)]
        private static void ToggleDebugMode()
        {
            FieldInfo field = Assembly.GetField("m_InspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);

            InspectorMode mode = (InspectorMode)field.GetValue(Window) == InspectorMode.Normal
                ? InspectorMode.Debug
                : InspectorMode.Normal;

            MethodInfo toggle = Assembly.GetMethod("SetMode", BindingFlags.NonPublic | BindingFlags.Instance);
            toggle.Invoke(Window, new object[] { mode });

            Window.Repaint();
        }
    }
}