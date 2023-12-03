using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static GlobalInventory Instance;
    public List<Pickup> pickups = new List<Pickup>();
    

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        

    }
  


    public void AddPickup (Pickup pickupToAdd)
    {
        bool pickupExist = false;

        foreach (Pickup pickup in pickups)
        {
            if (pickup.name == pickupToAdd.name)
            {
                pickup.count += pickupToAdd.count;
                pickupExist = true;
                break;
            }
        }
        if(!pickupExist) 
        {
            pickups.Add(pickupToAdd);  
        }
        Debug.Log(pickupToAdd.count + " " + pickupToAdd.name + " Added");

    }

    public void RemovePickup(Pickup pickupToRemove)
    {
        foreach (var pickup in pickups) 
        { 
            if(pickup.name == pickupToRemove.name)
            {
                pickup.count -= pickupToRemove.count;
                {
                    if( pickup.count <= 0 )
                    {
                        pickups.Remove(pickupToRemove);
                    }
                    break;
                }
            }
        }
        Debug.Log(pickupToRemove.count + " " + pickupToRemove.name + "removed");
    }
}
