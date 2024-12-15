using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;  // �⺻ 3��Ī ī�޶�
    public Camera reverseCamera; // ���� ī�޶� (C Ű ���� �� Ȱ��ȭ)

    private PlayerInput playerInput;  // PlayerInput ������Ʈ
    private InputAction lookForwardAction;

    private void Awake()
    {
        // PlayerInput ������Ʈ ��������
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        // InputAction ����
        lookForwardAction = playerInput.actions["Reverse Camera"]; // �׼� �̸��� Input Actions�� ������ �̸�
        lookForwardAction.started += OnCKeyPressed;
        lookForwardAction.canceled += OnCKeyReleased;
    }

    private void OnDisable()
    {
        // InputAction ���� ����
        lookForwardAction.started -= OnCKeyPressed;
        lookForwardAction.canceled -= OnCKeyReleased;
    }

    private void OnCKeyPressed(InputAction.CallbackContext context)
    {
        // C Ű�� ������ �� reverseCamera Ȱ��ȭ
        playerCamera.enabled = false;
        reverseCamera.enabled = true;
    }

    private void OnCKeyReleased(InputAction.CallbackContext context)
    {
        // C Ű�� ���� �� playerCamera Ȱ��ȭ
        reverseCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
