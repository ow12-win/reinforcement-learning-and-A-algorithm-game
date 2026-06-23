using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    public static AStarManager instance;

    private void Awake()
    {
        instance = this;

    }

    public List<Node> GeneratePath(Node start, Node end)
    {
        List<Node> openSet = new List<Node>();
        List<Node> allNodes = new List<Node>(FindObjectsOfType<Node>());
        List<Node> previousNodes = new List<Node>(new Node[allNodes.Count]); 

        
        foreach (Node n in allNodes)
        {
            n.gScore = float.MaxValue;
        }

        start.gScore = 0;
        start.hScore = Vector2.Distance(start.transform.position, end.transform.position);
        openSet.Add(start);

        while (openSet.Count > 0)
        {
            int lowestF = default;

            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FScore() < openSet[lowestF].FScore())
                {
                    lowestF=i;
                }
            }

            Node currentNode = openSet[lowestF];
            openSet.Remove(currentNode);

            if (currentNode == end)
            {
                List<Node> path = new List<Node>();

                path.Add(end);

                Node currentPathNode = currentNode;


                while (previousNodes[allNodes.IndexOf(currentPathNode)] != null)
                {
                    currentPathNode = previousNodes[allNodes.IndexOf(currentPathNode)];
                    path.Add(currentPathNode);
                }

                
                return path;
            }

            foreach (Node connectedNode in currentNode.connections)
            {
                float tentativeGScore = currentNode.gScore + Vector2.Distance(currentNode.transform.position, connectedNode.transform.position);

                if (tentativeGScore < connectedNode.gScore)
                {
                    connectedNode.gScore = tentativeGScore;
                    connectedNode.hScore = Vector2.Distance(connectedNode.transform.position, end.transform.position);

                    previousNodes[allNodes.IndexOf(connectedNode)] = currentNode;

                    if (!openSet.Contains(connectedNode))
                    {
                        openSet.Add(connectedNode);
                    }
                }
            }
        }
        return null;
    }


   
    public Node NearestNode(Vector2 position)
    {
        Node foundnode = null;
        float maxDistance = float.MaxValue;

        foreach (Node node in NodesInScence())
        {
            float currentDistance = Vector2.Distance(position, node.transform.position);
            if (currentDistance <maxDistance)
            {
                maxDistance = currentDistance;
                foundnode = node;
            }
        }

        return foundnode;
    }
    public Node FindFurthestNode(Vector2 position)

    {
        Node foundnode = null;
        float maxDistance = 0;

        foreach (Node node in NodesInScence())
        {
            float currentDistance = Vector2.Distance(position, node.transform.position);
            if (currentDistance > maxDistance)
            {
                maxDistance = currentDistance;
                foundnode = node;
            }
        }
        return foundnode;
    }
    public Node[] NodesInScence()
    {
        return FindObjectsOfType<Node>();
    }

    

}
