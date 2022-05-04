using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text score;


    public Text currentLevelText;
    public Text completedLevelText;

    public Transform lastRecord;
    public Text lastRecordText;


    private void Start()
    {
        currentLevelText.text = "Level: " + AudioManager.instance.difficulty.ToString();
        completedLevelText.text = currentLevelText.text.ToUpper();

        lastRecord.position = new Vector3(0f, lastRecord.position.y, PlayerPrefs.GetFloat("record"+AudioManager.instance.difficulty.ToString(),-20f));
        lastRecordText.text = lastRecord.position.z.ToString("0") + "m";
        if (lastRecordText.text == "497m") lastRecord.position = lastRecord.position = new Vector3(0f,0f,-30f);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = player.position.z.ToString("0");
        if (player.position.z >= 350f)
        {
            if (PlayerPrefs.GetInt("difficultyReached", 0) < AudioManager.instance.difficulty + 1)
                PlayerPrefs.SetInt("difficultyReached", AudioManager.instance.difficulty + 1);
        }
    }
}
