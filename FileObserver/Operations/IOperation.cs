namespace FileObserver.Operations
{
    interface IOperation
    {
        string OperationName { get; }

        string Execute(string data);
    }
}
