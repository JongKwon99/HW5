using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        PlayerLife plife = other.GetComponent<PlayerLife>();
        EnemyLife elife = other.GetComponent<EnemyLife>();

        if (plife != null)
        {
            // 직접 체력을 감소시키지 않고 TakeDamage 호출
            plife.TakeDamage(damage);
            gameObject.SetActive(false);
        }
        // 총알의 경우
        if (elife != null)
        {
            // 직접 체력을 감소시키지 않고 TakeDamage 호출
            elife.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
