using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float playerSpeed;
    public float atis_hizi = 0.30f; // x saniyede bir
    public float bulletDamage;
    [SerializeField]
    GameObject bulletprefab;
    [SerializeField]
    public GameObject spawner;
    

    private Vector3 spawnPoint;
    void Start()
    {   
        
         StartCoroutine(FireBullet());
        
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        transform.Translate(move,0,0);

       

    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            spawnPoint = spawner.transform.position;
            Instantiate(bulletprefab,spawnPoint,Quaternion.identity);
            Debug.Log("aTEŞ");
            yield return new WaitForSeconds(atis_hizi);
        }

    }
    
}
