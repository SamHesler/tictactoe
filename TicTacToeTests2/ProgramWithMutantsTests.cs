using NUnit.Framework;
using System;
using TicTacToe;

namespace TicTacToeTests
{
    public class ProgramWithMutantsTests
    {
        /* FirstLetterToUpper Tests */
        // These are all the same tests as for the regular methods, they just call the mutant versions instead


        [Test] //Ensure that when given a null paramenter the function returns null
        public void FirstLetterToUpper_Valid_ParamNull_ReturnNull()
        {
            string lower = null;
            Assert.AreEqual(Program.FirstLetterToUpper(lower), null);
        }

        [Test] //Ensure that when given a string of length greater than 1 the function returns that same string,
               //but with the first letter capitalized
        public void FirstLetterToUpper_Valid_StrLenGreaterThan1_ReturnCorrect()
        {
            string lower = "lower";
            string upper = "Lower";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }

        [Test] //Ensure that when given a string of lenght 1 the funtion returns that same string in all caps
        public void FirstLetterToUpper_Valid_StrLenIsOne_ReturnCorrect()
        {
            string lower = "l";
            string upper = "L";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }

        [Test] //Ensure that when given an empty string the function returns an empty string
        public void FirstLetterToUpper_Valid_StrEmpty_ReturnEmpty()
        {
            string lower = "";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), "");
        }

        /* ReplaceLastOccurrence Tests */
        // These are all the same tests as for the regular methods, they just call the mutant versions instead


        [Test] //Ensure that when looking for a 'Find' string that is not located within the 'Source'
               //string the source string is returned unchanged
        public void ReplaceLastOccurrence_Source_find_notmatch_Return_minusone()
        {

            string Source_test = "hello team";
            string Find_test = "all";
            string Replace_test = "great";

            Assert.AreEqual(Program.ReplaceLastOccurrence(Source_test, Find_test, Replace_test), Source_test);

        }

        [Test] //Ensure that the 'Find' string is appropratly replaced with the 'Replace' string within the 'Source' string
        public void ReplaceLastOccurrence_Source_find_match_ReturnReplaced_string()
        {

            string Source_test = "hello team hope you are good";
            string Find_test = "good";
            string Replace_test = "great";
            string Final_string_replaced = "hello team hope you are great";
            Assert.AreEqual(Program.ReplaceLastOccurrence(Source_test, Find_test, Replace_test), Final_string_replaced);

        }

    }
}




