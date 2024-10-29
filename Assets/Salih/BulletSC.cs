using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSC : MonoBehaviour
{
    public SpaceShip playerSC; //adında değişiklik oldu o yüaden spaceship ama PlayerSC bu
    public float bulletSpeed;
    public Animator Animator;

    private bool ok = true;
    
    void destroygameobject()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Animator.Play("BulletAnim");
            ok = false;
            Invoke("destroygameobject",1f);
        }
    }
    void Update()
    {
        if(transform.position.y>5.20)
        {
            Destroy(gameObject);
        }

        if (ok)
        {
            transform.Translate(0, bulletSpeed*Time.deltaTime ,0);
        }
      
    }
}
