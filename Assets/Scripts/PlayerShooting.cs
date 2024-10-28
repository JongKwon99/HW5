using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public int specialBulletNum;
    public GameObject normalBullet;
    public GameObject specialBullet;
    public GameObject shootPoint;

    void Update()
    {
/*        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(normalBullet, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (specialBulletNum > 0)
            {
                Instantiate(specialBullet, transform.position, transform.rotation);
                specialBulletNum--;
            }

        }*/
    }

    public void OnNormalShoot(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(normalBullet, transform.position, transform.rotation);
        }
    }

    public void OnSpecialShoot(InputValue value)
    {
        if (value.isPressed && specialBulletNum > 0)
        {
            GameObject clone = Instantiate(specialBullet, transform.position, transform.rotation);
            specialBulletNum--;
        }
    }
}
