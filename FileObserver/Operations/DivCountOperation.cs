using System.Text.RegularExpressions;

namespace FileObserver.Operations
{
    internal class DivCountOperation : IOperation
    {
        public string OperationName => "Подсчет количества тегов <div>";

        public string Execute(string data)
        {
            var regular = new Regex(@"<div.*?>");
            return regular.Matches(data).Count.ToString();
        }
    }
}
