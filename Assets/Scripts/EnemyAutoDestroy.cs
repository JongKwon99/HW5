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
        // ���𰡿� �ε����� �� �ڽ��� �ı�
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            Destroy(gameObject);
    }
}
