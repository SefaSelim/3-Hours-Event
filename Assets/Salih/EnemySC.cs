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

    public GameObject restartScene;

    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
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
            Vector2 force = new Vector2(0f, 0.1f);
            _rigidbody2D.AddForce(force,ForceMode2D.Impulse);
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
        Instantiate(restartScene, Vector3.zero, Quaternion.Euler(restartScene.transform.eulerAngles));
        Invoke("time",0.5f);
        Debug.Log("Gameover");
    }

    void time()
    {
        Time.timeScale = 0;
    }

}
