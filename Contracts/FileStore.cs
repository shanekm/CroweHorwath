using System;
using System.IO;
using Contracts.Abstract;

namespace Contracts
{
    public class FileStore : IStoreReader, IStoreWriter
    {
        private readonly string _fileInput;
        private readonly string _fileOutput;
        private readonly DirectoryInfo _workingDirectory;
        private string _contents;

        public FileStore(IApplicationSettings appSettings)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            _fileInput = appSettings.GetValue("inputFileName");
            _fileOutput = appSettings.GetValue("outputFileName");
            _workingDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        }

        public string Read()
        {
            var file = GetFileInfo(_fileInput);
            if (!file.Exists)
                return string.Empty;
            var path = file.FullName;

            try {
                _contents = File.ReadAllText(path);
            }
            catch (Exception e) {
                throw new Exception($"Failed to load input file {file.Name}.", e);
            }

            return _contents;
        }

        public void Write(string value)
        {
            var path = GetFileInfo(_fileOutput).FullName;
            File.WriteAllText(path, value);
        }

        private FileInfo GetFileInfo(string fileName)
        {
            return new FileInfo(
                Path.Combine(_workingDirectory.FullName, fileName));
        }
    }
}