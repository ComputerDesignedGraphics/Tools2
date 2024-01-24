using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        Heart,
        Gear,
        Beaker
        // Add other power-up types here
    }

    public PowerUpType powerUpType;

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            switch (powerUpType)
            {
                case PowerUpType.Heart:
                    playerInventory.HeartCollected();
                    break;
                case PowerUpType.Gear:
                    // Add logic for Gear collected
                    break;
                case PowerUpType.Beaker:
                    // Add logic for Beaker collected
                    break;
                // Add cases for other power-up types
            }

            Debug.Log($"Player collided with {powerUpType}!");
            gameObject.SetActive(false);
        }
    }
}
