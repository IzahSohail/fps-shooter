using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to Main Menu");
        SceneManager.LoadScene("MainMenu"); 
    }
}
