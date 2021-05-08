using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace UniqueFourLetters.Library
{
    public static class FileOperatorService
    {
        public static string[] GetAllWordsFromFile(string filePath)
        {
            try
            {
                return System.IO.File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured at GetAllWordsFromFile: " + ex.Message);
            }
        }

        public static async Task<bool> WriteToFile(List<string> wordList, string fileLocation)
        {
            try
            {
                if (fileLocation.IndexOf('/') != -1)
                {
                    string folderName = fileLocation.Substring(0, fileLocation.LastIndexOf('/'));
                    Directory.CreateDirectory(folderName);
                }
                await File.WriteAllLinesAsync(fileLocation, wordList);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured at WriteToFile: " + ex.Message);
            }

        }

    }
}
