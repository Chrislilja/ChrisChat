using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SQLChatCSharp
{
    class Program
    {
       public Int32 TotalMSG;
      public  Int32 ReadMSG = 1;
      public  string user ;

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Enter User Name (Temp replacement for login)");
            program.user = Console.ReadLine();
            Console.WriteLine("Welcome " + program.user);
            

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(program.OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
 
            do
            {

                string text = Console.ReadLine();
                SendMsg sendmsg = new SendMsg();


                sendmsg.send(text, program.user);

               
            } while (true);


        }


        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            runChk();
        }

        public void runChk()
        {
            SQLConnect connect = new SQLConnect();
            UpdateChatCount cnt = new UpdateChatCount();
            UpdateChat chat = new UpdateChat();
            MySqlConnection conn = connect.connect();
            cnt.Update(conn, out TotalMSG);
            chat.update(conn, TotalMSG, ReadMSG, out ReadMSG, user);

        }

        private void pause()
        {
            //End of program do shit, backups, logs, dispatch to db 
            Console.ReadLine();
        }

    }
}
