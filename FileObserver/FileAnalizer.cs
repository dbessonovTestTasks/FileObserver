using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FileObserver.Operations;

namespace FileObserver.FileAnalyzers
{
    internal class FileAnalizer
    {
        private Regex _fileMather;
        private List<IOperation> _operationList;

        public FileAnalizer(string filePatter, params IOperation[] operations)
        {
            _fileMather = new Regex(filePatter);
            _operationList = new List<IOperation>();
            _operationList.AddRange(operations);
        }

        public bool IsMath(string fileName)
        {
            return _fileMather.IsMatch(fileName);
        }

        public void Process(string fileName, string text)
        {
            foreach (var operation in _operationList)
              Logger.Log(fileName, operation.OperationName, operation.Execute(text));
        }
    }
}
