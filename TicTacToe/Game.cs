using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: InternalsVisibleTo("TicTacToeTests")]


namespace TicTacToe
{

    public static class ExtractedFunctions
    {
        public static int something = 0;

        public static Game.GameResult CheckWinner(Player lastDia2Elem, Game.GameResult result, int winner)
        {
            if (lastDia2Elem != Player.PlayerNull)
            {
                Debug.WriteLine("SUCCESS: found result in diagonal " + winner);
                result.Winner = lastDia2Elem;
                result.Diagonal = winner;
            }
            return result;
        }

        public static Player SwitchPlayer_SelectPlayer(Player CurrentPlayer)
        {
            if (CurrentPlayer == Player.PlayerO)
            {
                CurrentPlayer = Player.PlayerX;
            }
            else if (CurrentPlayer == Player.PlayerX)
            {
                CurrentPlayer = Player.PlayerO;
            }
            else
            {
                throw new InvalidOperationException("player state invalid");
            }

            return CurrentPlayer;
        }

        public static Player TestColumnsForWinner(Player lastLineElem, Player[,] Field, int numColumns, int line)
        {
            for (int column = 0; column < numColumns; column++)
            {
                Player currElement = Field[column, line];
                Debug.WriteLine("CheckGameResult: column {0}, line {1} = {2}", column, line, currElement);

                // break loop if no marked line can be found
                if (currElement == Player.PlayerNull || currElement != lastLineElem)
                {
                    // nullify last line element to indicate break
                    lastLineElem = Player.PlayerNull;
                    break;
                }
            }

            return lastLineElem;
        }

        public static Player TestRowsForWinner(Player lastColElem, Player[,] Field, int numLines, int column)
        {
            for (int line = 0; line < numLines; line++)
            {
                Player currElement = Field[column, line];
                Debug.WriteLine("CheckGameResult: column {0}, line {1} = {2}", column, line, currElement);

                // break loop if no marked column can be found
                if (currElement == Player.PlayerNull || currElement != lastColElem)
                {
                    // nullify last line element to indicate break
                    lastColElem = Player.PlayerNull;
                    break;
                }
            }

            return lastColElem;
        }

    }

    public enum Player
    {
        PlayerNull = 0, // field not played/unspecified player
        PlayerX = 1,
        PlayerO = 2
    }

    public class Game
    {
        public Player CurrentPlayer { get; set; }

        public Player[,] Field = new Player[3, 3];
        private GameForm gameWindow;
        private int gameFieldsMax;
        public int GameFieldsUsed { get; protected set; }

        /// <summary>
        /// simple constructor
        /// </summary>
        /// <param name="gameWindow">the window where the game should be "attached to"/executed</param>
        public Game(GameForm gameWindow)
        {
            this.gameWindow = gameWindow;
        }

        /// <summary>
        /// gets into form loop
        /// </summary>
        public void StartGame()
        {
            this.CurrentPlayer = this.gameWindow.GetStartPlayer();

            Debug.WriteLine("Started new game with player {0}", this.CurrentPlayer);

            // erase player array, so we can start with an empty one, if needed
            this.Field = new Player[3, 3];
            GameFieldsUsed = 0;

            gameFieldsMax = 3 * 3;
        }

