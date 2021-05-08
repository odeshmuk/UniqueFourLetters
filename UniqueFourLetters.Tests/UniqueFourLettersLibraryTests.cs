using System;
using Xunit;
using UniqueFourLetters.Library;
using System.Collections.Generic;

namespace UniqueFourLetters.Tests
{
    public class UniqueFourLettersLibraryTest
    {

        UniqueFourLettersLibrary uniqueFourLettersLibrary;

        public UniqueFourLettersLibraryTest()
        {
            uniqueFourLettersLibrary = new UniqueFourLettersLibrary();
        }

        [Theory]
        [InlineData("for", "")]
        [InlineData("book", "book")]
        [InlineData("10book", "book")]
        [InlineData("10'$book#<", "book")]
        public void Test_SanitizeWord_Returns_OnlyLetters(string word, string expected)
        {
            string actual = uniqueFourLettersLibrary.SanitizeWord(word);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new string[] { "book" }, new string[] { "book" }, new string[] { "book" })]
        [InlineData(new string[] { "book", "for" }, new string[] { "book" }, new string[] { "book" })]
        [InlineData(new string[] { "book", "for", "14th" }, new string[] { "book" }, new string[] { "book" })]
        [InlineData(new string[] { "Fort", "fort" }, new string[] { "fort", "Fort" }, new string[] { "fort", "Fort" })]
        [InlineData(new string[] { "bicycle" }, new string[] { "bicy", "cycl", "icyc", "ycle" }, new string[] { "bicycle", "bicycle", "bicycle", "bicycle" })]
        [InlineData(new string[] { "bicycle", "recycle" }, new string[] { "bicy", "ecyc", "icyc", "recy" }, new string[] { "bicycle", "recycle", "bicycle", "recycle" })]
        public void Test_AddUniqueAndRepeatedWordsToDictionary_Validates_Unique_And_Repeated_Words(string[] wordList, string[] expectedUniqueWords, string[] expectedFullWords)
        {
            uniqueFourLettersLibrary.AddUniqueAndRepeatedWordsToDictionary(wordList);
            var uniqueAndFullWordListModel = uniqueFourLettersLibrary.GetUniqueAndFullWordLists();
            Assert.Equal(expectedUniqueWords, uniqueAndFullWordListModel.UniqueWords);
            Assert.Equal(expectedFullWords, uniqueAndFullWordListModel.FullWords);
        }
    }


}