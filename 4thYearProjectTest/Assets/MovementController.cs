using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    int speed;

    [SerializeField]
    int moveSpeed;

    [SerializeField]
    int searchRadius;

    Quaternion direction;

    Vector3 moveTo;

    int moveCountdown = 240;

    bool rotating = false;

    bool moving = true;

     Collider[] nearbyFood; 

    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("hi");
    }

    // Update is called once per frame
    void Update()
    {
        moveCountdown --;
        if(moveCountdown == 0){
           newDirection();
        }else{
            if(rotating) rotate();
            if(moving) movement();
        }
        nearbyFood = Physics.OverlapSphere(transform.position, searchRadius);  
        Vector3 nearestFood = new Vector3(99999,99999,99999);
        for(int i = 0; i < nearbyFood.Length; i++){
            if(nearbyFood[i].tag == "Food"){
                Vector3 foodPos = nearbyFood[i].gameObject.transform.position;
               if(Vector3.Distance(transform.position,foodPos) < Vector3.Distance(transform.position,nearestFood)){
                   nearestFood = foodPos;
               }
           }
        }
    }
    void rotate(){
        transform.rotation = Quaternion.RotateTowards(transform.rotation,direction,speed*Time.deltaTime);
        if(transform.rotation == direction){
            rotating = false; 
            moving = true;
            moveTo = transform.forward*5; 
            moveTo += new Vector3(0,0.5f,0);
        } 
    }
    void movement(){
       float step = moveSpeed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position,moveTo,step);
       if(Vector3.Distance(transform.position, moveTo) < 0.1f){
           moving = false;
           moveCountdown = 240;
       }
    }

    void newDirection(){
        direction =  Quaternion.AngleAxis(Random.Range(0,360), Vector3.up);
        rotating = true;
    }

    void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
    }

}
