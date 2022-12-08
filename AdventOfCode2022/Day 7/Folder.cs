using System;
namespace AdventOfCode2022.Day7
{
    public class Folder
    {
        public Folder(string name, Folder parent)
        {
            Name = name;
            Parent = parent;
        }

        public Folder(string name)
        {
            Name = name; // isroot;
        }

        public List<Folder> folders = new List<Folder>();
        public List<File> files = new List<File>();
        public Folder? Parent;

        public string Name { get; }

        public long FolderSize()
        {
            var files = this.GetAllFiles();
            return files.Sum(f => f.size);
        }
    }

    public static class Extensions2
    {
        public static List<File> GetAllFiles(this Folder f)
        {
            var result = new List<File>();
            result.AddRange(f.files);

            foreach (var fol in f.folders)
            {
                result.AddRange(fol.GetAllFiles());
            }

            return result;
        }
    }
}

