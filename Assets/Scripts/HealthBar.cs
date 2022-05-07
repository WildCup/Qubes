using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text hpText;
    public Animator animator;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("skillHp", 0) == 0) gameObject.SetActive(false);
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        hpText.text = "HP:" + health.ToString("0");
        PlayAnimationDamage();
    }
    public void PlayAnimationDamage()
    {
        if (gameObject.activeSelf)
            animator.Play("HealthBarDamage",-1,0f);
    }
}
