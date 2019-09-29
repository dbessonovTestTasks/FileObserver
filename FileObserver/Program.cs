using System;
using FileObserver.FileAnalyzers;
using FileObserver.Operations;

namespace FileObserver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var observer = new FileObserver(Settings.ObservedFolder);
                observer.Register(new FileAnalizer(@".*\.css", new BracketsCheckOperation()));
                observer.Register(new FileAnalizer(@".*\.html", new DivCountOperation()));
                observer.Register(new FileAnalizer(@".*", new PunctuationCountOperation()));

                observer.StartWatch();

                Console.WriteLine("Press 'q' to stop.");
                while (Console.Read() != 'q') ;

                observer.StopWatch();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
