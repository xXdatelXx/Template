using System;
using System.IO;

namespace Template.Rename;

public sealed class Project(string[] directories, string oldName, string newName)
{
   public void Rename()
   {
      Console.WriteLine("Renaming started");

      foreach (var d in directories)
         Rename(Rename(new DirectoryInfo(d)).FullName);

      Console.WriteLine("Finish!");
   }

   // Rename root directories
   private DirectoryInfo Rename(DirectoryInfo di)
   {
      var parent = di.Parent;
      if (parent != null)
         di = new DirectoryInfo(Rename(parent).FullName + "\\" + di.Name);

      if (di.FullName.Contains(oldName))
      {
         if (di.Exists)
            di.MoveTo(di.FullName.Replace(oldName, newName));
         else
            di = new DirectoryInfo(di.FullName.Replace(oldName, newName));
      }

      return di;
   }

   private void Rename(string directory)
   {
      // Entry in all files of directory
      foreach (string entry in Directory.GetFileSystemEntries(directory, "*", SearchOption.TopDirectoryOnly))
      {
         // Rename directories
         if (File.GetAttributes(entry).HasFlag(FileAttributes.Directory))
         {
            string renamed = entry.Replace(oldName, newName);
            if (entry.Contains(oldName))
               Directory.Move(entry, renamed);

            Rename(renamed);

            continue;
         }

         // Rename in content
         string content = File.ReadAllText(entry);
         if (content.Contains(oldName))
         {
            content = content.Replace(oldName, newName);
            File.WriteAllText(entry, content);
         }

         // Rename files
         if (entry.Contains(oldName))
         {
            string renamed = entry.Replace(oldName, newName);
            File.Move(entry, renamed);
         }
      }
   }
}