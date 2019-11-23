using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    //This allows us to change what item we want to spawn, realistically Shouldve just named this script spawner for 
    //reusability, if you look in the inspector you can drag different type of game objects into the script to spawn those

     public GameObject myPrefab;

    //This is the same as with the prefab the [SerializeField] Attribute just allows us to set the value of how much
    //Food we spawn, probably better practice as having public variables is a no no, I just wanted to show off the diff ways
    // to do it
    
    [SerializeField]
    int numOfFood = 10;
    // Start is called before the first frame update
    void Start()
    {
        //We only want to spawn food along the x,z axis to make sure they're all level with each other
        for(int i = 0; i < numOfFood; i++){
            float x = Random.Range(-20,20);
            float z = Random.Range(-20,20);
            Instantiate(myPrefab,new Vector3(x,0.5f,z), Quaternion.identity);
        }
    }
}
