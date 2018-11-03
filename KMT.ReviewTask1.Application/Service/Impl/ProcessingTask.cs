using System;
using System.IO;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class ProcessingTask
    {
        private readonly IFolderProvider _folderProvider;
        private readonly IFileReader _fileReader;
        private readonly IMatrixProcessor _matrixProcessor;

        public ProcessingTask(IFolderProvider folderProvider, IFileReader fileReader, IMatrixProcessor matrixProcessor)
        {
            _folderProvider = folderProvider;
            _fileReader = fileReader;
            _matrixProcessor = matrixProcessor;
        }

        public void Do()
        {
            var workFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Files");

            var files = _folderProvider.GetUnprocessed(workFolder);
            foreach (var f in files)
            {
                Console.WriteLine($"Processing file '{f}'");
                var fileContent = _fileReader.Read(f);
                var results = _matrixProcessor.Process(fileContent);

                var r = _folderProvider.GetResultFileName(f);
                _fileReader.Write(r, results);
                Console.WriteLine($"File '{f}' processed, results at: '{r}");
            }
        }
    }
}