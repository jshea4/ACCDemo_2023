using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //If we had a moving camera, this guarantees that all camera movement on that frame is completed before we rotate the UI
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
