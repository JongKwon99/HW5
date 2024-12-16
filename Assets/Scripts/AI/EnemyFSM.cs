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
        // 목표 위치까지의 방향 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Y축 고정 (필요 시 활성화)
        direction.y = 0;

        // 목표 방향으로 부드럽게 회전
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f * Time.deltaTime);
        }

        // 목표 방향으로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2.0f * Time.deltaTime);
    }

    void LookAtPlayer()
    {
        if (player != null)
        {
            // B 오브젝트의 방향으로 로컬 Z축 정렬
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Y축 고정 (필요 시 활성화)
            direction.y = 0;

            // 방향이 유효하면 LookRotation 수행
            if (direction.magnitude > 0)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    lookRotation,
                    5.0f * Time.deltaTime // 회전 속도
                );
            }
        }
    }
}
