using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    // InGame 씬으로 이동
    public void LoadInGameScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }

    // 프로그램 종료
    public void QuitGame()
    {
        print("프로그램 종료");
        //Application.Quit();
    }
}
