using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f; // �̵� �ӵ�
    public float minMoveTime = 3f; // �ּ� �̵� �ð�
    public float maxMoveTime = 5f; // �ִ� �̵� �ð�
    public float maxRotationAngle = 90f; // �ִ� ȸ�� ����
    private Vector3 moveDirection; // ���� �̵� ����
    private float moveTimer; // �̵� Ÿ�̸�
    private float moveDuration; // ���� �̵� ���� �ð�
    private AttackPlayer attackPlayer; // AttackPlayer ������Ʈ�� ������ ����

    void Start()
    {
        attackPlayer = GetComponent<AttackPlayer>(); // AttackPlayer ������Ʈ ����
        SetNewDirectionAndDuration(); // ���ο� ���� �� �̵� ���� �ð� ����
    }

    void Update()
    {
        // �÷��̾ �ν��ϰ� ���� ��
        if (attackPlayer.IsAttacking())
        {
            MoveTowardsPlayer(); // �÷��̾� ������ �̵�
        }
        else
        {
            MoveRandomly(); // �����ϰ� �̵�
        }
    }

    private void MoveRandomly()
    {
        // �̵� Ÿ�̸� ����
        moveTimer += Time.deltaTime;

        // ������ �ð� ���� �̵�
        if (moveTimer < moveDuration)
        {
            // ���� �̵� �������� �̵�
            transform.position += moveDirection * speed * Time.deltaTime; // ������ �̵�
        }
        else
        {
            // �̵� �ð��� ������ ȸ��
            RotateRandomly();
        }
    }

    private void RotateRandomly()
    {
        // -90������ 90�� ������ ���� ���� ����
        float randomAngle = Random.Range(-maxRotationAngle, maxRotationAngle);
        Quaternion randomRotation = Quaternion.Euler(0, randomAngle, 0); // y���� �߽����� ȸ��

        // ���� ȸ�� ���⿡ ���� ȸ�� ����
        moveDirection = randomRotation * Vector3.forward; // �������θ� �̵�
        moveDirection.Normalize(); // ���� ����ȭ

        SetNewDuration(); // ���ο� �̵� ���� �ð� ����
    }

    private void SetNewDirectionAndDuration()
    {
        // ���� �������� ����
        moveDirection = transform.forward; // ���� ������ �⺻���� ���
        SetNewDuration(); // ���ο� �̵� ���� �ð� ����
    }

    private void SetNewDuration()
    {
        // ������ �̵� ���� �ð� ����
        moveDuration = Random.Range(minMoveTime, maxMoveTime);
        moveTimer = 0f; // Ÿ�̸� ����
    }

    private void MoveTowardsPlayer()
    {
        // �÷��̾� ������ �̵��ϴ� ������ �߰��� �� �ֽ��ϴ�.
        // ��: AttackPlayer ��ũ��Ʈ���� �÷��̾��� ��ġ�� ���޹޾� �̵�
    }
}
