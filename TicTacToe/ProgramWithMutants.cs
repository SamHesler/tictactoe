using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TicTacToeTests")]

namespace TicTacToe
{
    static class ProgramWithMutants
    {
        /// <summary>
        /// Helper function, thanks https://stackoverflow.com/a/4135491
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string FirstLetterToUpper(string str)
        {
            if (str != null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        /// <summary>
        /// replace the last occurence of a string, thanks https://stackoverflow.com/a/14826068
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Find"></param>
        /// <param name="Replace"></param>
        /// <returns></returns>
        internal static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place > -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
    }
}
