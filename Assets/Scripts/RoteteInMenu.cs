using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteteInMenu : MonoBehaviour
{
    public Transform cube;
    void Start()
    {
        if (!Input.gyro.enabled) Input.gyro.enabled = true;
    }

    
    void Update()
    {
        cube.rotation = Input.gyro.attitude;
    }
}
