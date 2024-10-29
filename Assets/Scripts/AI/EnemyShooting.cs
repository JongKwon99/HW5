using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject normalBullet;
    public GameObject shootPoint;
    public GameObject ai;

    private void Start()
    {

    }

    private void Update()
    {
        if (ai.GetComponent<Sight>().currentDetecting != null )
        {
            Instantiate(normalBullet, transform.position, transform.rotation);
        }
    }
}
