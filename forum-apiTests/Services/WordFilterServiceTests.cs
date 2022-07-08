using Microsoft.VisualStudio.TestTools.UnitTesting;
using forum_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using forum_api.Services.Interfaces;

namespace forum_api.Services.Tests
{
    [TestClass()]
    public class WordFilterServiceTests
    {
        private string _sentenceWithInsults;

        private IWordFilterService _wordFilterService;

        [TestInitialize]
        public void SetUp()
        {
            this._wordFilterService = new WordFilterService();
            this._sentenceWithInsults = "s**e, s******d.";
        }

        [TestMethod()]
        [DataRow("sale, salopard.")]
        public void FilterWordWithGoodArgumentShouldReturnSentenceWithWordsWithStars(string sentenceWithInsults)
        {
            // act
            string result = _wordFilterService.FilterWord(sentenceWithInsults);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, this._sentenceWithInsults);
        }
    }
}