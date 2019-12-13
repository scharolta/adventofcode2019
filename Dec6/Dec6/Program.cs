﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec6
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines(@"C:\Users\ssk\source\repos\Dec\Dec6\input6.txt");
            List<Node> allNodes = ConstructNodes(allLines);

            Part1(allNodes);
            Part2(allNodes);
        }

        private static void Part2(List<Node> allNodes)
        {
            var nodeYou = allNodes.Single(n => n.Id == "YOU");
            var nodeSan = allNodes.Single(n => n.Id == "SAN");
            var youOrbits = GetAllNodesOrbittedBy(nodeYou, allNodes);
            var sanOrbits = GetAllNodesOrbittedBy(nodeSan, allNodes);

            var crossPoint = youOrbits.First(n => sanOrbits.Contains(n));
            Console.WriteLine(youOrbits.IndexOf(crossPoint) + sanOrbits.IndexOf(crossPoint));
        }

        private static List<Node> GetAllNodesOrbittedBy(Node nodeYou, List<Node> allNodes)
        {
            var currentNode = nodeYou;
            var nodesOrbitted = new List<Node>();
            while (true)
            {
                var nodeOrbitted = allNodes.FirstOrDefault(n => n.OrbittedBy.Contains(currentNode));
                if (nodeOrbitted == null) break;
                else
                {
                    nodesOrbitted.Add(nodeOrbitted);
                    currentNode = nodeOrbitted;
                }
            }

            return nodesOrbitted;
        }

        private static void Part1(List<Node> allNodes)
        {
            var totalSum = 0;
            foreach (var node in allNodes)
            {
                var partSum = 0;
                var currentNode = node;
                while (true)
                {
                    var nodeOrbitted = allNodes.FirstOrDefault(n => n.OrbittedBy.Contains(currentNode));
                    if (nodeOrbitted == null) break;
                    else
                    {
                        partSum++;
                        currentNode = nodeOrbitted;
                    }
                }
                totalSum += partSum;
            }
            Console.WriteLine(totalSum);
        }

        private static List<Node> ConstructNodes(string[] allLines)
        {
            var allNodes = new List<Node>();
            foreach (var item in allLines)
            {
                var split = item.Split(')');
                Node findNode1 = CheckNodeExists(allNodes, split[0]);
                Node findNode2 = CheckNodeExists(allNodes, split[1]);
                findNode1.OrbittedBy.Add(findNode2);
            }

            return allNodes;
        }

        private static Node CheckNodeExists(List<Node> allNodes, string id)
        {
            var findNode2 = allNodes.SingleOrDefault(n => n.Id == id);
            if (findNode2 == null)
            {
                findNode2 = new Node(id);
                allNodes.Add(findNode2);
            }

            return findNode2;
        }
    }

    class Node
    {
        public Node(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public List<Node> OrbittedBy { get; set; } = new List<Node>();
    }
}
