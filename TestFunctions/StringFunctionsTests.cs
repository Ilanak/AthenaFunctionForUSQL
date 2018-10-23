using AthenaFunctionsForUSQL;
using System;
using Xunit;

namespace AthenaFunctionsForUSQLTests
{
    public class StringFunctionsTests
    {
        [Fact]
        public void TestLevenshteinDistance()
        {
            Assert.Equal(1, StringFunctions.LevenshteinDistance("abc", "acc"));
            Assert.Equal(2, StringFunctions.LevenshteinDistance("abc", "aca"));
            Assert.Equal(3, StringFunctions.LevenshteinDistance("abc", "ddd"));
        }

        [Fact]
        public void SplitPartTest()
        {
            Assert.Equal("def", StringFunctions.SplitPart("abc,123,def,456", ",", 2));
            Assert.Equal(string.Empty, StringFunctions.SplitPart("abc,123,def,456", ",", 10));
        }

        [Fact]
        public void SplitToMapTest()
        {
            // split first by "," and then by "-"
            var map = StringFunctions.SplitToMap("1-John,2-Rob,3-Tami", ",", "-");
            Assert.Equal(3, map.Keys.Count);
            Assert.Equal("John", map["1"]);
            Assert.Equal("Rob", map["2"]);
            Assert.Equal("Tami", map["3"]);

            try
            {
                map = StringFunctions.SplitToMap("1-John,2Rob", ",", "-");
                
            }
            catch (ArgumentException e)
            {
                Assert.Equal("Expected for two values after splitting by -, but received 1", e.Message);
            }
           
        }
    }
}
