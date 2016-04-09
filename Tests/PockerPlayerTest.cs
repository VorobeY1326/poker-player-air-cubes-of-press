using System;
using System.IO;
using ClassLibrary;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PockerPlayerTest
    {
        [Test]
        public void RunBetR()
        {
            var str = File.ReadAllText("D:\\data1.txt");
            var j = JObject.Parse(str);
            Console.WriteLine(PokerPlayer.BetRequest(j));
        }
    }
}