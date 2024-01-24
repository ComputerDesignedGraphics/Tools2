using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public enum PowerUpType
    {
        Heart,
        Gear,
        Beaker
        // Add other power-up types here
    }

    public int NumberOfHearts { get; private set; }
    public int NumberOfGears { get; private set; }
    public int NumberOfBeakers { get; private set; }

    public HMG_Slider HMG_Slider; // Reference to HMG_Slider script

    public void CollectPowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.Heart:
                HeartCollected();
                break;
            case PowerUpType.Gear:
                GearCollected();
                break;
            case PowerUpType.Beaker:
                BeakerCollected();
                break;
            // Add cases for other power-up types
        }
    }

    public void HeartCollected()
    {
        NumberOfHearts++;
        IncreaseHealth();
    }

    public void GearCollected()
    {
        NumberOfGears++;
        IncreaseHealth();
    }

    public void BeakerCollected()
    {
        NumberOfBeakers++;
        IncreaseHealth();
    }

    private void IncreaseHealth()
    {
        if (HMG_Slider != null && HMG_Slider.slider.value <= 90)
        {
            HMG_Slider.slider.value += 10; // Increase health slider by 10
        }
    }

    // Add other methods for different power-up types
}
