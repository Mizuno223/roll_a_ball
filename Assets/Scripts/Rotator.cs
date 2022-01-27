using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
       void Update()
    {
        transform.Rotate (new Vector3 (30, 30, 45) * Time.deltaTime);    
    }
}
