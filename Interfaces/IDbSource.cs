using System;
using System.Collections.Generic;
using System.Text;
using zIinz_3_bigdata.Classes.Database;

namespace zIinz_3_bigdata.Interfaces
{
    public interface IDbSource
    {
        bool IsConnected { get; }

        bool Connect();
        bool Disconnect();

        int ExecuteNonQuery(string a_sQuery);
        int ExecuteNonQuery(string[] a_oQueries);

        void TransactionStart();
        void TransactionRollback();
        void TransactionCommit();

        bool Exists<T>(DbObject<T> Object) where T : class;
        bool Select<T>(DbObject<T> Object) where T : class;
        bool Insert<T>(DbObject<T> Object) where T : class;
        bool Update<T>(DbObject<T> Object) where T : class;
        bool Delete<T>(DbObject<T> Object) where T : class;

        List<DbRow> ExecuteReader(string a_sQuery);
        List<T> ExecuteReader<T>(string a_sWhereClausule = "", string a_sOrderByClausule = "") where T : DbObject<T>, new();
    }
}
