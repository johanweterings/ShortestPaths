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

namespace ShortestPaths_1
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


        private void TestA_Click(object sender, RoutedEventArgs e)
        {
            var network = new Network();

            var aNode = new Node(network, new Point(20, 20), "A");
            var bNode = new Node(network, new Point(120, 120), "B");

            new Link(network, aNode, bNode, 10);

            ValidateNetwork(network, "network_a.net");
        }

        private void TestB_Click(object sender, RoutedEventArgs e)
        {
            var network = new Network();

            var aNode = new Node(network, new Point(20, 20), "A");
            var bNode = new Node(network, new Point(120, 20), "B");
            var cNode = new Node(network, new Point(20, 120), "C");
            var dNode = new Node(network, new Point(120, 120), "D");

            new Link(network, aNode, bNode, 10);
            new Link(network, bNode, dNode, 15);
            new Link(network, aNode, cNode, 20);
            new Link(network, cNode, dNode, 25);

            ValidateNetwork(network, "network_b.net");

        }

        private void TestC_Click(object sender, RoutedEventArgs e)
        {
            var network = new Network();

            var aNode = new Node(network, new Point(20, 20), "A");
            var bNode = new Node(network, new Point(120, 20), "B");
            var cNode = new Node(network, new Point(20, 120), "C");
            var dNode = new Node(network, new Point(120, 120), "D");

            new Link(network, aNode, bNode, 10);
            new Link(network, bNode, dNode, 15);
            new Link(network, aNode, cNode, 20);
            new Link(network, cNode, dNode, 25);

            new Link(network, bNode, aNode, 11);
            new Link(network, dNode, bNode, 16);
            new Link(network, cNode, aNode, 21);
            new Link(network, dNode, cNode, 26);


            ValidateNetwork(network, "network_c.net");

        }

        private void ValidateNetwork(Network network, string filename)
        {
            var data = network.Serialization();
            network.SaveIntoFile(filename);
            network.LoadFromFile(filename);
            var newData = network.Serialization();
            netTextBox.Text = newData;

            statusLabel.Content = "OK";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != newData[i])
                {
                    statusLabel.Content = $"Serializations do not match at position {i}";
                    break;
                }
            }            
        }

    }
}
