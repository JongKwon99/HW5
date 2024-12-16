using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTest : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;

        if (direction.magnitude > 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = lookRotation;
        }
    }
}
