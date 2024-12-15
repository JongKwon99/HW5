using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public int specialBulletNum;
    public GameObject normalBullet;
    public GameObject specialBullet;
    public GameObject shootPoint;
    public AudioSource shootingSound; // AudioSource 컴포넌트를 참조

    public void Awake()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            // 총알 생성
            Instantiate(normalBullet, shootPoint.transform.position, shootPoint.transform.rotation);

            // 사운드 재생
            if (shootingSound != null)
            {
                shootingSound.Play();
            }
        }
    }

    /*public void OnSpecialShoot(InputValue value)
    {
        if (value.isPressed && specialBulletNum > 0)
        {
            GameObject clone = Instantiate(specialBullet, transform.position, transform.rotation);
            specialBulletNum--;
        }
    }*/
}
