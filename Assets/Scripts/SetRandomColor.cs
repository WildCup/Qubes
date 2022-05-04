using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomColor : MonoBehaviour
{
    public MeshRenderer rend;

    static Color newColor;

    static int lastDifficulty = -1;

    void Start()
    {
        if (lastDifficulty != AudioManager.instance.difficulty)
        {
            newColor = new Color(Random.value, Random.value, Random.value, 1f);
            rend.material.color = newColor;

            lastDifficulty = AudioManager.instance.difficulty;
        }
        rend.material.color = newColor;

    }

}
