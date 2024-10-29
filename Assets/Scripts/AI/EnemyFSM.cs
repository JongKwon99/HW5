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
    public EnemyShooting shooting; // 총 발사 컴포넌트
    private float chaseDistance = 10f; // 추적 시작 거리
    private float attackDistance = 5f; // 공격 시작 거리

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

        // 도착 감지: 현재 위치와 목표 위치 간의 거리 계산
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // 월드의 -Z 방향을 바라보도록 회전
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back); // 월드의 -Z 방향

            // 부드럽게 회전
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
        // 현재 위치와 목표 위치 사이의 방향 벡터를 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 목표 방향으로 회전
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);

        // 목표 방향으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.0f * Time.deltaTime);
    }
   
}
