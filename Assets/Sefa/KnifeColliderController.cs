using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KnifeColliderController : MonoBehaviour
{
    [SerializeField] private GameObject LostFragments;
    
    private bool forOnce = true;
    public float forceAmount;

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject KnifePrefab;
    
    [SerializeField] private Transform woodPlank;
    [SerializeField] private Rigidbody2D _knifeRb;

    //salih:

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private WoodPlankRotate woodPlankrotate;
    [SerializeField] private RecordScript recordScript;
    [SerializeField] private TextMeshProUGUI recordText;

    private void Start()
    {
        Time.timeScale = 1;

        recordScript.record = PlayerPrefs.GetInt("HighScore", 0); 
        recordText.text = recordScript.record.ToString();
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

            woodPlankrotate.score++;
            scoreText.text = woodPlankrotate.score.ToString();
            Debug.Log(woodPlankrotate.score);
        }

        if (other.gameObject.CompareTag("Knife"))
        {
            Time.timeScale = 0;
            LostFragments.SetActive(true);

            if (woodPlankrotate.score > recordScript.record)
            {
                recordScript.record = woodPlankrotate.score;
                PlayerPrefs.SetInt("HighScore", recordScript.record); // Rekoru kaydet
                PlayerPrefs.Save(); // PlayerPrefs'i kaydet
                recordText.text = recordScript.record.ToString();
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && forOnce)
        {
            _knifeRb.AddForce(Vector2.up.normalized * forceAmount,ForceMode2D.Impulse);
        }
        scoreText.text = woodPlankrotate.score.ToString();
        recordText.text = recordScript.record.ToString();
    }
}
