using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemiesDestroyed = 0;   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        if (enemiesDestroyed >= 10)     // 10������ ���� �ı��ϸ� �¸�
        {
            Win();
        }
    }

    public void CheckLife(Life playerLife)
    {
        if (playerLife.amount <= 0)     // ü���� 0 ���ϰ� �Ǹ� �й�
        {
            Lose();
        }
    }

    private void Win()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("Win");
    }

    private void Lose()
    {
        Debug.Log("You Lose!");
        SceneManager.LoadScene("Lose");
    }
}
