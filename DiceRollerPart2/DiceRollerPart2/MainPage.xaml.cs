using System;
using System.Collections.Generic; 
using Windows.UI.Xaml;  
using Windows.UI.Xaml.Controls; 

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceRollerPart2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
 
    public sealed partial class MainPage : Page
    {
        readonly MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            InitializeComponent();
            _mainPageViewModel = new MainPageViewModel();
            DataContext = _mainPageViewModel;
        }

        void Dice(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _mainPageViewModel.RollDice(button.Name);
        }

        void ClearButton(object sender, RoutedEventArgs e) => _mainPageViewModel.Reset();
    }
}
