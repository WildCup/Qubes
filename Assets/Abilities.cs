using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public skill[] skills;

    private Rigidbody rb;
    private Transform player;
    private float jumpHeigh = 6f;
    private int wavePoverSterter = 2300;

    void Start()
    {
        foreach (skill s in skills)
        {
            s.skillName = s.textSkillName.text + "Use";
            s.useLeft = PlayerPrefs.GetInt("skill" + s.skillName, 0);
            s.textUseLeft.text = s.useLeft.ToString();
            if (s.useLeft <= 0) s.button.interactable = false;
        }
        rb = this.GetComponent<Rigidbody>();
        player = this.GetComponent<Transform>();

        //wave
        wavePoverSterter += PlayerPrefs.GetInt("skillWavePower", 0) * 5;
    }

    void Update()
    {
        
    }

    public void JumpButtonClicked()
    {
        rb.AddForce(0f, jumpHeigh, 0f, ForceMode.Impulse);
        CalculateUseLeft("JumpUse");
    }

    public void WaveButtonClicked()
    {
        float radius = PlayerPrefs.GetInt("skillWavePower", 0) * 0.625f; //lvl 80 => 50f
        Collider[] obstactes = Physics.OverlapSphere(player.position+new Vector3(0,0,0.5f),radius,1<<7);
        foreach (Collider c in obstactes)
        {
            c.GetComponent<Rigidbody>().AddExplosionForce(wavePoverSterter, player.position, radius);
        }

        CalculateUseLeft("WaveUse");
    }
    public void CalculateUseLeft(string name)
    {
        skill s = Array.Find(skills, skill => skill.skillName == name);
        if(s == null)
        {
            Debug.Log(name + "not found");
            return;
        }

        s.useLeft--;
        s.textUseLeft.text = s.useLeft.ToString();
        if (s.useLeft <= 0)
        {
            //s.textSkillName.text = "";
            //s.textUseLeft.text = "";
            //s.button.interactable = false;
            s.button.gameObject.SetActive(false);
        }
    }
}
