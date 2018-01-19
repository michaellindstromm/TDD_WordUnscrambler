using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Unscrambler.CLI.Workers;
using Unscrambler.CLI.Data;

namespace Unscrambler.CLI
{
    class Program
    {

        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFile = "wordList.txt";

        static void Main(string[] args)
        {
            bool continueUnscrambler = true;

            do
            {
                Console.WriteLine("Please enter the option - F for File and M for Manual.");
                var option = Console.ReadLine() ?? string.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.Write("Enter scrambled words file name:");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.Write("Enter scrambled words manually:");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.Write("Option was not recognized.");
                        break;
                }

                var continueDecision = string.Empty;

                do
                {
                    
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = (Console.ReadLine() ?? string.Empty);

                } while (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueUnscrambler = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueUnscrambler);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFile);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.word);
                }
            }
            else
            {
                Console.WriteLine("No matches have been found.");
            }
        }
    }

}
