using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f;

    private void Update()
    {
        // Time.timeScale이 0일 때는 FPS 계산 중지
        if (Time.timeScale == 0)
            return;

        // 프레임 시간 계산
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        // Time.timeScale이 0일 때는 FPS 표시 중지
        if (Time.timeScale == 0)
            return;

        int width = Screen.width;
        int height = Screen.height;

        // 스타일 설정
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, width, height * 0.05f); // 화면 상단
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = height / 30; // 화면 크기에 비례하는 폰트 크기
        style.normal.textColor = Color.white;

        // FPS 계산 및 표시
        float fps = 1.0f / deltaTime;
        string text = $"FPS: {Mathf.RoundToInt(fps)}";
        GUI.Label(rect, text, style);
    }
}
