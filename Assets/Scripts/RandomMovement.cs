using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 2f; // 이동 속도
    public float minMoveTime = 3f; // 최소 이동 시간
    public float maxMoveTime = 5f; // 최대 이동 시간
    public float maxRotationAngle = 90f; // 최대 회전 각도
    private Vector3 moveDirection; // 현재 이동 방향
    private float moveTimer; // 이동 타이머
    private float moveDuration; // 현재 이동 지속 시간
    private AttackPlayer attackPlayer; // AttackPlayer 컴포넌트를 참조할 변수

    void Start()
    {
        attackPlayer = GetComponent<AttackPlayer>(); // AttackPlayer 컴포넌트 참조
        SetNewDirectionAndDuration(); // 새로운 방향 및 이동 지속 시간 설정
    }

    void Update()
    {
        // 플레이어를 인식하고 있을 때
        if (attackPlayer.IsAttacking())
        {
            MoveTowardsPlayer(); // 플레이어 쪽으로 이동
        }
        else
        {
            MoveRandomly(); // 랜덤하게 이동
        }
    }

    private void MoveRandomly()
    {
        // 이동 타이머 증가
        moveTimer += Time.deltaTime;

        // 지정된 시간 동안 이동
        if (moveTimer < moveDuration)
        {
            // 현재 이동 방향으로 이동
            transform.position += moveDirection * speed * Time.deltaTime; // 앞으로 이동
        }
        else
        {
            // 이동 시간이 끝나면 회전
            RotateRandomly();
        }
    }

    private void RotateRandomly()
    {
        // -90도에서 90도 사이의 랜덤 각도 생성
        float randomAngle = Random.Range(-maxRotationAngle, maxRotationAngle);
        Quaternion randomRotation = Quaternion.Euler(0, randomAngle, 0); // y축을 중심으로 회전

        // 현재 회전 방향에 랜덤 회전 적용
        moveDirection = randomRotation * Vector3.forward; // 정면으로만 이동
        moveDirection.Normalize(); // 방향 정규화

        SetNewDuration(); // 새로운 이동 지속 시간 설정
    }

    private void SetNewDirectionAndDuration()
    {
        // 현재 방향으로 설정
        moveDirection = transform.forward; // 현재 방향을 기본으로 사용
        SetNewDuration(); // 새로운 이동 지속 시간 설정
    }

    private void SetNewDuration()
    {
        // 랜덤한 이동 지속 시간 설정
        moveDuration = Random.Range(minMoveTime, maxMoveTime);
        moveTimer = 0f; // 타이머 리셋
    }

    private void MoveTowardsPlayer()
    {
        // 플레이어 쪽으로 이동하는 로직을 추가할 수 있습니다.
        // 예: AttackPlayer 스크립트에서 플레이어의 위치를 전달받아 이동
    }
}
