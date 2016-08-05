using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SQLChatCSharp
{
    class SendMsg
    {

        public void send(string text, string user)

        {
            string test;
            Program program = new Program();
            SQLConnect connect = new SQLConnect();
            RunSQLCommand cmdrun = new RunSQLCommand();
            MySqlConnection conn = connect.connect();
            bool pm;

            string userto;
            Regexfind(text, out userto, out pm);
            if (pm == true)
            {
                RegexReplace(text, "\\" + userto + " ", "", out text);
                RegexReplace(userto, "\\/", "", out userto);
            }
            cmdrun.comrun("INSERT INTO chat (message, user, userto) VALUES('" + text + "', '" + user + "', '" + userto + "'); ", conn, out test);
        }

        public void Regexfind(string text, out string found, out bool pm)
        {

            pm = false;
            Regex regex = new Regex(@"\/\w*");
            Match match = regex.Match(text);
            found = null;
            if (match.Success)
            {
                found = match.Value;
                pm = true;
            }

        }

        public void RegexReplace(string text, string pattern, string replace, out string replacement)
        {

            string input = text;
            
            
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(input, replace);

            replacement = result;

        }
    }
}
