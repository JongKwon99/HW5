using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    public int enemiesCount;
    public int playerLife;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        playerLife = player.GetComponent<Life>().amount;
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
