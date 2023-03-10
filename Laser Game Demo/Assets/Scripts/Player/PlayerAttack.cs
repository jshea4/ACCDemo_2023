using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private LineRenderer laserLine; 

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void OnFire()
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);

        Ray ray = new Ray(transform.position, transform.forward);//position, direction
        if (Physics.Raycast(ray, out RaycastHit hitData, 100))
        {
            laserLine.SetPosition(1, hitData.point);
            EnemyHealth enemy = hitData.transform.GetComponent<EnemyHealth>();
            if (enemy)
                enemy.TakeDamage(10);
        }
        else 
        {
            laserLine.SetPosition(1, ray.origin + ray.direction * 100);
        }
        StartCoroutine(DelayDisable(0.1f));
    }

    IEnumerator DelayDisable(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        laserLine.enabled = false;
    }
}
