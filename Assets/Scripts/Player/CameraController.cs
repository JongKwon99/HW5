using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;  // 기본 3인칭 카메라

    private PlayerInput playerInput;  // PlayerInput 컴포넌트

    private void Awake()
    {
        // PlayerInput 컴포넌트 가져오기
        playerInput = GetComponent<PlayerInput>();
    }
}
