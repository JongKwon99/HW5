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
    public EnemyShooting shooting; // �� �߻� ������Ʈ
    private float chaseDistance = 10f; // ���� ���� �Ÿ�
    private float attackDistance = 5f; // ���� ���� �Ÿ�

    public enum EnemyState
    {
        GoToEnemyBase,
        AttackPlayerBase,
        ChasePlayer,
        AttackPlayer
    }

    private void Start()
    {
        currentState = EnemyState.GoToEnemyBase;
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.GoToEnemyBase:
                GoToEnemyBase();
                break;
            case EnemyState.AttackPlayerBase:
                AttackPlayerBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    void GoToEnemyBase()
    {
        Vector3 targetPosition = enemyBase.transform.position + new Vector3(0, 0, -5);
        MoveTowards(targetPosition);

        // ���� ����: ���� ��ġ�� ��ǥ ��ġ ���� �Ÿ� ���
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // ������ -Z ������ �ٶ󺸵��� ȸ��
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back); // ������ -Z ����

            // �ε巴�� ȸ��
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);
        }

        if (sight.currentDetecting != null)
            currentState = EnemyState.ChasePlayer;
    }

    void AttackPlayerBase()
    {
        
    }

    void ChasePlayer()
    {
        MoveTowards(player.transform.position);

        if (sight.currentDetecting == null)
            currentState = EnemyState.GoToEnemyBase;
    }

    void AttackPlayer()
    {

    }

    void MoveTowards(Vector3 targetPosition)
    {
        // ���� ��ġ�� ��ǥ ��ġ ������ ���� ���͸� ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ��ǥ �������� ȸ��
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);

        // ��ǥ �������� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.0f * Time.deltaTime);
    }
   
}
