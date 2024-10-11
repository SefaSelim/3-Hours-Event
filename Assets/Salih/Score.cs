using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static float score = 0;
    public TextMeshProUGUI scoretext;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score : " + score;
    }

    public void AddScore(float addingscore){
        score += addingscore; 
    }
}
