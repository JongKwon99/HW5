using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject normalBullet;
    public GameObject shootPoint;

    private void Start()
    {
        Instantiate(normalBullet, transform.position, transform.rotation);
    }
}
