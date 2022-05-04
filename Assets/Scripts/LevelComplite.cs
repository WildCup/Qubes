using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplite : MonoBehaviour
{
    
    public void LoadNewLevel()
    {
        AudioManager.instance.difficulty++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
