using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    class GameTests
    {
        /* GameResult Tests */


        [Test]
        public void GameResults_Valid_WinnerGetSet()
        {
            Game.GameResult gr = new Game.GameResult(Player.PlayerNull, 1, 1, 0);
            gr.Winner = Player.PlayerO;
            Assert.AreEqual(gr.Winner, Player.PlayerO);
        }

        [Test]
        public void GameResults_Valid_LineGetSet()
        {
            Game.GameResult gr = new Game.GameResult(Player.PlayerNull, -1, 1, 0);
            gr.Line = 1;
            Assert.AreEqual(gr.Line, 1);
        }

        [Test]
        public void GameResults_Valid_ColumnGetSet()
        {
            Game.GameResult gr = new Game.GameResult(Player.PlayerNull, 1, -1, 0);
            gr.Column = 1;
            Assert.AreEqual(gr.Column, 1);
        }

        [Test]
        public void GameResults_Valid_DiagonalGetSet()
        {
            Game.GameResult gr = new Game.GameResult(Player.PlayerNull, 1, 1, -1);
            gr.Diagonal = 1;
            Assert.AreEqual(gr.Diagonal, 1);
        }
    }
}
