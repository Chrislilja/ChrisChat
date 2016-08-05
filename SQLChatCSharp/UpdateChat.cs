using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQLChatCSharp
{
    class UpdateChat
    {


        public void update(MySqlConnection conn, Int32 chatt, Int32 chatpoint, out Int32 chatpointer, string user)
        {
            RunSQLCommand cmdrun = new RunSQLCommand();
            string msg;
            string usr;
            string time;
            string usrto;

            do
            {


                if (chatpoint > chatt)
                {
                    break;
                }

                else
                {
                    cmdrun.comrun("SELECT userto FROM chat WHERE id='" + chatpoint + "';", conn, out usrto);


                    if (usrto == "" || usrto == user || user == "admin")
                    {
                        cmdrun.comrun("SELECT Message FROM chat WHERE id='" + chatpoint + "';", conn, out msg);
                        cmdrun.comrun("SELECT user FROM chat WHERE id='" + chatpoint + "';", conn, out usr);
                        cmdrun.comrun("SELECT timestamp FROM chat WHERE id='" + chatpoint + "';", conn, out time);

                        if (usrto == user || user == "admin")
                        {
                            Console.WriteLine(time + ":: PM from " + usr + " TO " + user + ">" + msg);
                        }
                        else
                        {
                            Console.WriteLine(time + "::" + usr + ">" + msg);
                        }
                       
                    }

                    chatpoint++;
                }
            } while (true);


            chatpointer = chatpoint;

        }
    }
}
