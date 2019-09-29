using System.Text.RegularExpressions;

namespace FileObserver.Operations
{
    class PunctuationCountOperation:IOperation
    {
        public string OperationName => "Подсчет количества знаков препинания";
        public string Execute(string data)
        {
            var regular = new Regex(@"[-.?!)(,:]");
            return regular.Matches(data).Count.ToString();
        }
    }
}
