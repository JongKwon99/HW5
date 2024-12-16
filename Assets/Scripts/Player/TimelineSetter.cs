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

        // PlayableDirector 종료 시 이벤트 연결
        if (playableDirector != null)
        {
            playableDirector.stopped += OnTimelineEnd;
        }
    }

    void OnTimelineEnd(PlayableDirector director)
    {
        // TimeScale을 1로 리셋
        Time.timeScale = 1.0f;
        // 적 활성화
        enemies.SetActive(true);
        pi.enabled = true;
    }

    void OnDestroy()
    {
        // 이벤트 해제 (안전하게 메모리 관리)
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnTimelineEnd;
        }
    }
}
