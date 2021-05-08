using System;
using UniqueFourLetters.Library;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace UniqueFourLetters.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Get the word list from input/words.txt
            string[] wordList=FileOperatorService.GetAllWordsFromFile(@"input/words.txt");

            //Creating an instance of the UniqueFourLettersLibrary 
            UniqueFourLettersLibrary uniqueFourLettersLibrary = new UniqueFourLettersLibrary();

            //Creates a dictionary of unique and repeated words in the list of words supplied 
            uniqueFourLettersLibrary.AddUniqueAndRepeatedWordsToDictionary(wordList); 

            //Get the sorted, unique word chunks and their corresponding words from where the chunks were sourced from 
            var result=uniqueFourLettersLibrary.GetUniqueAndFullWordLists();     

            List<string> uniqueWordList=result.UniqueWords;
            List<string> fullWordList=result.FullWords;

            //Create uniques and fullwords in parallel.
            var tasks = new List<Task>();
            tasks.Add((FileOperatorService.WriteToFile(uniqueWordList, @"output/uniques.txt")));
            tasks.Add((FileOperatorService.WriteToFile(fullWordList, @"output/fullwords.txt")));
            await Task.WhenAll(tasks);   

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0}.{1:00}",
            ts.Seconds,
            ts.Milliseconds);
            System.Console.WriteLine("RunTime for the operation: " + elapsedTime+" s");  

        }
    }
}
