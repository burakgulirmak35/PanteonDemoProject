using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Obstacle")
        {
            Player.transform.position = respawnPoint.transform.position;
        }
    }
}
