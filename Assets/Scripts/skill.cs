using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class skill
{
    public Button button;
    public Text textUseLeft;
    public Text textSkillName;

    [HideInInspector]
    public int useLeft;
    [HideInInspector]
    public string skillName;
}
