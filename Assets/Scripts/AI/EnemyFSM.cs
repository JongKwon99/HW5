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

    public enum EnemyState
    {
        AttackPlayerBase,
        ChasePlayer,
    }

    private void Start()
    {
        currentState = EnemyState.AttackPlayerBase;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.AttackPlayerBase:
                AttackPlayerBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
        }
    }

    void AttackPlayerBase()
    {
        if (sight.currentDetecting != null)
            currentState = EnemyState.ChasePlayer;
        else
        {
            MoveTowards(playerBase.transform.position);
        }
    }

    void ChasePlayer()
    {
        if (sight.currentDetecting != null)
        {
            //LookAtPlayer();
            MoveTowards(player.transform.position);
        }  
        else
            currentState = EnemyState.AttackPlayerBase;
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
