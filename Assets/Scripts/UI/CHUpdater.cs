using TMPro; // TextMeshPro를 사용하려면 필요
using UnityEngine;

public class CHUpdater : MonoBehaviour
{
    public TextMeshProUGUI textUI; // TextMeshProUGUI 컴포넌트
    public PlayerBase pb;             // 연동할 값

    void Update()
    {
        // 값 업데이트
        textUI.text = $"Castle Health: {pb.life}";
    }
}
