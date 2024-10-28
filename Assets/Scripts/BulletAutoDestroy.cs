using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAutoDestroy : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }

    // ���𰡿� �ε����� �� �ڽ��� �ı�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
