using UnityEngine;

public class DestroyAllChildren : MonoBehaviour
{
    
    public GameObject woodenplank;
    public WoodPlankRotate woodPlankRotate;
    public KnifeColliderController knifeColliderController;

    float maxwoodplankscore = 17;
    void Update()
    {
        if (woodPlankRotate.score >= maxwoodplankscore)
        {
            DestroyChildren();
          
            
        }
    }
    public void DestroyChildren()
    {
       
        
            foreach (Transform child in woodenplank.transform)
            {
                Destroy(child.gameObject);
            }
            KnifeColliderController.knifenum = 17;
            maxwoodplankscore+=17;
        

    }
    
}
