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
            txtblockDescription.Text = "* The HelloWindoesService Is Running in the Windows Service So that we could able send the request to the service and get back the reponse from the server..";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelloService.HelloServiceClient helloServiceClient = new HelloService.HelloServiceClient("NetTcpBinding_IHelloService");            
            //lblname.Content = helloServiceClient.GetMessage(txtName.Text);
            MessageBox.Show(helloServiceClient.GetMessage(txtName.Text), "Message From Server",MessageBoxButton.OK,MessageBoxImage.Information);
        }       

        private void btnAgeCalculate_Click(object sender, RoutedEventArgs e)
        {
            if(txtday !=null && txtMonth !=null && txtYear !=null && txtday.Text.Length > 0 && txtMonth.Text.Length > 0 && txtYear.Text.Length > 0)
            {
                int day, Month, Year, TotalDays;
                HelloService.HelloServiceClient helloServiceClient = new HelloService.HelloServiceClient("NetTcpBinding_IHelloService");//creating the object of WCF service client  

                day = int.Parse(txtday.Text);
                Month = int.Parse(txtMonth.Text);
                Year = int.Parse(txtYear.Text);

                TotalDays = helloServiceClient.calculateDays(day, Month, Year); //assigning the output value from service Response  

                MessageBox.Show("You are Currently " + Convert.ToString(TotalDays) + " days old", "Response From the Server", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("PLease Enter all the Fields", "Alerts..", MessageBoxButton.OK, MessageBoxImage.Warning);
                //FieldsFocus();
            }
          
        }

        private void FieldsFocus()
        {
            //if(txtday.Text !=null)
            //{ 
            //    txtday.Focus();
            //    txtday.BorderBrush = Brushes.Red;
            //}
            //else if(txtMonth.Text == null)
            //{
            //    txtMonth.Focus();
            //}
            //else if(txtYear.Text == null)
            //{
            //    txtYear.Focus();
            //}
            //else
            //{

            //}
        }
    }
}
