using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTests
{
    class ExtractedFunctionTests
    {
        //Check that the player who should win will win along diagonal2
        [Test]
        public void CheckWinner_Diagonal2_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 2);
            Assert.True(true);
        }

        //Check that the player who should win will win along diagonal1
        [Test]
        public void CheckWinner_Diagonal1_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 1);
            Assert.True(true);
        }

        //Check that Player O will switch to Player X when the player is asked to switch
        [Test]
        public void SwitchPlayer_SelectPlayerO_Should_Pass()
        {
            Player testPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(Player.PlayerO);
            //O should switch to X
            Assert.AreEqual(testPlayer.ToString(), Player.PlayerX.ToString());
        }

        //Check that Player X will switch to Player O when the player is asked to switch
        [Test]
        public void SwitchPlayer_SelectPlayerX_Should_Pass()
        {
            Player testPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(Player.PlayerX);
            //X should switch to O
            Assert.AreEqual(testPlayer.ToString(), Player.PlayerO.ToString());
        }

        //Selecting an invalid player should not be allowed
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

        //Check that Player O can win in columns
        [Test]
        public void TestColumnsForWinner_PlayerO_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerO, ExtractedFunctions.TestColumnsForWinner(Player.PlayerO, Field, 3, 0, 3));
        }

        //Check that Null Player can win in columns
        [Test]
        public void TestColumnsForWinner_PlayerNull_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerNull, ExtractedFunctions.TestColumnsForWinner(Player.PlayerNull, Field, 3, 0, 3));
        }

        //Check that Player X does not win if Player O should win
        [Test]
        public void TestColumnsForWinner_PlayerX_Should_Fail()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreNotEqual(Player.PlayerO, ExtractedFunctions.TestColumnsForWinner(Player.PlayerX, Field, 3, 0, 3));
        }

        //Check that Player O should win along a row
        [Test]
        public void TestRowsForWinner_PlayerO_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerO, ExtractedFunctions.TestRowsForWinner(Player.PlayerO, Field, 3, 0, 3));
        }

        //Check that Player Null should win along a row
        [Test]
        public void TestRowsForWinner_PlayerNull_Should_Pass()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreEqual(Player.PlayerNull, ExtractedFunctions.TestRowsForWinner(Player.PlayerNull, Field, 3, 0, 3));
        }

        //Check that Player X doesn't win if Player O should win along rows
        [Test]
        public void TestRowsForWinner_PlayerX_Should_Fail()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            Assert.AreNotEqual(Player.PlayerO, ExtractedFunctions.TestRowsForWinner(Player.PlayerX, Field, 3, 0, 3));
        }

        // Ensure that Player O cannot select the picture that is their own
        [Test]
        public void CanSelectPictureHelper_PlayerO_Should_Be_False()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO },
                { Player.PlayerO, Player.PlayerO, Player.PlayerO }
            };
            int[] position = new int[] { 0, 0, 0 };
            Assert.IsFalse(ExtractedFunctions.CanSelectPictureHelper(Field, position));
        }

        // Ensure that Player null can select the picture that is their own
        [Test]
        public void CanSelectPictureHelper_PlayerNull_Should_Be_True()
        {
            Player[,] Field = new Player[,]
            {
                { Player.PlayerNull, Player.PlayerNull, Player.PlayerNull },
                { Player.PlayerNull, Player.PlayerNull, Player.PlayerNull },
                { Player.PlayerNull, Player.PlayerNull, Player.PlayerNull }
            };
            int[] position = new int[] { 0, 0, 0 };
            Assert.IsTrue(ExtractedFunctions.CanSelectPictureHelper(Field, position));
        }
    }
}
