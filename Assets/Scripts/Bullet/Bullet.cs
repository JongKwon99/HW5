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

    // 무언가와 부딪히면 나 자신을 파괴
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
