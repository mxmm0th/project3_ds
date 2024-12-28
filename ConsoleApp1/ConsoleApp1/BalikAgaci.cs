using System;
using System.Collections.Generic;

public class BalikAgaci
{
    private class Node
    {
        public EgeDeniziB Balik;
        public Node Sol;
        public Node Sag;

        public Node(EgeDeniziB balik)
        {
            Balik = balik;
        }
    }

    private Node root;

    public void Ekle(EgeDeniziB balik)
    {
        root = EkleRec(root, balik);
    }

    private Node EkleRec(Node root, EgeDeniziB balik)
    {
        if (root == null)
            return new Node(balik);

        if (string.Compare(balik.BalikAdi, root.Balik.BalikAdi) < 0)
            root.Sol = EkleRec(root.Sol, balik);
        else if (string.Compare(balik.BalikAdi, root.Balik.BalikAdi) > 0)
            root.Sag = EkleRec(root.Sag, balik);

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
            Console.WriteLine($"Balık Adı: {root.Balik.BalikAdi}");
            InOrderListeleRec(root.Sag);
        }
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

    //balk isimlerini ceken method getter


      public List<EgeDeniziB> GetBalikObjeleri()
    {
        List<EgeDeniziB> balikObjeleri = new List<EgeDeniziB>();
        InOrderTraversal(root, balikObjeleri);
        return balikObjeleri;
    }

    public Dictionary<string, string> CreateBalikDictionary()
    {
        Dictionary<string, string> balikDictionary = new Dictionary<string, string>();
        InOrderTraversal(root, balikDictionary);
        return balikDictionary;
    }

    private void InOrderTraversal(Node node, List<EgeDeniziB> balikObjeleri)
    {
        if (node == null) return;

        InOrderTraversal(node.Sol, balikObjeleri);
        balikObjeleri.Add(node.Balik);
        InOrderTraversal(node.Sag, balikObjeleri);
    }

    private void InOrderTraversal(Node node, Dictionary<string, string> balikDictionary)
    {
        if (node == null) return;

        InOrderTraversal(node.Sol, balikDictionary);
        balikDictionary[node.Balik.BalikAdi] = node.Balik.Bilgi;
        InOrderTraversal(node.Sag, balikDictionary);
    }
}
