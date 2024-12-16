using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public GameObject player;
    public GameObject enemy;
    public int kill_stack;

    PlayerLife playerLife;
    EnemyLife enemyLife;

    private void Start()
    {
        kill_stack = 0;
        playerLife = player.GetComponent<PlayerLife>();
        enemyLife = enemy.GetComponent<EnemyLife>();

        // ü���� 0 ���Ϸ� �������� �� �̺�Ʈ�� ȣ���ϵ��� ����
        playerLife.onDeath.AddListener(OnPlayerDeath);
        //enemyLife.onDeath.AddListener(OnEnemyDeath);
    }

    private void OnPlayerDeath()
    {
        SceneManager.LoadScene("Lose");
    }

    private void OnEnemyDeath()
    {
        kill_stack++;  // óġ�� �� �� ����
        if (kill_stack >= 3)
            SceneManager.LoadScene("Win");
    }
}
