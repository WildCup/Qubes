using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    public Text text;
    public Text recordText;
    //static private int buttonNumber = 0;

    void Start()
    {
        //text.text = buttonNumber.ToString();
        //buttonNumber++;

        int difficultyReached = PlayerPrefs.GetInt("difficultyReached", 0);
        if (int.Parse(text.text) > difficultyReached)
        {
            this.GetComponent<Button>().interactable = false;
            recordText.text = "";
        }
        else recordText.text = " " + (PlayerPrefs.GetFloat("record" + text.text, 0f)/4.99f).ToString("0") + "%";
    }
    public void SetDifficultyToClickedButton()
    {
        AudioManager.instance.difficulty = int.Parse(text.text);
        Debug.Log(AudioManager.instance.difficulty);
        FindObjectOfType<Fader>().LoadNextLevel();
    }
}
