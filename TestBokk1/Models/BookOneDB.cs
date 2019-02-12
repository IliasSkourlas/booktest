using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using System.Web;
using Dapper;


namespace TestBokk1.Models //Why the interface here
{
   
    public class BookOneDB
    {


        private string _connectionString = Properties.Settings.Default._connectionStringWeb;
        public string RunOnConnectionError { get; private set; }


        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = null;
            RunOnConnection((dbCon) =>
            {
                books = dbCon.Query<Book>("select * from Book");
            });
            return books;
        }


        //Ti kanei?
        public bool RunOnConnection(Action<SqlConnection> execute)
        {
            bool success = true;
            RunOnConnectionError = null;

            using (var dbcon = new SqlConnection(_connectionString))
            {
                try
                {
                    execute(dbcon);
                }
                catch (DbException e)
                {
                    RunOnConnectionError = e.Message;
                    success = false;
                }
            }
            return success;
        }

    }
}