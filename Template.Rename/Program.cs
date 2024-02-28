using System;
using System.IO;
using Template.Rename;

// Template -> Template.Rename -> bin -> Release -> .exe
var root = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent;

new Project(
      directories:
      [
         root.FullName + "/Template.Documentation",
         root.FullName + "/Template.Unity/Assets/_Game",
      ],
      oldName: "Template",
      newName: root.Name)
   .Rename();

Console.Read();