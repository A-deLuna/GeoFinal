using System;
using Npgsql;
using System.Data;

namespace ProyectoFinal
{
	public class SingletonDB
	{
		private IDbConnection dbcon;
		private IDbCommand dbcmd;
		private static SingletonDB instance;
		private SingletonDB (){	
		
			string connectionString = 
				"Server=localhost;" +
				"Database=ProyectoFinal;" +
				"Port=5433;"+
				"User ID=postgres;" +
				"Password=amelia;";
			
			dbcon = new NpgsqlConnection (connectionString);
			dbcmd = dbcon.CreateCommand ();
			dbcon.Open ();
			//NpgsqlEventLog.Level = LogLevel.Debug;
			//NpgsqlEventLog.EchoMessages = true;
		}
		public IDataReader query(string sql){
			
			dbcmd.CommandText = sql;
			return dbcmd.ExecuteReader ();

		}
		public void execute(string sql){
			dbcmd.CommandText = sql;
			dbcmd.ExecuteNonQuery ();
		}
		public void close(){
			dbcmd.Dispose ();
			dbcmd = null;
			dbcon.Close();
			dbcon = null;

		}
		public static SingletonDB Instance
		{
			get {
				if (instance == null) {
					instance = new SingletonDB ();
				}
				return instance;
			}
		}
	}
}

