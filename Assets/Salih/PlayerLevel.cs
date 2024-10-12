using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
     public static float  playerexp = 0;
    public static float exptolevelup = 100;
    
    public static float playerLevel = 0;
    public SpaceShip spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel = 0;
        exptolevelup  = 100;
        playerexp = 0;
        Debug.Log("Current Exp: " + playerexp);
    }

    // Update is called once per frame
    void Update()
    {
          if(playerexp>=exptolevelup)
        {
            Debug.Log("level atladi");
            PlayerLevelUp();
        }
    }
    public void PlayetGetsExp(float exp)
    {
        playerexp+=exp;
        Debug.Log("Current Exp: " + playerexp); 
       
    }

    public void PlayerLevelUp()
    {
        exptolevelup = exptolevelup * 1.5f;
        spaceShip.atis_hizi *= 0.8f;
        Debug.Log("atis hizi" + spaceShip.atis_hizi);
        playerLevel++;
        playerexp = 0;
        
       
        

    }
}
