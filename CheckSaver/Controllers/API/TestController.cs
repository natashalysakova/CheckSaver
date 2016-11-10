using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CheckSaver.Controllers.API
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public Folder Get()
        {
            var drives = System.IO.DriveInfo.GetDrives();
            Folder folders = new Folder();
            foreach (var drive in drives)
            {
                folders.Folders.Add(drive.RootDirectory.Name);
            }

            return folders;
        }

        // GET: api/Test/5
        public Folder Get(string path)
        {
            var folder = new Folder();
            var pathFolders = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            if (pathFolders.Length > 1)
            {
                var parent = pathFolders.Take(pathFolders.Length - 1).ToArray();
                if (parent.Length == 1)
                {
                    folder.Parent = parent[0] + "\\";
                }
                else
                {
                    folder.Parent = string.Join("\\", parent);
                }
            }
            else if (pathFolders.Length == 1)
            {
                folder.Parent = string.Empty;
            }

            try
            {
                folder.Folders = Directory.GetDirectories(path).ToList();
                folder.Files = Directory.GetFiles(path).ToList();
            }
            catch (UnauthorizedAccessException)
            {
                folder.AccessError = true;
            }

           folder.FilesCount = GetFilesCount(path);
            return folder;
        }


        const int TenMB = 1048576;
        const int FiftyMB = 52428800;
        const int HundredB = 104857600;

        private Files GetFilesCount(string path)
        {
            var filesCount = new Files();
            try
            {
                var files = Directory.GetFiles(path);

                foreach (var file in files)
                {
                    FileInfo f = new FileInfo(file);
                    if (f.Length <= TenMB)
                    {
                        filesCount.Small++;
                    }
                    else if (f.Length > TenMB && f.Length <= FiftyMB)
                    {
                        filesCount.Medium++;
                    }
                    else if (f.Length >= HundredB)
                    {
                        filesCount.Large++;
                    }
                }

                foreach (string directory in Directory.GetDirectories(path))
                {
                    var fileInfo = GetFilesCount(directory);
                    filesCount += fileInfo;
                }

            }
            catch (UnauthorizedAccessException)
            {
            }

            return filesCount;
        }

    }

    public class Folder
    {
        public Folder()
        {
            Folders = new List<string>();
            Files = new List<string>();
        }
        public string Parent { get; set; }
        public List<string> Folders { get; set; }
        public List<string> Files { get; set; }

        public Files FilesCount { get; set; }
        public bool AccessError { get; set; }
    }

    public class Files
    {
        public int Small { get; set; }
        public int Medium { get; set; }
        public int Large { get; set; }

        public static Files operator +(Files one, Files other)
        {
            return new Files()
            {
                Small = one.Small + other.Small,
                Large = one.Large + other.Large,
                Medium = one.Medium + other.Medium
            };
        }
    }
}