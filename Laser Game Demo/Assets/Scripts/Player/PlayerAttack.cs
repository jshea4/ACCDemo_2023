using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private LineRenderer laserLine; 

    // Start is called before the first frame update
    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    //This will be called when the user clicks, based on how we set up the "Fire" InputAction
    private void OnFire()
    {
        laserLine.enabled = true;
        
        //LineRenderers maintain an array of positions, and draw a line between each position.
        //Here, we set the first position in the array to the position of the player
        laserLine.SetPosition(0, transform.position);

        //Create a new ray, starting at the player's position, and going the direction the player is looking
        Ray ray = new Ray(transform.position, transform.forward);
        
        //If the ray hits anything, Physics.Raycast will return true, and we'll go into the if statement
        //The data from the raycast will be stored in the hitData variable
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 100))
        {
            laserLine.SetPosition(1, hitData.point); //set the second position in the array to the point that the ray hit

            //Attempt to get the EnemyHealth component from the object that the ray hit
            EnemyHealth enemy = hitData.transform.GetComponent<EnemyHealth>();
            if (enemy)
            {
                enemy.TakeDamage(10);
            }
        }
        else 
        {
            //If the ray didn't hit anything, set the second position of the linerenderer to be 100 units forward, 
            // in the direction of the ray
            laserLine.SetPosition(1, ray.origin + ray.direction * 100);
        }

        //start a coroutine that will disable the linerenderer in 0.03 seconds
        StartCoroutine(DelayDisable());
    }

    IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(0.03f);
        laserLine.enabled = false;
    }
}
