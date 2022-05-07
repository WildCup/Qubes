using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(1);        
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
