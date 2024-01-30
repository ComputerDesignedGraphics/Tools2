using UnityEngine;

public class BlueGlowPowerUp : MonoBehaviour
{
    // Assign this in the Inspector to the glowing blue material
    public Material blueGlowMaterial;
    private Material originalMaterial;
    private Renderer objectRenderer;

    void Start()
    {
        // Get the Renderer component from the object
        objectRenderer = GetComponent<Renderer>();
        // Save the original material of the object
        originalMaterial = objectRenderer.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Player" or whatever your target object tag is
        if (collision.gameObject.tag == "Player")
        {
            ApplyBlueGlow();
            // Optionally, disable the power-up object so it can't be used again
            gameObject.SetActive(false);
        }
    }

    void ApplyBlueGlow()
    {
        // Change the material of the object to the blue glow material
        objectRenderer.material = blueGlowMaterial;
        // Here you can add more logic to handle the duration of the glow, effects, etc.

        // Example to revert back after 5 seconds (You can remove or adjust this part as needed)
        Invoke("RemoveBlueGlow", 5f);
    }

    void RemoveBlueGlow()
    {
        // Revert to the original material
        objectRenderer.material = originalMaterial;
    }
}
