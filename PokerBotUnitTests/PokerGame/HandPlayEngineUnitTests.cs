using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicomputer.PokerBot.PokerGame;
using Nicomputer.PokerBot.UnitTests.Common;

namespace Nicomputer.PokerBot.UnitTests.PokerGame
{
    [TestClass]
    public class HandPlayEngineUnitTests
    {
        [TestMethod]
        [TestCategory("Hand Play Engine")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Table_Is_Not_Opened()
        {
            var table = new Table(9);
            var hpEngine = new HandPlayEngine(table);
            hpEngine.Run();
        }

        [TestMethod]
        [TestCategory("Hand Play Engine")]
        public void Table_Is_Opened()
        {
            var table = PokerGameUnitTestsHelper.CreateAndOpenTable(9, 9);
            var hpEngine = new HandPlayEngine(table);
            Assert.AreEqual(1, table.Turn);
            hpEngine.Run();
            Assert.AreEqual(2, table.Turn);
            Assert.AreEqual(0, table.ButtonPosition);
            Assert.AreEqual(1, table.SmallBlindPosition);
            Assert.AreEqual(2, table.BigBlindPosition);
            hpEngine.Run();
            Assert.AreEqual(3, table.Turn);
            Assert.AreEqual(1, table.ButtonPosition);
            Assert.AreEqual(2, table.SmallBlindPosition);
            Assert.AreEqual(3, table.BigBlindPosition);
        }
    }
}
