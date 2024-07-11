using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace DiceRollerPart2
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Random _randomNumberGenerator = new Random();
        MainPageModel _mainPageModel = new MainPageModel();
        int _sumRandomNumbers = 0;
        string _individualRolls;

        readonly Dictionary<string, int> _sidesMap = new Dictionary<string, int>
        {
            { "twoSided", 2 },
            { "threeSided", 3 },
            { "fourSided", 4 },
            { "sixSided", 6 },
            { "eightSided", 8 },
            { "tenSided", 10 },
            { "twelveSided", 12 },
            { "twentySided", 20 },
            { "oneHundredSided", 100 }
        }; 

        public int SumRandomNumbers
        {
            get => _sumRandomNumbers;
            set
            {
                if (_sumRandomNumbers != value)
                {
                    _sumRandomNumbers = value;
                    OnPropertyChanged();
                }
            }
        }

        public string IndividualRolls
        {
            get => _individualRolls;
            set
            {
                if (_individualRolls != value)
                {
                    _individualRolls = value;
                    OnPropertyChanged();
                }
            }
        }

        void UpdateProperties(int randomNumber)
        {
            SumRandomNumbers += randomNumber;
            IndividualRolls = string.IsNullOrEmpty(_individualRolls) ? randomNumber.ToString() : $"{_individualRolls}+{randomNumber}";
        }

        void InsertRollData(int dice, int result) => _mainPageModel.DatabaseManager.InsertData(dice, result);

        int GenerateRandomNumber(int sides) => _randomNumberGenerator.Next(1, sides + 1);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RollDice(string buttonName)
        {
            int sides = _sidesMap[buttonName];
            int randomNumber = GenerateRandomNumber(sides);
            InsertRollData(sides, randomNumber);
            UpdateProperties(randomNumber);
        }

        public void Reset()
        {
            SumRandomNumbers = 0;
            IndividualRolls = string.Empty;
            _mainPageModel.DisplayData();
        }
    }
}