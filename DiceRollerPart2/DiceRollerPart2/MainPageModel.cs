using System.IO;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Media.Audio;

namespace DiceRollerPart2
{
    public class MainPageModel
    {
        DatabaseManager _databaseManager;

        public DatabaseManager DatabaseManager => _databaseManager;

        public MainPageModel()
        {
            _databaseManager = new DatabaseManager();
            InitializeDatabaseAsync();
        }

        async void InitializeDatabaseAsync() => await _databaseManager.InitializeAsync();

        void OutputRollData(List<(int dice, int count, int avg)> results)
        {
            foreach (var (dice, count, avg) in results)
            {
                Debug.WriteLine($"Number of times {dice} rolled: {count}\nDice's average rolls: {avg}\n");
            }
        } 

        public void DisplayData()
        {
            var results = _databaseManager.GetDataFromDatabase();
            OutputRollData(results);
        }
    }
}