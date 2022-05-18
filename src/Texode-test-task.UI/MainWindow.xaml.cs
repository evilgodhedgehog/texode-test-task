using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Texode_test_task.Api.ViewModels;
using Texode_test_task.UI.Views;

namespace Texode_test_task.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PhoneViewModel> _phones = new ObservableCollection<PhoneViewModel>();
        private string _url = "https://localhost:7041/phone";

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
        }

        private async void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            await Get(_url);

            MainList.ItemsSource = _phones;
        }

        private async Task Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                _phones = JsonConvert.DeserializeObject<ObservableCollection<PhoneViewModel>>(jsonResponse);
            }
        }

         private async void AddButtonClick(object sender, RoutedEventArgs e)
        {
            await Get(_url);
            AddWindow objAddWindow = new AddWindow(_phones, MainList);
            objAddWindow.Show();
        }

        private async void EditButtonClick(object sender, RoutedEventArgs e)
        {
            await Get(_url);
            var index = MainList.SelectedIndex;

            if (index >= 0)
            {
                EditWindow objEditWindow = new EditWindow(_phones, index, MainList);
                objEditWindow.Show();
            }
        }

        private async void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            await Get(_url);
            var index = MainList.SelectedIndex;
            await Delete(_phones[index].Id);
            await Get(_url);
            MainList.ItemsSource = _phones;
        }

        private async Task Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7041");
                var response = await client.DeleteAsync($"/phone?id={id}");
            }
        }
    }
}