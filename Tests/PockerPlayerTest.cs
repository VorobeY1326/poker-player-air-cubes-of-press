using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PockerPlayerTest
    {
        [Test]
        public void RunBetR()
        {
            Console.WriteLine(PokerPlayer.BetRequest(null));
        }
    }
}