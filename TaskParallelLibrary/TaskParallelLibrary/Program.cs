using System;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations op = new Operations();
            string[] words = op.CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(
                   () =>
                   {
                       Console.WriteLine("Begin First Task ...");
                       op.GetLongestWord(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Second Task ...");
                       op.GetMostCommonWords(words);
                   },
                   () =>
                   {
                       Console.WriteLine("Begin Third Task ...");
                       op.GetCountForWord(words, "sleep");
                   }
                );
            Console.WriteLine("Returned From Parallel.Invoke");
            #endregion
        }
    }
}