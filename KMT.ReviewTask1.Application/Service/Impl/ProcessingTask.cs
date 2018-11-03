using System;
using System.IO;

namespace KMT.ReviewTask1.Application.Service.Impl
{
    public class ProcessingTask : IProcessingTask
    {
        private readonly IFolderProvider _folderProvider;
        private readonly IFileReader _fileReader;
        private readonly IMatrixProcessor _matrixProcessor;
        private readonly ILogger _logger;

        public ProcessingTask(
            IFolderProvider folderProvider,
            IFileReader fileReader,
            IMatrixProcessor matrixProcessor, 
            ILogger logger)
        {
            _folderProvider = folderProvider;
            _fileReader = fileReader;
            _matrixProcessor = matrixProcessor;
            _logger = logger;
        }

        public void Do()
        {
            var workFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Files");

            var files = _folderProvider.GetUnprocessed(workFolder);
            foreach (var f in files)
            {
                _logger.Add($"Processing file '{f}'");
                var fileContent = _fileReader.Read(f);
                var results = _matrixProcessor.Process(fileContent);

                var r = _folderProvider.GetResultFileName(f);
                _fileReader.Write(r, results);
                _logger.Add($"File '{f}' processed, results at: '{r}");
            }
        }
    }
}