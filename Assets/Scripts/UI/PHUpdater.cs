using TMPro; // TextMeshPro�� ����Ϸ��� �ʿ�
using UnityEngine;

public class PHUpdater : MonoBehaviour
{
    public TextMeshProUGUI textUI; // TextMeshProUGUI ������Ʈ
    public PlayerLife pl;

    void Update()
    {

        // �� ������Ʈ
        textUI.text = $"Player Health: {pl.amount}";
    }
}
