using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public int specialBulletNum;
    public GameObject normalBullet;
    public GameObject specialBullet;
    public GameObject shootPoint;
    public AudioSource shootingSound; // AudioSource ������Ʈ�� ����

    public void Awake()
    {
        shootingSound = GetComponent<AudioSource>();
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            // �Ѿ� ����
            Instantiate(normalBullet, shootPoint.transform.position, shootPoint.transform.rotation);

            // ���� ���
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
