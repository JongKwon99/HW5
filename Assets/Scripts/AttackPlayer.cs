using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float speed = 2f; // ���� �̵� �ӵ�
    public float rotationSpeed = 5f; // ���� ȸ�� �ӵ�
    private Sight sight; // Sight ������Ʈ�� ������ ����
    private Collider playerCollider; // �浹�� �÷��̾��� �ݶ��̴�
    protected bool isAttacking = false; // ���� ���¸� ��Ÿ���� ����

    void Start()
    {
        sight = GetComponentInChildren<Sight>(); // �ڽ��� Sight ������Ʈ ����
    }

    void Update()
    {
        // �÷��̾ �νĵǰ� ��ֹ��� ���� �� ���� ���·� ��ȯ
        if (sight.detectedObject != null)
        {
            playerCollider = sight.detectedObject; // �νĵ� �÷��̾��� �ݶ��̴�

            // ��ֹ��� ������ ���� ���·� ��ȯ
            if (!Physics.Linecast(transform.position, playerCollider.bounds.center, sight.obstaclesLayers))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false; // ��ֹ��� ������ �������� ����
            }
        }
        else
        {
            isAttacking = false; // �νĵ� �÷��̾ ������ �������� ����
        }

        // ���� ������ �� �÷��̾� ������ �̵� �� ȸ��
        if (isAttacking)
        {
            MoveTowardsPlayer();
        }
    }

    public bool IsAttacking()
    {
        return isAttacking; // ���� ���� ��ȯ
    }

    private void MoveTowardsPlayer()
    {
        // �÷��̾���� �Ÿ� ���
        Vector3 targetPosition = playerCollider.bounds.center; // �÷��̾��� ��ġ
        targetPosition.y = transform.position.y; // y���� ���� ���� y ��ġ�� �����Ͽ� ���� �̵��� �ϰ� ��
        float step = speed * Time.deltaTime; // �̵� �ܰ� ���

        // ȸ�� ó��
        Vector3 direction = (targetPosition - transform.position).normalized; // �÷��̾� ���� ���
        if (direction != Vector3.zero)
        {
            // ���� ȸ���� ����ϱ� ���� y�� �������θ� ȸ��
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            lookRotation.x = 0; // x�� ȸ�� ����
            lookRotation.z = 0; // z�� ȸ�� ����
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime); // �ε巯�� ȸ��
        }

        // �÷��̾� ������ �̵�
        // y�� ��ġ ����
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, step); // �÷��̾� ������ �̵�
        newPosition.y = transform.position.y; // y���� ����
        transform.position = newPosition; // ���ο� ��ġ�� ����
    }
}
