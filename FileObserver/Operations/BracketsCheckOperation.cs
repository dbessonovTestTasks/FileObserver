using System.Text.RegularExpressions;

namespace FileObserver.Operations
{
    internal class BracketsCheckOperation:IOperation
    {
        public string OperationName =>
            "Проверка совпадения количества открывающих скобок \"{\" с количеством закрывающих скобок \"}\"";
        public string Execute(string data)
        {
            var regularOpenBrackets = new Regex(@"{");
            var regularCloseBrackets = new Regex(@"}");
            return regularOpenBrackets.Matches(data).Count == regularCloseBrackets.Matches(data).Count
                ? "Совпадает"
                : "Не совпадет";
        }
    }
}
