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
    public int patient = 4;

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
        if (sight.currentDetecting != null)
            currentState = EnemyState.ChasePlayer;

        Vector3 targetPosition = enemyBase.transform.position + new Vector3(0, 0, -5);
        MoveTowards(targetPosition);

        // ���� ����: ���� ��ġ�� ��ǥ ��ġ ���� �Ÿ� ���
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Y�� �������� ������ -Z ������ �ٶ󺸵��� ȸ��
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back); // ������ -Z ����

            // �ε巴�� ȸ��
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);

            // �̵��� ���߱� ����, �� �̻� MoveTowards�� ȣ������ �ʵ��� ����
            return; // �� �Լ��� �����Ͽ� �� �̻� MoveTowards�� ȣ������ �ʵ��� ��
        }
    }

    void AttackPlayerBase()
    {
        MoveTowards(playerBase.transform.position);
    }

    void ChasePlayer()
    {
        if (patient <= 0)
            currentState = EnemyState.AttackPlayerBase;

        if (player != null)
            MoveTowards(player.transform.position);

        if (player != null && Vector3.Distance(player.transform.position, transform.position) < 4f)
            currentState = EnemyState.AttackPlayer;
        
        if (sight.currentDetecting == null)
        {
            currentState = EnemyState.GoToEnemyBase;
            patient--;  // �γ��� ����
        }  
            
    }

    void AttackPlayer()
    {
        if (player != null)
            MoveTowards(player.transform.position);
        shooting.Shoot();

        if (player != null && Vector3.Distance(player.transform.position, transform.position) > 10f)
            currentState = EnemyState.GoToEnemyBase;
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
