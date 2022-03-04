namespace ShortestPaths_1
{
    internal class Link
    {
        //Network: The Network object that contains the link
        //FromNode, ToNode: The Node objects that this link connects
        //Cost: The cost of crossing this link
        public Network Network { get; set; }
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }
        public int Cost { get; set; }

        public Link(Network network, Node fromNode, Node toNode, int cost)
        {
            Network = network;
            FromNode = fromNode;
            ToNode = toNode;
            Cost = cost;

            Network.AddLink(this);
            FromNode.AddLink(this);
        }

        public override string ToString()
        {
            return $"[{FromNode.Text}] --> [{ToNode.Text}] ({Cost})";
        }
    }

}