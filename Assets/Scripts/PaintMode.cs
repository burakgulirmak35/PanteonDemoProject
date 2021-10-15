using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMode : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    public GameObject Player;
    public GameObject wall;
    private Component Change;

    void start()
    {

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            wall.GetComponent<Paintable>().enabled = true;
            Player.GetComponent<Controller>().enabled = false;
        }
    }

}
