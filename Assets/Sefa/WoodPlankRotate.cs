using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlankRotate : MonoBehaviour
{
    public float RotationSpeed;
    void Update()
    {
       transform.Rotate(0,0,RotationSpeed * Time.deltaTime);
    }
}
