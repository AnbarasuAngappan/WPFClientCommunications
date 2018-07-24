using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WPFClientCommunications
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelloService.HelloServiceClient helloServiceClient = new HelloService.HelloServiceClient("NetTcpBinding_IHelloService");            
            //lblname.Content = helloServiceClient.GetMessage(txtName.Text);
            MessageBox.Show(helloServiceClient.GetMessage(txtName.Text), "Message From Server",MessageBoxButton.OK,MessageBoxImage.Information);
        }       

        private void btnAgeCalculate_Click(object sender, RoutedEventArgs e)
        {
            int day, Month, Year, TotalDays;             
            HelloService.HelloServiceClient helloServiceClient = new HelloService.HelloServiceClient("NetTcpBinding_IHelloService");//creating the object of WCF service client  
            
            day = int.Parse(txtday.Text);
            Month = int.Parse(txtMonth.Text);
            Year = int.Parse(txtYear.Text);
           
            TotalDays = helloServiceClient.calculateDays(day, Month, Year); //assigning the output value from service Response  
           
            MessageBox.Show("You are Currently " + Convert.ToString(TotalDays) + " days old","Response From the Server",MessageBoxButton.OK,MessageBoxImage.Information);            
        }
    }
}
