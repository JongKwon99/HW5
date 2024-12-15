using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;  // 기본 3인칭 카메라
    public Camera reverseCamera; // 정면 카메라 (C 키 누를 때 활성화)

    private PlayerInput playerInput;  // PlayerInput 컴포넌트
    private InputAction lookForwardAction;

    private void Awake()
    {
        // PlayerInput 컴포넌트 가져오기
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        // InputAction 연결
        lookForwardAction = playerInput.actions["Reverse Camera"]; // 액션 이름은 Input Actions에 설정된 이름
        lookForwardAction.started += OnCKeyPressed;
        lookForwardAction.canceled += OnCKeyReleased;
    }

    private void OnDisable()
    {
        // InputAction 연결 해제
        lookForwardAction.started -= OnCKeyPressed;
        lookForwardAction.canceled -= OnCKeyReleased;
    }

    private void OnCKeyPressed(InputAction.CallbackContext context)
    {
        // C 키를 눌렀을 때 reverseCamera 활성화
        playerCamera.enabled = false;
        reverseCamera.enabled = true;
    }

    private void OnCKeyReleased(InputAction.CallbackContext context)
    {
        // C 키를 뗐을 때 playerCamera 활성화
        reverseCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
