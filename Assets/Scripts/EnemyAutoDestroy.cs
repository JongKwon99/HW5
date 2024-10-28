using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoDestroy : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 무언가와 부딪히면 나 자신을 파괴
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            Destroy(gameObject);
    }
}
