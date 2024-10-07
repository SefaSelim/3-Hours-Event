using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeColliderController : MonoBehaviour
{
    [SerializeField] private GameObject LostFragments;
    
    private bool forOnce = true;
    public float forceAmount;

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject KnifePrefab;
    
    [SerializeField] private Transform woodPlank;
    [SerializeField] private Rigidbody2D _knifeRb;

    private void Start()
    {
        Time.timeScale = 1;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("WoodPlank") && forOnce)
        {
            transform.SetParent(woodPlank);
            //_knifeRb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            GameObject newKnife = Instantiate(KnifePrefab, spawnLocation.position, spawnLocation.rotation);
            newKnife.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            forOnce = false;
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            Time.timeScale = 0;
            LostFragments.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && forOnce)
        {
            _knifeRb.AddForce(Vector2.up.normalized * forceAmount,ForceMode2D.Impulse);
        }
    }
}
