using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrade : MonoBehaviour
{
    public Text skillName;
    public Text costText;
    public Text lvlText;
    int lvl;
    float cost;

    public Button button;

    //money
    public Text myMoneyText;
    float myMoney = 0f;

    void Start()
    {
        lvl = PlayerPrefs.GetInt("skill" + skillName.text, 0);

        //money
        /*
        */
        myMoneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        myMoney = PlayerPrefs.GetFloat("money", 0f);
        

        ShowTheResult();
    }
    public void Upgrade()
    {
        //lvl
        lvl++;
        PlayerPrefs.SetInt("skill" + skillName.text, lvl);

        //money
        string lastCost = cost.ToString();
        myMoney -= cost;
        PlayerPrefs.SetFloat("money", myMoney);
        //money animation
        //*do sth with lastCost*

        //show next transaction
        ShowTheResult();      
    }

    private void ShowTheResult()
    {
        lvlText.text = "lvl:" + lvl.ToString();
        cost = 100f * Mathf.Pow(1.5f,lvl);
        //if it is jump then 10*more expensive
        if(skillName.text.Contains("Use")) cost = Mathf.Pow(cost, 2);
        cost = Mathf.Round(cost);

        //if cost is more then 1k then round it
        bool done = false;
        int divedeMe = 1000;

        //less then 1k = do nothing
        if (cost < divedeMe)
        {
            done = true;
            divedeMe = 1;
        }
        //in case of emergency E+
        if (cost > 1000000000)
        {
            cost = 1000000000;
            divedeMe = 1000000000;
            done = true;
        }
        //normal
        while (!done)
        {
            if (cost < divedeMe * 10)
            {
                float c = Mathf.Floor(cost / (divedeMe/100));
                c = c / 100;
                cost = c * divedeMe;
                done = true;
            }
            else if (cost < divedeMe * 100)
            {
                float c = Mathf.Floor(cost / (divedeMe / 10));
                c = c / 10;
                cost = c * divedeMe;
                done = true;
            }
            else if (cost < divedeMe * 1000)
            {
                float c = Mathf.Floor(cost / (divedeMe / 1));
                c = c / 1;
                cost = c * divedeMe;
                done = true;
            }
            else divedeMe *= 1000;
        }

        string multiplayer;
        switch (divedeMe)
        {
            case 1:
                multiplayer = "";
                break;
            case 1000:
                multiplayer = "k";
                break;
            case 1000000:
                multiplayer = "M";
                break;
            case 1000000000:
                multiplayer = "G";
                break;
            default:
                multiplayer = "E+";
                break;
        }
        costText.text = (cost / divedeMe).ToString() + multiplayer + "$";

        //money
        if (cost > myMoney) button.interactable = false;
        myMoneyText.text = myMoney.ToString() + "$";
    }
}
