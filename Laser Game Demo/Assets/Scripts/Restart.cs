using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //This will be called when the Restart button is pressed, which is a UnityEvent that we set up in the editor
    public void ResetScene()
    {
        //Reload the scene
        SceneManager.LoadScene("SampleScene");
    }
}
