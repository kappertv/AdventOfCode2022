using System;
namespace AdventOfCode2022.Day7
{
    public class FolderSizeAnalyzer
    {
        Folder root = new Folder("/");
        public FolderSizeAnalyzer(string[] lines)
        {
            var currentFolder = root;
            foreach (var line in lines.Skip(1))
            {
                if (line.IsListCommand()) continue;
                if (line.IsFolder())
                {
                    currentFolder.folders.Add(new Folder(line.Substring(4), currentFolder));
                    continue;
                }
                if (line.IsFile())
                {
                    var parts = line.Split(" ");
                    currentFolder.files.Add(new File(parts[1], int.Parse(parts[0])));
                    continue;
                }
                if (line.IsChangeDirCommand())
                {
                    if (line.Substring(5).Equals(".."))
                    {
                        currentFolder = currentFolder.Parent!;
                    }
                    else
                    {
                        currentFolder = currentFolder.folders.Single(s => s.Name == line.Substring(5));
                    }
                    continue;
                }
                throw new InvalidProgramException();
            }
        }

        public long GetSmallestFolderToReachRequiredSpace()
        {
            const int totalspace = 70000000;
            const int requiredspace = 30000000;
            var minimumsize = requiredspace -(totalspace - root.FolderSize());
            var result = root.GetAllFolders().Select(f => f.FolderSize());
            var r = result.Where(s => s >= minimumsize).Min();
            return r;
        }

        public long GetSumOfFoldersWithAtMost(int maxsize)
        {
            var result = root.GetAllFolders().Where(f => f.FolderSize() <= maxsize);
            return result.Sum(f => f.FolderSize());
        }
    }

    public static class Extensions
    {

        public static List<Folder> GetAllFolders(this Folder folder)
        {
            var result = new List<Folder>();
            result.Add(folder);
            foreach(var f in folder.folders)
            {
                result.AddRange(f.GetAllFolders());
            }
            return result;
        }

        public static bool IsFolder(this string line)
        {
            return line.StartsWith("dir");
        }

        public static bool IsFile(this string line)
        {
            return Char.IsNumber(line.ElementAt(0));
        }

        public static bool IsListCommand(this string line)
        {
            return line.StartsWith("$ ls");
        }

        public static bool IsChangeDirCommand(this string line)
        {
            return line.StartsWith("$ cd");
        }
    }
}

