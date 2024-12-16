using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    public GameObject player;
    public GameObject enemy;

    private int _killStack; // ���� ����

    // �ܺο��� kill_stack�� ������ �� �ִ� �Ӽ�
    public int kill_stack
    {
        get => _killStack;
        set
        {
            _killStack = value;

            // kill_stack�� 3 �̻��� �Ǹ� Win �� �ε�
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
        kill_stack = 0; // �Ӽ��� ���� �ʱ�ȭ
        playerLife = player.GetComponent<PlayerLife>();
        //enemyLife = enemy.GetComponent<EnemyLife>();

        // ü���� 0 ���Ϸ� �������� �� �̺�Ʈ�� ȣ���ϵ��� ����
        playerLife.onDeath.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        SceneManager.LoadScene("Lose");
    }
}
