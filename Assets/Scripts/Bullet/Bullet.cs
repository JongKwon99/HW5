using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // ���𰡿� �ε����� �� �ڽ��� �ı�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
