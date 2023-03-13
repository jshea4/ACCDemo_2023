using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Using LateUpdate guarantees that the UI updates after the camera.
    //Not really needed here, but would in theory create a better result if we had a moving camera.
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
