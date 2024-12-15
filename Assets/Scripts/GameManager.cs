using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public GameObject enemy;
    public GameObject playerBase;

    Life playerLife;
    Life enemyLife;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        playerLife = player.GetComponent<Life>();
        enemyLife = player.GetComponent<Life>();
    }

    private void Update()
    {
        if (playerLife.amount <= 0)
            SceneManager.LoadScene("Lose");
        else if (enemyLife.amount <= 0)
            SceneManager.LoadScene("Win");
    }
}
