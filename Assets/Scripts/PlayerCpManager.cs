using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCpManager : MonoBehaviour
{
    public int PlayerNumber;
    public int cpCrossed = 0;
    public int PlayerPosition;

    public Placement Placement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CP"))
        {
            cpCrossed += 1;
            Placement.PlayerCollectedCp(PlayerNumber, cpCrossed);
        }
    }

}
