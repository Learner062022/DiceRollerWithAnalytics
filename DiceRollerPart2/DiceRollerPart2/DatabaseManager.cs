using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DiceRollerPart2
{
    public class DatabaseManager
    {
        static SqliteConnection _database;
        static string _filePath;
        static bool _isInitialized = false;

        public async Task InitializeAsync()
        {
            if (!_isInitialized)
            {
                await InitialiseDatabaseAsync();
                OpenDatabaseConnection();
                CreateTable();
                _isInitialized = true;
            }
        }

        async Task InitialiseDatabaseAsync()
        {
            var databaseFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(FileManager.DatabaseFileName, CreationCollisionOption.OpenIfExists);
            _filePath = databaseFile.Path;
        }

        void OpenDatabaseConnection()
        {
            _database = new SqliteConnection($"Filename={_filePath}");
            _database.Open();
        }

        void CreateTable()
        {
            SqliteCommand createTable = new SqliteCommand("CREATE TABLE IF NOT EXISTS dice_results(dice TINYINT UNSIGNED, result TINYINT UNSIGNED);", _database);
            createTable.ExecuteNonQuery();
        }

        public void InsertData(int dice, int result)
        {
            string insertDataQuery = $"INSERT INTO dice_results(dice, result) VALUES ({dice}, {result});";
            SqliteCommand insertData = new SqliteCommand(insertDataQuery, _database);
            insertData.ExecuteReader();
        }

        public List<(int dice, int count, int avg)> GetDataFromDatabase()
        {
            string getDataQuery = $"SELECT dice, COUNT(dice) AS times_rolled, AVG(result) AS average_rolls FROM dice_resultS GROUP BY dice ORDER BY dice DESC;";
            List<(int dice, int count, int avg)> resultList = new List<(int dice, int count, int avg)>();
            SqliteCommand getData = new SqliteCommand(getDataQuery, _database);
            SqliteDataReader queryResult = getData.ExecuteReader();
            while (queryResult.Read())
            {
                int dice = queryResult.GetInt32(0);
                int count = queryResult.GetInt32(1);
                int avg = queryResult.GetInt32(2);
                resultList.Add((dice, count, avg));
            }
            return resultList;
        }
    }
}