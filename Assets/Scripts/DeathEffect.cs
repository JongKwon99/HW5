using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public GameObject particlePrefab;
    //public UnityEvent onDeath;

    void Start()
    {
        EnemyLife life = GetComponent<EnemyLife>();
        life.onDeath.AddListener(explode);
    }

    void explode()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
