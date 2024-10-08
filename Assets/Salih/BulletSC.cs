using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSC : MonoBehaviour
{
    public SpaceShip playerSC; //adında değişiklik oldu o yüaden spaceship ama PlayerSC bu
    private float bulletSpeed = 10;
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(transform.position.y>5.20)
        {
            Destroy(gameObject);
        }

        transform.Translate(0, bulletSpeed*Time.deltaTime ,0);
    }
}
