using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class TimelineSetter : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject enemies;
    public PlayerInput pi;

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        pi = GetComponent<PlayerInput>();

        // PlayableDirector ���� �� �̺�Ʈ ����
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineEnd;
        }
    }

    void OnTimelineEnd(PlayableDirector director)
    {
        // TimeScale�� 1�� ����
        Time.timeScale = 1.0f;
        // �� Ȱ��ȭ
        enemies.SetActive(true);
        pi.enabled = true;
    }

    void OnDestroy()
    {
        // �̺�Ʈ ���� (�����ϰ� �޸� ����)
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnTimelineEnd;
        }
    }
}
