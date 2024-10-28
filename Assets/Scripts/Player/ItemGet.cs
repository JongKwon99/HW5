using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public GameObject prefab;
    public Transform shootPoint;

    private void OnTriggerEnter(Collider other)
    {
        int itemLayer = LayerMask.NameToLayer("Item");

        if (other.gameObject.layer == itemLayer)
        {
            Destroy(other.gameObject);

            for (int i = 0; i < 64; i++)
            {
                float angle = i * 5.625f;
                Quaternion newRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + angle, 0);
                Instantiate(prefab, shootPoint.position, newRotation);
            }
        }
    }
}
