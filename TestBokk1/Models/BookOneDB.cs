using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using System.Web;
using Dapper;
using System.Web.Mvc;
using System.Data;

namespace TestBokk1.Models //Why the interface here
{
   
    public class BookOneDB
    {


        private static string _connectionString = Properties.Settings.Default._connectionString;
        //public string RunOnConnectionError { get; private set; }


        //public IEnumerable<Book> GetBooks()
        //{
        //    IEnumerable<Book> books = null;
        //    RunOnConnection((dbCon) =>
        //    {
        //        books = dbCon.Query<Book>("select * from Book");
        //    });
        //    return books;
        //}      
        ////Ti kanei?
        //public bool RunOnConnection(Action<SqlConnection> execute)
        //{
        //    bool success = true;
        //    RunOnConnectionError = null;

        //    using (var dbcon = new SqlConnection(_connectionString))
        //    {
        //        try
        //        {
        //            execute(dbcon);
        //        }
        //        catch (DbException e)
        //        {
        //            RunOnConnectionError = e.Message;
        //            success = false;
        //        }
        //    }
        //    return success;
        //}

        // Start All Over


        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }

        }

        //BookOneDB.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }

        //DapperORM.ReturnList<EmployeeModel> <=  IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(_connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }

        }



    }
}