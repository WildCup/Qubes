using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    float restartDelay = 0.6f;

    public GameObject compliteLevelUI;
    public Transform player;

    private void Start()
    {
        AudioManager.instance.Stop();
        AudioManager.instance.Play("Level" + AudioManager.instance.difficulty); 
    }
    public void CompliteLevel()
    {
        SetNewRecord();

        compliteLevelUI.SetActive(true);
        //if(PlayerPrefs.GetInt("difficultyReached",0)< AudioManager.instance.difficulty + 1)
            //PlayerPrefs.SetInt("difficultyReached", AudioManager.instance.difficulty + 1);
    }

    public void EndGame()
    {
       SetNewRecord();
        
       if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart",restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoBackToLevelMenu()
    {
        FindObjectOfType<Fader>().LoadLevelMenu();
        AudioManager.instance.Stop();
        AudioManager.instance.PlayTheme();
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
        AudioManager.instance.Stop();
        AudioManager.instance.PlayTheme();
    }

    public void SetNewRecord()
    {
        //if new record then set new record
        if (PlayerPrefs.GetFloat("record" + AudioManager.instance.difficulty.ToString(), 0f) < player.position.z)
        {
            PlayerPrefs.SetFloat("record" + AudioManager.instance.difficulty.ToString(), player.position.z);
            if (player.position.z>250f && (PlayerPrefs.GetInt("difficultyReached", 0) < AudioManager.instance.difficulty + 1))
            {
                PlayerPrefs.SetInt("difficultyReached", AudioManager.instance.difficulty + 1);
            }
        }
    }

}
