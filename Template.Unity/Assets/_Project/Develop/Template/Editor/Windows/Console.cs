using System;
using System.Reflection;

namespace Template.Editor
{
    internal sealed class Console
    {
        private readonly Type _logs;

        public Console(Type logs) =>
            _logs = logs;

        public Console() : this(Type.GetType("UnityEditor.LogEntries, UnityEditor.dll"))
        { }

        public void Clear()
        {
            MethodInfo method = _logs.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
            method.Invoke(null, null);
        }
    }
}