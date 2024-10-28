using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Vector2 movementValue;
    private float lookValue;
    private Rigidbody rb;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>() * speed;
    }

    public void OnLook(InputValue value)
    {
        lookValue = value.Get<Vector2>().x * rotationSpeed;
    }

    void Update()
    {
        /*transform.Translate(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime);

        transform.Rotate(0, lookValue * Time.deltaTime, 0);*/

        rb.AddRelativeForce(
            movementValue.x * Time.deltaTime,
            0,
            movementValue.y * Time.deltaTime);

        rb.AddRelativeTorque(0, lookValue * Time.deltaTime, 0);

        //Debug.Log($"Movement Value: {movementValue}, Look Value: {lookValue}");
        //Debug.Log($"Velocity: {rb.velocity}, Angular Velocity: {rb.angularVelocity}");
    }

    // �۵��Ǵ� �ڵ�
    /*    private void FixedUpdate()
        {
            // �̵� ó��
            Vector3 moveDirection = new Vector3(movementValue.x, 0, movementValue.y).normalized;
            Vector3 targetPosition = rb.position + transform.TransformDirection(moveDirection) * speed * Time.fixedDeltaTime;

            rb.MovePosition(targetPosition);

            // ȸ�� ó�� (y�� ȸ����)
            float rotation = lookValue * rotationSpeed * Time.fixedDeltaTime;
            Quaternion turnOffset = Quaternion.Euler(0, rotation, 0);
            rb.MoveRotation(rb.rotation * turnOffset);
        }*/
}
