using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvAlmak.ColorConsole
{
    internal static class Print
    {
        /// <summary>
        /// Kişisel Renkli Console.Write 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public static void Write(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Kişisel Renkli Console.WriteLine
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public static void WriteLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
