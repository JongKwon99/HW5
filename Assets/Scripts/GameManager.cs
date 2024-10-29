using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;
    public Life playerLife;

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
        
    }

    private void Update()
    {
        
    }

    private void Win()
    {
        SceneManager.LoadScene("Win");
    }

    private void Lose()
    {
        print("nooo!!");
        SceneManager.LoadScene("Lose");
    }
}
