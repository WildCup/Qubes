using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 0.4f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevelMenu()
    {
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int index)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //stop music
        AudioManager.instance.Stop();
        //load the scene
        SceneManager.LoadScene(index);
    }
}
