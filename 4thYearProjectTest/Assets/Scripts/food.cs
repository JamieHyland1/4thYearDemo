using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    Vector3 tempPos;

    public float amplitude = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
       // transform.position = new Vector3(0,1,0);
        tempPos = new Vector3();
        amplitude = 0.009f;
    }

    // Update is called once per frame
    
    void Update()
    {
    //This will make the food float and rotate along a sin wave, its not really useful,
    // but play with it if you want to get a better of how rotations and stuff work if you want

    //    tempPos = transform.position;
    //    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI) * amplitude;
    //    transform.position += tempPos;
    }

   
}
