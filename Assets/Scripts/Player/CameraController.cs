using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Camera playerCamera;  // �⺻ 3��Ī ī�޶�

    private PlayerInput playerInput;  // PlayerInput ������Ʈ

    private void Awake()
    {
        // PlayerInput ������Ʈ ��������
        playerInput = GetComponent<PlayerInput>();
    }
}
