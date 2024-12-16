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
            // ���� ü���� ���ҽ�Ű�� �ʰ� TakeDamage ȣ��
            plife.TakeDamage(damage);
            gameObject.SetActive(false);
        }
        // �Ѿ��� ���
        if (elife != null)
        {
            // ���� ü���� ���ҽ�Ű�� �ʰ� TakeDamage ȣ��
            elife.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
