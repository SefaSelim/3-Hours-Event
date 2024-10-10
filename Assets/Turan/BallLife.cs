using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLife : MonoBehaviour
{
    public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.CompareTag("hitcollider"))
      {
        
        Debug.Log("Game over");
        Time.timeScale = 0;

      }
    }
}
