using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    // ���𰡿� �ε����� �� �ڽ��� �ı�
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
