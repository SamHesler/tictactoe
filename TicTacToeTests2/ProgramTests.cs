using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTests
{
    public class ProgramTests
    {
        [Test]
        public void FirstLetterToUpper_Valid_ParamNull_ReturnNull()
        {
            string lower = null;
            Assert.AreEqual(Program.FirstLetterToUpper(lower), null);
        }

        [Test]
        public void FirstLetterToUpper_Valid_StrLenGreaterThan1_ReturnCorrect()
        {
            string lower = "lower";
            string upper = "Lower";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }

        [Test]
        public void FirstLetterToUpper_Valid_StrLenIsOne_ReturnCorrect()
        {
            string lower = "l";
            string upper = "L";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }
        [Test]
        public void FirstLetterToUpper_Valid_StrEmpty_ReturnEmpty()
        {
            string lower = "";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), "");
        }


        /*UNIT TEST ON ReplaceLastOccurrence
         */

        [Test]
        public void ReplaceLastOccurrence_Source_find_notmatch_Return_minusone()
        {
            
            string Source_test = "hello team";
            string Find_test = "all";
            string Replace_test = "great";
            
            Assert.AreEqual(Program.ReplaceLastOccurrence(Source_test, Find_test, Replace_test), Source_test);

        }


        [Test]

        public void ReplaceLastOccurrence_Source_find_match_ReturnReplaced_string()
        {
           
            string Source_test = "hello team hope you are good";
            string Find_test = "good";
            string Replace_test = "great";
            string Final_string_replaced = "hello team hope you are great";
            Assert.AreEqual(Program.ReplaceLastOccurrence(Source_test, Find_test, Replace_test), Final_string_replaced);

        }

        /*
        public void ReplaceLastOccurrence_EmptyString_Check()
        {
            string Source_test = " ";
            string Find_test = " ";
            string Replace_test = " ";
            Assert.AreEqual(Program.ReplaceLastOccurrence(Source_test, Find_test, Replace_test), Source_test);

        }
        */

       
       [Test]
       public void Random_Valid_SetsCorrectlyAndGetsCorrectly()
       {
            Random rand = new Random();
            Program.Random = rand;
            Assert.AreEqual(Program.Random, rand);
       }


    }




}




