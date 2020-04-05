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
using Nancy;
using Nancy.Hosting.Self;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Net;


namespace Checkpoint_3_API
{
    public partial class MainWindow : Window
    {
        public string url = "http://localhost:1234/";


        public MainWindow()
        {
            InitializeComponent();

        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowTxtBlock.Text = String.Empty;
            string filePath = FilePathTxtBox.Text;
            
            using (var client = new WebClient())
            {
                string fileJson = client.DownloadString(url + "file/get/" + filePath);
                ShowTxtBlock.Text = fileJson;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowTxtBlock.Text = String.Empty;
            string filePath = FilePathTxtBox.Text;

            using (var client = new WebClient())
            {
                string fileJson = client.DownloadString(url + "file/delete/" + filePath);
                ShowTxtBlock.Text = fileJson;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowTxtBlock.Text = String.Empty;
            string filePath = FilePathTxtBox.Text;

            using (var client = new WebClient())
            {
                string fileJson = client.DownloadString(url + "file/put/" + filePath);
                ShowTxtBlock.Text = fileJson;
            }
        }
    }
}
