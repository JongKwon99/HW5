using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    public int life;
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            life--;
            if (life <= 0)
                SceneManager.LoadScene("Lose");
        }
    }
}
