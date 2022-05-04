using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earning : MonoBehaviour
{
    private Transform player;

    //money
    public Text ernedMoenyText;
    public Animator ernedMoenyAnimator;
    float distanceToEarn = 50f;
    

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (player.transform.position.z >= distanceToEarn)
        {
            if (distanceToEarn >= 495f) distanceToEarn = 1000f;

            float multiplayer = 1;
            if (player.transform.position.z < PlayerPrefs.GetFloat("record" + AudioManager.instance.difficulty.ToString(), -20f)) multiplayer = 0.1f;
            EarnMoney(distanceToEarn * Mathf.Max(AudioManager.instance.difficulty,0.5f)* multiplayer);
            distanceToEarn += 50f;
        }
    }

    public void EarnMoney(float reward)
    {
        //play animation with reward amount
        ernedMoenyText.text = "+" + reward.ToString() + "$";
        ernedMoenyAnimator.Play("ErnedMoneyAnimation",-1,0);

        //add money
        PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money", 0f) + reward);
    }
}
