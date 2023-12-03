using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour
{
    public Pickup pickup = new Pickup("Resource", 1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            GlobalInventory.Instance.AddPickup(pickup);
            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet1"))
        {
            Destroy(gameObject);
        }
    }

}
