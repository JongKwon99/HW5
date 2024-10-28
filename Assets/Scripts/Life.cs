using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float amount;

    private void Update()
    {
        if (amount <= 0)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Player"))
                GameManager.Instance.CheckLife(this);

            Destroy(gameObject);
        }
    }
}
