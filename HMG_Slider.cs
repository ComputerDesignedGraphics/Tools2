using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HMG_Slider : MonoBehaviour
{
    public Slider slider;

    public int heartsCollected = 0;
    public int gearsCollected = 0;
    public int beakersCollected = 0;

    // Call this method whenever a power-up is collected
    public void UpdateHealth()
    {
        int totalCollected = heartsCollected + gearsCollected + beakersCollected;
        SetHealth(totalCollected * 10); // Assuming each item increases health by 10
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
