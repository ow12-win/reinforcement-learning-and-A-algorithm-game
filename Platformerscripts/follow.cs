using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject enemy;
    [SerializeField] public float speed;
    void Update()
    {
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed);
    }
}
