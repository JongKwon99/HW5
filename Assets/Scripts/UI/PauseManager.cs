using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public PlayerInput pi;
    public GameObject pausePanel;
    private bool isPaused = false;
    public AudioSource soundManagerAudio;

    // OnPause() 메서드 수정 - InputValue와 연결
    public void OnPause(InputValue value)
    {
        // `InputValue`를 통해 눌린 키가 "Pause"일 때만 처리
        if (value.isPressed)  // 키가 눌렸을 때만 토글
        {
            if (isPaused)
            {
                ResumeGame();  // 이미 일시정지 상태라면 재개
            }
            else
            {
                PauseGame();   // 일시정지 상태가 아니라면 일시정지
            }
        }
    }

    // 게임을 일시정지하는 메서드
    private void PauseGame()
    {
        pi.SwitchCurrentActionMap("UI");
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (soundManagerAudio != null)
            soundManagerAudio.Pause();
    }

    // 게임을 재개하는 메서드
    public void ResumeGame()
    {
        pi.SwitchCurrentActionMap("Player");
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (soundManagerAudio != null)
            soundManagerAudio.UnPause();
    }

    // Quit 버튼 클릭 시 타이틀로 돌아가기
    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
    }
}
