using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speedX = 0f;
    private float speedY = 0.5f;
    private float speedZ = 0f;

    void Update()
    {
        transform.Rotate(360 * speedX * Time.deltaTime, 
            360 * speedY * Time.deltaTime, 
            360 * speedZ * Time.deltaTime);
    }
}
