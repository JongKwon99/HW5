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

    // 무언가와 부딪히면 나 자신을 파괴
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
