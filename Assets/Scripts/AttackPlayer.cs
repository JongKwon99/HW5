using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public float speed = 2f; // 적의 이동 속도
    public float rotationSpeed = 5f; // 적의 회전 속도
    private Sight sight; // Sight 컴포넌트를 참조할 변수
    private Collider playerCollider; // 충돌할 플레이어의 콜라이더
    protected bool isAttacking = false; // 공격 상태를 나타내는 변수

    void Start()
    {
        sight = GetComponentInChildren<Sight>(); // 자식의 Sight 컴포넌트 참조
    }

    void Update()
    {
        // 플레이어가 인식되고 장애물이 없을 때 공격 상태로 전환
        if (sight.detectedObject != null)
        {
            playerCollider = sight.detectedObject; // 인식된 플레이어의 콜라이더

            // 장애물이 없으면 공격 상태로 전환
            if (!Physics.Linecast(transform.position, playerCollider.bounds.center, sight.obstaclesLayers))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false; // 장애물이 있으면 공격하지 않음
            }
        }
        else
        {
            isAttacking = false; // 인식된 플레이어가 없으면 공격하지 않음
        }

        // 공격 상태일 때 플레이어 쪽으로 이동 및 회전
        if (isAttacking)
        {
            MoveTowardsPlayer();
        }
    }

    public bool IsAttacking()
    {
        return isAttacking; // 공격 상태 반환
    }

    private void MoveTowardsPlayer()
    {
        // 플레이어와의 거리 계산
        Vector3 targetPosition = playerCollider.bounds.center; // 플레이어의 위치
        targetPosition.y = transform.position.y; // y축을 현재 적의 y 위치로 고정하여 수평 이동만 하게 함
        float step = speed * Time.deltaTime; // 이동 단계 계산

        // 회전 처리
        Vector3 direction = (targetPosition - transform.position).normalized; // 플레이어 방향 계산
        if (direction != Vector3.zero)
        {
            // 수평 회전만 고려하기 위해 y축 방향으로만 회전
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            lookRotation.x = 0; // x축 회전 고정
            lookRotation.z = 0; // z축 회전 고정
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime); // 부드러운 회전
        }

        // 플레이어 쪽으로 이동
        // y축 위치 고정
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, step); // 플레이어 쪽으로 이동
        newPosition.y = transform.position.y; // y축을 고정
        transform.position = newPosition; // 새로운 위치로 설정
    }
}
