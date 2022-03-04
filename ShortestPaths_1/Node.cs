using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShortestPaths_1
{
    internal class Node
    {

        //Index - The node’s index in the network
        //Network - The Network object that contains the node
        //Center - A Point that represents the coordinates of the node’s center
        //Text - The node’s displayed value
        //Links - A list of Link objects leaving this node

        public int Index { get; set; }
        public Network Network { get; set; }
        public Point Center { get; set; }
        public string Text { get; set; } = string.Empty;
        public ICollection<Link> Links { get; private set; }

        public Node(Network network, Point center, string text)
        {
            Network = network;
            Center = center;
            Text = text;
            Links = new List<Link>();
            Index = -1;
            Network.AddNode(this);
        }

        public override string ToString()
        {
            return $"[{Text}]";
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }

    }
}
