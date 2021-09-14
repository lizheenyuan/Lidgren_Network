using System;

namespace LidgrenTest
{
    public interface ILog
    {
        void Debug(string s);
        void Warn(string s);
        void Error(string s);
        void Info(string s);
    }
    public class Log:ILog
    {
        public void Debug(string s)
        {
            string logflag = $"[{DateTime.Now.ToString("g")}---DEBUG---]:";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(logflag+s);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Warn(string s)
        {
            string logflag = $"[{DateTime.Now.ToString("g")}---WA RN---]:";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(logflag+s);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Error(string s)
        {
            string logflag = $"[{DateTime.Now.ToString("g")}---ERROR---]:";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(logflag+s);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Info(string s)
        {
            string logflag = $"[{DateTime.Now.ToString("g")}---IN FO---]:";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(logflag+s);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}