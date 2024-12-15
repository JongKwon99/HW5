using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f;

    private void Update()
    {
        // Time.timeScale�� 0�� ���� FPS ��� ����
        if (Time.timeScale == 0)
            return;

        // ������ �ð� ���
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        // Time.timeScale�� 0�� ���� FPS ǥ�� ����
        if (Time.timeScale == 0)
            return;

        int width = Screen.width;
        int height = Screen.height;

        // ��Ÿ�� ����
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0, width, height * 0.05f); // ȭ�� ���
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = height / 30; // ȭ�� ũ�⿡ ����ϴ� ��Ʈ ũ��
        style.normal.textColor = Color.white;

        // FPS ��� �� ǥ��
        float fps = 1.0f / deltaTime;
        string text = $"FPS: {Mathf.RoundToInt(fps)}";
        GUI.Label(rect, text, style);
    }
}
