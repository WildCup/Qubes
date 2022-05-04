using UnityEngine;

public class AddRandomForse : MonoBehaviour
{
    public Rigidbody rbO;
    void Start()
    {
        //rbO = this.GetComponent<Rigidbody>();
        //rbO.AddForce(0f,20f,0f,ForceMode.Impulse);
    }
    private Vector3 RandomeForse()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-0.2f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        return new Vector3(randomX, randomY, randomZ);
    }
}