        /// <summary>
        /// wether the user can actually select that picture
        /// </summary>
        /// <param name="pos">The position as a two-dimensional array:
        ///     0=x=column;
        ///     1=y=line
        /// </param>
        public bool CanSelectPicture(int[] pos)
        {
            // only allow clicks on PlayerNull fields
            return (this.Field[pos[0], pos[1]] == Player.PlayerNull);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos">The position as a two-dimensional array:
        ///     0=x=column;
        ///     1=y=line
        /// </param>
        public void SelectPicture(int[] pos)
        {
            Debug.WriteLine("SelectPicture: column {0}, line {1}", pos[0], pos[1]);

            this.Field[pos[0], pos[1]] = this.CurrentPlayer;

            // one more field selected
            GameFieldsUsed++;
        }

        public void SwitchPlayer()
        {
            this.CurrentPlayer = ExtractedFunctions.SwitchPlayer_SelectPlayer(this.CurrentPlayer);

            // also change GUI state
            this.gameWindow.SetPlayerState(this.CurrentPlayer);
        }

        public void CheckGameEnd()
        {
            GameResult result = GetGameResult();

            // early return if noone won
            switch (result.Winner)
            {
                case null:
                    // in case of no winner, just continue game
                    return;
                case Player.PlayerNull:
                    // stalemate
                    this.gameWindow.EndGameStalemate();
                    break;
                // fall through for "usual" players
                case Player.PlayerO:
                case Player.PlayerX:
                    // show winner message
                    this.gameWindow.EndGameWinner((Player)result.Winner, result.Line, result.Column, result.Diagonal);
                    break;
                default:
                    throw new InvalidOperationException("returned winner status is invalid");
            }
            
            // start new game
            this.StartGame();
            this.gameWindow.StartGame(this);
        }

        public struct GameResult
        {
            public Player? Winner { get; set; }
            public int? Line { get; set; }
            public int? Column { get; set; }
            public int? Diagonal { get; set; }
            public GameResult(Player? winner, int? line, int? column, int? diagonal)
            {
                this.Winner = winner;
                this.Line = line;
                this.Column = column;
                this.Diagonal = diagonal;
            }
        }
        
        /// <summary>
        /// Return the lines, columns and diagonal elements where a player won, if they won...
        /// 
        /// In case of a stalemate it returns "PlayerNull" as the winner.
        /// </summary>
        public GameResult GetGameResult()
        {
            int numLines = this.Field.GetLength(1);
            int numColumns = this.Field.GetLength(0);

            // intialize var with first item as this is always the first reference
            Player lastLineElem = this.Field[0, 0];

            // line, column, diagonal
            GameResult result = new GameResult();

            // loop through lines in order to find marked ones
            for (int line = 0; line < numLines; line++)
            {
                // new line
                lastLineElem = this.Field[0, line];

                Debug.WriteLine("testing line {0} of {1}", line, numLines-1);

                lastLineElem = ExtractedFunctions.TestColumnsForWinner(lastLineElem, this.Field, numColumns, line);

                // if we are at the end and we found no different value in line, someone won
                if (lastLineElem != Player.PlayerNull)
                {
                    Debug.WriteLine("SUCCESS: found line {0}", line);
                    result.Winner = lastLineElem;
                    result.Line = line;
                    // only one line can be matching when properly checked -> do not need to test more
                    break;
                }
            }

            // again first item first
            Player lastColElem = this.Field[0, 0];

            // loop through columns in order to find marked ones
            for (int column = 0; column < numColumns; column++)
            {
                // new line
                lastColElem = this.Field[column, 0];

                Debug.WriteLine("testing column {0} of {1}", column, numColumns-1);

                lastColElem = ExtractedFunctions.TestRowsForWinner(lastColElem, this.Field, numLines, column);

                // if we are at the end and we found no different value in column, someone won
                if (lastColElem != Player.PlayerNull)
                {
                    Debug.WriteLine("SUCCESS: found column {0}", column);
                    result.Winner = lastColElem;
                    result.Column = column;
                    // only one line can be matching when properly checked -> do not need to test more
                    break;
                }
            }

            // again first item first
            Player lastDia1Elem = this.Field[0, 0];

            // check diagonal 1
            for (int dia = 0; dia < numColumns; dia++)
            {
                Player currElement = this.Field[dia, dia];
                Debug.WriteLine("CheckGameResult: dia1 {0}, line {1} = {2}", dia, dia, currElement);

                // break loop if no marked element can be found
                if (currElement == Player.PlayerNull || currElement != lastDia1Elem)
                {
                    // nullify last line element to indicate break
                    lastDia1Elem = Player.PlayerNull;
                    break;
                }
            }

            // if we are at the end and we found no different value in dia, someone won
            result = ExtractedFunctions.CheckWinner(lastDia1Elem, result, 1);

            // this time we start from upper right, so first element is this...
            Player lastDia2Elem = this.Field[2, 0];

            // check diagonal 2
            for (int dia1 = 0; dia1 < numColumns; dia1++)
            {
                // the second diagonale is the "reverse" from dia1
                int dia2 = 2 - dia1;

                Player currElement = this.Field[dia1, dia2];
                Debug.WriteLine("CheckGameResult: dia2 {0}, line {1} = {2}", dia1, dia2, currElement);

                // break loop if no marked element can be found
                if (currElement == Player.PlayerNull || currElement != lastDia2Elem)
                {
                    // nullify last line element to indicate break
                    lastDia2Elem = Player.PlayerNull;
                    break;
                }
            }

            // if we are at the end and we found no different value in dia, someone won
            result =  ExtractedFunctions.CheckWinner(lastDia2Elem, result, 2);

            // if we found no other winner, check whether all fields are full
            if (result.Winner == null && (GameFieldsUsed == gameFieldsMax))
            {
                // we have a stalemate here -> PlayerNull won
                return new GameResult(Player.PlayerNull, null, null, null);
            }

            return result;
        }
    }
}
