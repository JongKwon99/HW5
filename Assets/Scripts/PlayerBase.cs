using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBase : MonoBehaviour
{
    public GameObject player;
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(effectPrefab, transform.position, transform.rotation);
    }
}
