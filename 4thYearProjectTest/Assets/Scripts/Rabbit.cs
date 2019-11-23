using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
   public float hunger;

    [SerializeField]
    //how much do we want to decrease his hunger level each step
    float hungerStep;
    void Start()
    {
        hunger = 100f;
        hungerStep = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hunger > 0) hunger -= hungerStep;
    }
}
