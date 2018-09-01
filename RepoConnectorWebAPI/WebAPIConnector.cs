using Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace RepoConnectorWebAPI
{
    public class WebAPIConnector : IRepoConnection {
        string m_DbFileName; // "SQLiteDB.sqlite";
        string m_ConnectionString; // "Data Source=" + m_DbFileName + ";"; //Data Source=SQLiteDB.sqlite;
        string m_Database = "";

        //###	Properties

        //Returns Database name-
        public string DatabaseName {
            get { return m_Database; }
            set { m_Database = value; }
        }

        public string ConnectionString {
            get {
                return m_ConnectionString;
            }
            set {
                m_ConnectionString = value;
            }
        }

        //Returns connection string with Database name
        private string ConnectionStringWithDBname {
            get {
               return "";
            }
        }


        //####	Constuctor

        //I realize using IConfiguration here means this Implementation assumes use with ASP.NET Core
        //However since constructors are not determined by Interfaces, IRepoConnection makes no such assumption
        //I feel it is reasonable to either re-implement IRepoConnection for a non(ASP.NET Core) app or,
        //Sub-class this class and change the constructor to as needed

        public WebAPIConnector(IConfiguration aConfiguration) { 
            var vConnectionString = aConfiguration.GetSection("ConnectionStrings:WebAPIConnection");
            ConnectionString = vConnectionString.Value;
        }


        //####	Methods

        //Takes connection string returns SQLiteConnection
        public IDbConnection Connection(string aConnectionString) {
            return null;
        }

        public IDbConnection Connection() {
            return null;
        }

    }
}
