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
        // ���� �ð��� ������ �߻� �ð��� ���̰� ��ٿ� �ð����� ū�� Ȯ��
        if (Time.time >= lastShootTime + shootCooldown)
        {
            Instantiate(normalBullet, shootPoint.transform.position, shootPoint.transform.rotation);
            lastShootTime = Time.time; // ������ �߻� �ð��� ���� �ð����� ������Ʈ
        }
    }
}
