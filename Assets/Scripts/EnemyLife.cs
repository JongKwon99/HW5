using UnityEngine;
using UnityEngine.Events;

public class EnemyLife : MonoBehaviour
{
    public int amount;
    public UnityEvent onDeath;  // 체력이 0 이하일 때 호출되는 이벤트

    public void TakeDamage(int damage)
    {
        amount -= damage;
        if (amount <= 0)
        {
            amount = 0;
            onDeath?.Invoke(); // 체력이 0이 되면 이벤트 호출
            Destroy(gameObject);
        }
    }
}
