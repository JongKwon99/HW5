using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public GameObject player;
    public GameObject enemy;

    private int _killStack; // 내부 변수

    // 외부에서 kill_stack에 접근할 수 있는 속성
    public int kill_stack
    {
        get => _killStack;
        set
        {
            _killStack = value;

            // kill_stack이 3 이상이 되면 Win 씬 로드
            if (_killStack >= 3)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }

    PlayerLife playerLife;
    EnemyLife enemyLife;

    private void Start()
    {
        kill_stack = 0; // 속성을 통해 초기화
        playerLife = player.GetComponent<PlayerLife>();
        //enemyLife = enemy.GetComponent<EnemyLife>();

        // 체력이 0 이하로 떨어졌을 때 이벤트를 호출하도록 구독
        playerLife.onDeath.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        SceneManager.LoadScene("Lose");
    }
}
