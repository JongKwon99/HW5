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
        if (enemiesDestroyed >= 10)     // 10마리의 적을 파괴하면 승리
        {
            Win();
        }
    }

    public void CheckLife(Life playerLife)
    {
        if (playerLife.amount <= 0)     // 체력이 0 이하가 되면 패배
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
