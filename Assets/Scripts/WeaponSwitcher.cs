using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;

    private bool isUsingPistol = true;

    void Start()
    {
        pistol.SetActive(true);
        rifle.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            rifle.SetActive(false);
            isUsingPistol = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol.SetActive(false);
            rifle.SetActive(true);
            isUsingPistol = false;
        }
    }

    public bool IsUsingPistol()
    {
        return isUsingPistol;
    }
}
