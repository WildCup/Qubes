using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private GameObject player;
    public Transform[] spawnPoints;
    private Transform end;
    private float distanceToSpawn = 0f;
    private float myStartPosition;

    private float distanceBetweenWaves = 13f;
    private float maxRandomForce = 25f;
    private int difficulty;

    void Start()
    {
        myStartPosition = this.transform.position.z;
        player = GameObject.Find("Player");
        end = GameObject.Find("END").GetComponent<Transform>();

        difficulty = AudioManager.instance.difficulty;

        distanceBetweenWaves = Mathf.Max(distanceBetweenWaves - (Mathf.Sqrt(difficulty)*2.4f), 5f);
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(0f,1f, myStartPosition + player.transform.position.z);
        if ((player.transform.position.z >= distanceToSpawn)&& (distanceToSpawn < (end.position.z - 100f)))
        {
            SpawnObstycles();
            if (difficulty > 3) SpawnObstycles();
            if (difficulty > 10) SpawnObstycles();
            if (difficulty > 15) SpawnObstycles();
            if (difficulty > 30) SpawnObstycles();

            distanceToSpawn = player.transform.position.z + distanceBetweenWaves;
        }
    }

    void SpawnObstycles()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i == randomIndex)
            {
                var obs = Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                Rigidbody rbO = obs.GetComponent<Rigidbody>();
                rbO.AddForce(RandomeForse(), ForceMode.Impulse);
            }
        }
    }

    private Vector3 RandomeForse()
    {
        float d = Mathf.Clamp((difficulty - 8)*4, 0f, maxRandomForce);
        float randomX = Random.Range(-d, d);
        float randomY = Random.Range(-0.2f, d);
        float randomZ = Random.Range(-d, d);
        return new Vector3(randomX, randomY, randomZ);
    }
}
