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

        // 체력이 0 이하로 떨어졌을 때 이벤트를 호출하도록 구독
        playerLife.onDeath.AddListener(OnPlayerDeath);
        //enemyLife.onDeath.AddListener(OnEnemyDeath);
    }

    private void OnPlayerDeath()
    {
        SceneManager.LoadScene("Lose");
    }

    private void OnEnemyDeath()
    {
        kill_stack++;  // 처치한 적 수 증가
        if (kill_stack >= 3)
            SceneManager.LoadScene("Win");
    }
}
