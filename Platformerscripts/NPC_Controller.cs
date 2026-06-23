using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{

   

    public Node currentNode;
    public List<Node> path;

    public PlayerMovement player;
    private float speed = 3;

    private void Start()
    {
    }
    private void Update()
    {
        if (path.Count == 0)
        {
            path = AStarManager.instance.GeneratePath(currentNode, AStarManager.instance.NearestNode(player.transform.position));
        }
        CreatePath();
    }

    void CreatePath()
    {
        if (path.Count > 0)
        {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[x].transform.position.x, path[x].transform.position.y, -2), speed = Time.deltaTime*1.5f);

            if(Vector2.Distance(transform.position, path[x].transform.position) < 0.7f)
            {
                currentNode = path[x];
                path.RemoveAt(x);
            }
        }

    }

   



}
