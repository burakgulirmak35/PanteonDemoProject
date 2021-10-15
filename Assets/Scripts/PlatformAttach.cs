using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    [SerializeField]
    Vector3 rotationVector;

    private void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        col.transform.parent = transform;
    }

    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
