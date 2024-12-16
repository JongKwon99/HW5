using TMPro; // TextMeshPro를 사용하려면 필요
using UnityEngine;

public class PHUpdater : MonoBehaviour
{
    public TextMeshProUGUI textUI; // TextMeshProUGUI 컴포넌트
    public PlayerLife pl;

    void Update()
    {

        // 값 업데이트
        textUI.text = $"Player Health: {pl.amount}";
    }
}
