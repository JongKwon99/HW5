using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // InGame ������ �̵�
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    // ���α׷� ����
    public void QuitGame()
    {
        print("���α׷� ����");
        //Application.Quit();
    }
}
