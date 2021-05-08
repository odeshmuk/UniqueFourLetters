using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UniqueFourLetters.Library
{
    public class UniqueFourLettersLibrary
    {
        private SortedDictionary<string, string> uniqueWords;
        private Dictionary<string, string> repeatedWords;
        public UniqueFourLettersLibrary()
        {
            uniqueWords = new SortedDictionary<string, string>();
            repeatedWords = new Dictionary<string, string>();
        }

        //Given a word, returns only words which have more than 4 characters and contain only letters.
        public string SanitizeWord(string word)
        {
            string sanitizedWord = string.Empty;
            if (word.Length >= 4)
            {
                sanitizedWord = Regex.Replace(word, "[^a-zA-Z]", ""); ;
            }
            return sanitizedWord;
        }
        // given a word list, adds the 4 letter chunks to a unique sorted dictionary, and adds repeated words, if any to another dictionary for future checks to remove repeated chunks from uniqueWord dictionary
        public void AddUniqueAndRepeatedWordsToDictionary(string[] wordList)
        {
            foreach (var item in wordList)
            {
                string cleanedWord = SanitizeWord(item);
                if (!string.IsNullOrWhiteSpace(cleanedWord))
                {
                    for (int i = 0; i <= cleanedWord.Length - 4; i++)
                    {
                        string slidingWord = cleanedWord.Substring(i, 4);
                        if (!uniqueWords.ContainsKey(slidingWord))
                        {
                            uniqueWords.Add(slidingWord, item);
                        }
                        else
                        {
                            repeatedWords.Add(slidingWord, item);
                        }
                        if (repeatedWords.ContainsKey(slidingWord))
                        {
                            uniqueWords.Remove(slidingWord);
                        }
                    }
                }
            }

        }

        //Gets Unique And FullWord Lists for further operations
        public UniqueAndFullWordListModel GetUniqueAndFullWordLists()
        {
            List<string> uniques = new List<string>();
            List<string> fullWords = new List<string>();
            foreach (var item in uniqueWords)
            {
                uniques.Add(item.Key);
                fullWords.Add(item.Value);
            }
            UniqueAndFullWordListModel model = new UniqueAndFullWordListModel
            {
                UniqueWords = uniques,
                FullWords = fullWords
            };

            return model;
        }
    }
}