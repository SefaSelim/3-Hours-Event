using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySC : MonoBehaviour
{
    public float health;
    public SpaceShip PlayerSC; //script adı değişti o yüzden spaceship
    public PlayerLevel playerLevel;
    public Score score;
    public float enemyexp = 20;
    public float enemyscore = 20;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip") || collision.gameObject.CompareTag("Base"))
        {
            GameOver();
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            health-=PlayerSC.bulletDamage;
            Debug.Log("can "+ health);
        }
    }

    void Update()
    {
        transform.Translate(0, -2*Time.deltaTime ,0);
        
        if(health <= 0)
        {
            playerLevel.PlayetGetsExp(enemyexp);
            score.AddScore(enemyscore);

            Destroy(gameObject);

        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Gameover");
    }
}
