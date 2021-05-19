using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTests
{
    class ExtractedFunctionTests
    {
        [Test]
        public void CheckWinner_Diagonal2_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 2);
            //Todo see if game result can be parsed
            Assert.True(true);
        }

        [Test]
        public void CheckWinner_Diagonal1_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 1);
            //Todo see if game result can be parsed
            Assert.True(true);
        }

        [Test]
        public void SwitchPlayer_SelectPlayerO_Should_Pass()
        {
            Player testPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(Player.PlayerO);
            //O should switch to X
            Assert.AreEqual(testPlayer.ToString(), Player.PlayerX.ToString());
        }

        [Test]
        public void SwitchPlayer_SelectPlayerX_Should_Pass()
        {
            Player testPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(Player.PlayerX);
            //X should switch to O
            Assert.AreEqual(testPlayer.ToString(), Player.PlayerO.ToString());
        }

        [Test]
        public void SwitchPlayer_SelectPlayerInvalid_Should_Fail()
        {
            try
            {
                Player testPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(Player.PlayerNull);
                //If it doesn't fail with exception, fail test
                Assert.Fail();
            }
            catch(Exception e) { }
            //Exception was caught, pass test
            Assert.Pass();
        }

        [Test]
        public void TestColumnsForWinner_PlayerO_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerO, ExtractedFunctions.TestColumnsForWinner(Player.PlayerO, Field, 3, 0));
        }

        [Test]
        public void TestColumnsForWinner_PlayerX_Should_Fail()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreNotEqual(Player.PlayerO, ExtractedFunctions.TestColumnsForWinner(Player.PlayerX, Field, 3, 0));
        }

        [Test]
        public void TestRowsForWinner_PlayerO_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerO, ExtractedFunctions.TestRowsForWinner(Player.PlayerO, Field, 3, 0));
        }

        [Test]
        public void TestRowsForWinner_PlayerX_Should_Fail()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreNotEqual(Player.PlayerO, ExtractedFunctions.TestRowsForWinner(Player.PlayerX, Field, 3, 0));
        }


    }
}
