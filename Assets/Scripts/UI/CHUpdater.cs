using TMPro; // TextMeshPro�� ����Ϸ��� �ʿ�
using UnityEngine;

public class CHUpdater : MonoBehaviour
{
    public TextMeshProUGUI textUI; // TextMeshProUGUI ������Ʈ
    public PlayerBase pb;             // ������ ��

    void Update()
    {
        // �� ������Ʈ
        textUI.text = $"Castle Health: {pb.life}";
    }
}
