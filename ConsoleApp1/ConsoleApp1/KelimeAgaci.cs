public class KelimeAgaci
{
    private class Node
    {
        public string Kelime;
        public Node Sol;
        public Node Sag;

        public Node(string kelime)
        {
            Kelime = kelime;
        }
    }

    private Node root;

    public void Ekle(string kelime)
    {
        root = EkleRec(root, kelime);
    }

    private Node EkleRec(Node root, string kelime)
    {

        
        if (root == null)
            return new Node(kelime);
        if (string.Compare(kelime, root.Kelime) < 0)
            root.Sol = EkleRec(root.Sol, kelime);
        else if (string.Compare(kelime, root.Kelime) > 0)
            root.Sag = EkleRec(root.Sag, kelime);
        return root;
    }
        public void InOrderListele()
    {
        InOrderListeleRec(root);
    }

        private void InOrderListeleRec(Node root)
    {
        if (root != null)
        {
            InOrderListeleRec(root.Sol);
            Console.Write($"{root.Kelime}" + " ");
            InOrderListeleRec(root.Sag);
        }

        
    }

            public int GetDepth()
        {
            return GetDepthRec(root);
        }

        private int GetDepthRec(Node node)
        {
            if (node == null)
                return 0;

            int leftDepth = GetDepthRec(node.Sol);
            int rightDepth = GetDepthRec(node.Sag);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        
        public int GetNodeCount()
        {
            return GetNodeCountRec(root);
        }

        private int GetNodeCountRec(Node node)
        {
            if (node == null)
                return 0;

            int leftCount = GetNodeCountRec(node.Sol);
            int rightCount = GetNodeCountRec(node.Sag);

            return leftCount + rightCount + 1;
        }



        public int GetBalancedDepth()
        {
            return GetBalancedDepthRec(GetNodeCount());
        }

        private int GetBalancedDepthRec(int nodeCount)
        {
            return (int)Math.Ceiling(Math.Log(nodeCount + 1, 2));
        }

}


