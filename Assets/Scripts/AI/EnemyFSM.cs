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

        // 도착 감지: 현재 위치와 목표 위치 간의 거리 계산
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Y축 기준으로 월드의 -Z 방향을 바라보도록 회전
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back); // 월드의 -Z 방향

            // 부드럽게 회전
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5.0f * Time.deltaTime);

            // 이동을 멈추기 위해, 더 이상 MoveTowards를 호출하지 않도록 설정
            return; // 이 함수를 종료하여 더 이상 MoveTowards를 호출하지 않도록 함
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
            patient--;  // 인내심 감소
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
        // 현재 위치와 목표 위치 사이의 방향 벡터를 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 목표 방향으로 회전
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);

        // 목표 방향으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.0f * Time.deltaTime);
    }
   
}
