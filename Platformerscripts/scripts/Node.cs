using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONNECT : MonoBehaviour
{

    [HideInInspector]
    public List<CONNECT> neighbours = new List<CONNECT>();

    private void Awake()
    {
        FindNeighbours();
    }

    public void FindNeighbours()
    {
        neighbours = new List<CONNECT>();

        foreach (CONNECT n in GameObject.FindObjectsOfType<CONNECT>())
        {
            Ray ray = new Ray(transform.position, n.transform.position - transform.position);
            RaycastHit hit;
            if(Physics.Raycast (ray,out hit))
            {
                if (hit.transform == n.transform)
                {
                    neighbours.Add(n);
                    Debug.DrawLine(transform.position, n.transform.position, Color.yellow, 2);
                }
                else
                {
                    continue;
                }
            }
        }
    }

   

}
