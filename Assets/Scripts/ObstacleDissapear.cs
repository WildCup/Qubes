using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleDissapear : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
