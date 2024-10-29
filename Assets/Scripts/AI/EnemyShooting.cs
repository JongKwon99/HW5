using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject normalBullet;
    public GameObject shootPoint;

    private float shootCooldown = 1f;
    private float lastShootTime = 0f;

    public void Shoot()
    {
        // 현재 시간과 마지막 발사 시간의 차이가 쿨다운 시간보다 큰지 확인
        if (Time.time >= lastShootTime + shootCooldown)
        {
            Instantiate(normalBullet, shootPoint.transform.position, shootPoint.transform.rotation);
            lastShootTime = Time.time; // 마지막 발사 시간을 현재 시간으로 업데이트
        }
    }
}
