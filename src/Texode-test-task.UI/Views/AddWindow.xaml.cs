using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;
using Texode_test_task.Api.ViewModels;

namespace Texode_test_task.UI.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private ObservableCollection<PhoneViewModel> _phones = new ObservableCollection<PhoneViewModel>();
        private ListBox _mainList = new ListBox();

        public AddWindow(ObservableCollection<PhoneViewModel> phones, ListBox mainList)
        {
            InitializeComponent();
            _phones = phones;
            _mainList = mainList;
        }

        private async void SubmitClick(object sender, RoutedEventArgs e)
        {
            string manufacturer = ManufactureTextBox.Text.Trim();
            string model = ModelTextBox.Text.Trim();
            string imageLink = ImageLinkTextBox.Text.Trim();
            decimal price;

            decimal.TryParse(PriceTextBox.Text.Trim(), out price);

            if (manufacturer == "")
            {
                ManufactureTextBox.ToolTip = "Incorrect value";
                ManufactureTextBox.Background = Brushes.Red;
            }
            else if(model == "")
            {
                ModelTextBox.ToolTip = "Incorrect value";
                ModelTextBox.Background = Brushes.Red;
            }
            else if(imageLink == "")
            {
                ImageLinkTextBox.ToolTip = "Incorrect value";
                ImageLinkTextBox.Background = Brushes.Red;
            }
            else if(price <= 0)
            {
                PriceTextBox.ToolTip = "Incorrect value";
                PriceTextBox.Background = Brushes.Red;
            }
            else
            {
                ManufactureTextBox.ToolTip = "";
                ManufactureTextBox.Background = Brushes.Transparent;
                ModelTextBox.ToolTip = "";
                ModelTextBox.Background = Brushes.Transparent;
                ImageLinkTextBox.ToolTip = "";
                ImageLinkTextBox.Background = Brushes.Transparent;
                PriceTextBox.ToolTip = "";
                PriceTextBox.Background = Brushes.Transparent;

                PhoneViewModel phone = new PhoneViewModel
                {
                    Id = _phones.Last().Id + 1,
                    Manufacturer = manufacturer,
                    Model = model,
                    ImageLink = imageLink,
                    Price = price,
                };

                _phones.Add(phone);

                await Send(phone);

                _mainList.ItemsSource = _phones;
                this.Hide();
            }
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            ManufactureTextBox.Clear();
            ManufactureTextBox.Background = Brushes.Transparent;
            ModelTextBox.Clear();
            ModelTextBox.Background = Brushes.Transparent;
            ImageLinkTextBox.Clear();
            ImageLinkTextBox.Background = Brushes.Transparent;
            PriceTextBox.Clear();
            PriceTextBox.Background = Brushes.Transparent;
        }

        private async Task Send(PhoneViewModel phone)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7041");
                var json = JsonConvert.SerializeObject(phone, Formatting.Indented);
                var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/phone", requestContent);
                var result = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
