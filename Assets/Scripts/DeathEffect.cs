using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathEffect : MonoBehaviour
{
    public GameObject particlePrefab;
    //public UnityEvent onDeath;

    void Start()
    {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(explode);
    }

    void explode()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
