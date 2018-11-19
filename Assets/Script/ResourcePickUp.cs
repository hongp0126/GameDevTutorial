using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickUp : MonoBehaviour {
    private PlayerInventory player_inventory;

    public void Start()
    {
        player_inventory = GetComponent<PlayerInventory>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Resource")
        {
            player_inventory.OnResourcePickup(other.GetComponent<Resource>());
            GameObject.Destroy(other.gameObject);
        }
    }
}
