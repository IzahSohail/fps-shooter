using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Health playerHealth; // Drag your player's Health script here
    public Image fillImage;     // Drag your HealthBarFill image here

    void Update()
    {
        if (playerHealth != null && fillImage != null)
        {
            fillImage.fillAmount = playerHealth.GetHealthPercent();
        }
    }
}

