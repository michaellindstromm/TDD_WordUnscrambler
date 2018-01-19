using System;
using Xunit;
using Unscrambler.CLI.Workers;

namespace Unscrambler.Test
{
    public class WordMatcherTest
    {

        private readonly WordMatcher _wordMatcher = new WordMatcher();

        [Fact]
        public void ScrambledWordMatchesGivenWordInList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre" };
            var matchedWords = _wordMatcher.Match(scrambledWords, words);

            Assert.True(matchedWords.Count == 1);
            Assert.Equal("omre", matchedWords[0].ScrambledWord);
            Assert.Equal("more", matchedWords[0].Word);

        }

        [Fact]
        public void ScrambledWordsMatchGivenWordInList()
        {
            string[] words = { "cat", "chair", "more" };
            string[] scrambledWords = { "omre", "act" };
            var matchedWords = _wordMatcher.Match(scrambledWords, words);

            Assert.True(matchedWords.Count == 2);
            Assert.Equal("omre", matchedWords[0].ScrambledWord);
            Assert.Equal("more", matchedWords[0].Word);
            Assert.Equal("act", matchedWords[1].ScrambledWord);
            Assert.Equal("cat", matchedWords[1].Word);

        }
    }
}
