using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    float hp;
    public float damageSpeed = 50f;
    public HealthBar healthBar;

    private void Start()
    {
        hp = PlayerPrefs.GetInt("skillHp", 0);// * 2f;
        healthBar.SetMaxHealth(hp);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            hp = Mathf.Max(hp - damageSpeed * Time.deltaTime,0f);
            healthBar.SetHealth(hp);
            if (hp <= 0)
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
