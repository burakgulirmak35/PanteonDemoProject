using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform2 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, -0.3f);
    }
}
