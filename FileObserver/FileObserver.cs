using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using FileObserver.FileAnalyzers;

namespace FileObserver
{
    internal class FileObserver
    {
        private List<FileAnalizer> _fileAnalyzers = new List<FileAnalizer>();
        private string _folderPath;
        private FileSystemWatcher _watcher;

        public FileObserver(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void Register(FileAnalizer analizer)
        {
            _fileAnalyzers.Add(analizer);
        }

        public void StartWatch()
        {
            _watcher = new FileSystemWatcher(_folderPath)
            {
                NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName
            };


            _watcher.Created += (o, e) =>
                _fileAnalyzers.FirstOrDefault(a => a.IsMath(e.Name))?.Process(e.Name, Read(e.FullPath));

            _watcher.EnableRaisingEvents = true;
        }

        private string Read(string fullPath)
        {
            var fileText = string.Empty;

            bool success = false;
            var attemptCount = 0;

            while (!success && attemptCount < 120)
            {
                try
                {
                    fileText = File.ReadAllText(fullPath);
                    success = true;
                }
                catch (IOException ex)
                {
                    attemptCount++;
                    Thread.Sleep(500);
                }
            }

            return fileText;
        }

        public void StopWatch()
        {
            _watcher.Dispose();
        }
    }
}
