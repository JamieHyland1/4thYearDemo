using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    int speed;

    [SerializeField]
    float hunger;

    [SerializeField]
    float hungerStep;

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
      hunger = 100;
      hungerStep = 0.01f;
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
       hunger -= hungerStep;
       if(hunger < 40f) checkForFood();
    }
    void rotate(){
        if(hunger > 40f){ 
            transform.rotation = Quaternion.RotateTowards(transform.rotation,direction,speed*Time.deltaTime);
            if(transform.rotation == direction){
                rotating = false; 
                moving = true;
                moveTo = transform.forward*5; 
                moveTo += new Vector3(0,0.5f,0);
            } 
        }
    }

    //Check agents current surroundings for food
    void checkForFood(){
        nearbyFood = Physics.OverlapSphere(transform.position, searchRadius);  
        Vector3 nearestFood = new Vector3(99999,99999,99999);
        for(int i = 0; i < nearbyFood.Length; i++){
            if(nearbyFood[i].tag == "Food"){
                Vector3 foodPos = nearbyFood[i].gameObject.transform.position;
               if(Vector3.Distance(transform.position,foodPos) < Vector3.Distance(transform.position,nearestFood)){
                   nearestFood = foodPos;
                   if(hunger < 40f) moveTo = nearestFood;
               }
           }
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
        hunger += 10f;
        Debug.Log("Just ate some food, now heres my hunger level: " + hunger);
    }

}
