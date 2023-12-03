using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectVirus : MonoBehaviour

 {
    public Pickup pickup = new Pickup("Item Name", 1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            GlobalInventory.Instance.AddPickup(pickup);
            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet2"))
        {
            Destroy(gameObject);
        }
    }

}

