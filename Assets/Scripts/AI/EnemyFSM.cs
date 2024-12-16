using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBase;
    public GameObject enemyBase;

    public EnemyState currentState;
    public Sight sight;
    public EnemyShooting shooting;
    public int patient = 2;

    public enum EnemyState
    {
        Patrol,
        ChasePlayer,
    }

    private void Start()
    {
        currentState = EnemyState.Patrol;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
        }
    }

    void Patrol()
    {
        if (sight.currentDetecting != null)
            currentState = EnemyState.ChasePlayer;
    }

    void ChasePlayer()
    {
        if (sight.currentDetecting != null)
        {
            //LookAtPlayer();
            MoveTowards(player.transform.position);
        }  
        else
            currentState = EnemyState.Patrol;
    }

    void MoveTowards(Vector3 targetPosition)
    {
        // ��ǥ ��ġ������ ���� ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Y�� ���� (�ʿ� �� Ȱ��ȭ)
        direction.y = 0;

        // ��ǥ �������� �ε巴�� ȸ��
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);
        }

        // ��ǥ �������� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.0f * Time.deltaTime);
    }

    void LookAtPlayer()
    {
        if (player != null)
        {
            // B ������Ʈ�� �������� ���� Z�� ����
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Y�� ���� (�ʿ� �� Ȱ��ȭ)
            direction.y = 0;

            // ������ ��ȿ�ϸ� LookRotation ����
            if (direction.magnitude > 0)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    lookRotation,
                    5.0f * Time.deltaTime // ȸ�� �ӵ�
                );
            }
        }
    }
}
