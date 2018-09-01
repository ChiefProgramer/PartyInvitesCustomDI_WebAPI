using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Contracts;
using Entities;
using System.Linq;

namespace RepositoryDapper {
    public class GuestDapper : IGuestR {
        private IRepoConnection _DataConnector;

        public GuestDapper (IRepoConnection aRepoConnection) {
            _DataConnector = aRepoConnection;

            SetupDataBase();
        }

        //this creates DB and add tables... if needed
        private void SetupDataBase() {
            DbCreator mDbCreator = new DbCreator(_DataConnector);

            //if this fails its becasue we did not need to do this 
            mDbCreator.CreateDB();
            mDbCreator.CreateTables();
        }


        public void Add(Guest aGuest) {
            string vSQL = "insert into Guests (name, email, phone, WillAttend) values(@Name, @Email, @Phone, @WillAttend)";
            Execute(vSQL, aGuest);
        }

        public async Task<int> CountAsync() {
            string vSQL = "SELECT COUNT(*) From Guests"; ;
            IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database
            var vResult = await vDataConn.ExecuteScalarAsync<int>(vSQL);
            vDataConn.Close();
            return vResult;

        }

        public void Delete(int aGuestId) {
            string vSQL = "DELETE FROM Guest WHERE Id = @Id";
            IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database

            vDataConn.Execute(vSQL, new { Id = aGuestId });
        }
         
        public async Task<List<Guest>> GetAllAsync() {
                string vSQL = "SELECT * From Guests";
                List<Guest> vGuestList = new List<Guest>();

                IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database

                var vResult = await vDataConn.QueryAsync<Guest>(vSQL);
                vGuestList = vResult.AsList();
                vDataConn.Close();
                return vGuestList;

        }

        public async Task<Guest> GetAsync(int aGuestId) {

                string vSQL = "SELECT * From Guests WHERE id = " + aGuestId;
                Guest vGuest = new Guest(); 

                IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database

                var vResult = await vDataConn.QueryAsync<Guest>(vSQL, new { Id = aGuestId });
                vGuest = vResult.FirstOrDefault();
        
                vDataConn.Close();
                return vGuest;

        }

        public void Update(Guest aGuest) {
            string vSQL = "UPDATE Guests SET name = @Name, email = @Email, phone = @Phone, WillAttend = @WillAttend WHERE id = @Id";
            IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database

            vDataConn.QueryAsync(vSQL, aGuest);

            vDataConn.Close();
        }

        //Execute SQL returns true if sucessful;
        private bool Execute(string aSQL, Guest aGuest) {
            IDbConnection vDataConn = _DataConnector.Connection(); //Gets open connection to Database

            try {
                vDataConn.ExecuteAsync(aSQL, aGuest);
            } catch {
                vDataConn.Close();
                return false;
            }
            vDataConn.Close();
            return true;
        }



    }


}