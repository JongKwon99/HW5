using UnityEngine;
using UnityEngine.Events;

public class EnemyLife : MonoBehaviour
{
    public int amount;
    public UnityEvent onDeath;  // ü���� 0 ������ �� ȣ��Ǵ� �̺�Ʈ

    public void TakeDamage(int damage)
    {
        amount -= damage;
        if (amount <= 0)
        {
            amount = 0;
            onDeath?.Invoke(); // ü���� 0�� �Ǹ� �̺�Ʈ ȣ��
            Destroy(gameObject);
        }
    }
}
