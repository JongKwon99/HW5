using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public PlayerInput pi;
    public GameObject pausePanel;
    private bool isPaused = false;
    public AudioSource soundManagerAudio;

    // OnPause() �޼��� ���� - InputValue�� ����
    public void OnPause(InputValue value)
    {
        // `InputValue`�� ���� ���� Ű�� "Pause"�� ���� ó��
        if (value.isPressed)  // Ű�� ������ ���� ���
        {
            if (isPaused)
            {
                ResumeGame();  // �̹� �Ͻ����� ���¶�� �簳
            }
            else
            {
                PauseGame();   // �Ͻ����� ���°� �ƴ϶�� �Ͻ�����
            }
        }
    }

    // ������ �Ͻ������ϴ� �޼���
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

    // ������ �簳�ϴ� �޼���
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

    // Quit ��ư Ŭ�� �� Ÿ��Ʋ�� ���ư���
    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
    }
}
