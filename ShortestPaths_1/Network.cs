using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShortestPaths_1
{
    internal class Network
    {
        public ICollection<Node> Nodes { get; set; }
        public ICollection<Link> Links { get; set; }

        public Network()
        {
            Clear();
        }

        private void Clear()
        {
            Nodes = new List<Node>();
            Links = new List<Link>();
        }

        internal void AddNode(Node node)
        {
            node.Index = Nodes.Count;
            Nodes.Add(node);
        }

        internal void AddLink(Link link)
        {
            Links.Add(link);
        }

        public string Serialization()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Nodes.Count} # Number of nodes");
            sb.AppendLine($"{Links.Count} # Number of links");
            sb.AppendLine($"# Nodes");
            foreach (var node in Nodes)
            {
                sb.AppendLine($"{node.Center.X},{node.Center.Y},{node.Text}");
            }
            sb.AppendLine($"# Links");
            foreach (var link in Links)
            {
                sb.AppendLine($"{link.FromNode.Index},{link.ToNode.Index},{link.Cost}");
            }

            return sb.ToString();
        }

        public void SaveIntoFile(string filename)
        {
            File.WriteAllText(filename, Serialization());
        }

        public string ReadNextLine(StringReader reader)
        {
            string line;

            do
            {
                line = reader.ReadLine();
                if (line == null) return null;

                var pos = line.IndexOf('#');
                if (pos > -1)
                {
                    line = line.Substring(0, pos);
                }

                line.Trim();

            } while (string.IsNullOrWhiteSpace(line));

            return line;
        }

        public void Deserialize(string data)
        {
            Clear();
            using (var r = new StringReader(data))
            {
                var numberOfNodes = int.Parse(ReadNextLine(r));
                var numberOfLinks = int.Parse(ReadNextLine(r));
                
                for (int i = 0; i < numberOfNodes; i++)
                {
                    var text = ReadNextLine(r);
                    var values = text.Split(',');
                    new Node(this, new System.Windows.Point(int.Parse(values[0]), int.Parse(values[1])), values[2]);
                }

                for (int i = 0; i < numberOfLinks; i++)
                {
                    var text = ReadNextLine(r);
                    var values = text.Split(',');
                    var fromNode = Nodes.FirstOrDefault(n => n.Index == int.Parse(values[0]));
                    var toNode = Nodes.FirstOrDefault(n => n.Index == int.Parse(values[1]));
                    new Link(this, fromNode, toNode, int.Parse(values[2]));
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            Deserialize(File.ReadAllText(filename));
        }


    }
}