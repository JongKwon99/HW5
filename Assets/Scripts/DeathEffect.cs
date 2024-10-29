using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathEffect : MonoBehaviour
{
    public GameObject particlePrefab;
    public UnityEvent onDeath;

    void Awake()
    {
        Life life = GetComponent<Life>();
        life.onDeath.AddListener(OnDeath);
    }

    void OnDeath()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
