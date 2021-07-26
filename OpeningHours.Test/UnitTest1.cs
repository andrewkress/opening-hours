using System;
using Xunit;
using OpeningHours.Controllers;
using System.IO;
using Newtonsoft.Json;
using OpeningHours.Models;

namespace OpeningHours.Test {
    public class UnitTest1 {
        private OpenHourController ohc;
        public UnitTest1() {
            ohc = new OpenHourController(null);
        }
        [Theory]
        [InlineData(@"TestFiles\test1.json", @"TestFiles\test1.txt")]
        [InlineData(@"TestFiles\test2.json", @"TestFiles\test2.txt")]
        [InlineData(@"TestFiles\test3.json", @"TestFiles\test3.txt")]
        public void Test1(String fileName, String expected) {
            OpenHour oh = JsonConvert.DeserializeObject<OpenHour>(File.ReadAllText(fileName));
            String expectedText = File.ReadAllText(expected);
            String result = ohc.Post(oh);
            Assert.Equal(expectedText, result);
        }
    }

}
