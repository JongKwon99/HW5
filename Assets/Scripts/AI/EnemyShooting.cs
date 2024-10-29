using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject normalBullet;
    public GameObject shootPoint;

    private void Start()
    {

    }

    public void Shoot()
    {
        Instantiate(normalBullet, shootPoint.transform.position, shootPoint.transform.rotation);
    }
}
