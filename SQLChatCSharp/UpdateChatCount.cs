using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQLChatCSharp
{
    class UpdateChatCount
    {


        public void Update(MySqlConnection conn, out Int32 cnt)
        {
            RunSQLCommand cmdrun = new RunSQLCommand();



            string cmdout;
            cmdrun.comrun("SELECT COUNT(*) FROM chat", conn, out cmdout);

            cnt = Convert.ToInt32(cmdout);
        }

    }
}
