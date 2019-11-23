using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float[] degrees = {225,135,45,315};

    int rotateIndex = 2;

    [SerializeField]
    float rotateSpeed = 2;

    int rotateTo;

    Transform to;
    // Start is called before the first frame update
    void Start()
    {
      transform.eulerAngles = new Vector3(30,degrees[rotateIndex],0);
    }

   // Update is called once per frame
   int speed = 5;
   void Update(){
       rotateCamera();
       rotating(rotateTo);
   }

   void rotateCamera(){
       if(Input.GetKeyDown(KeyCode.D)){
           if(rotateIndex < 3) rotateIndex++; else rotateIndex = 0;
           rotateTo = rotateIndex + 1;
           if(rotateTo == 4) rotateTo = 0;
           Debug.Log(rotateTo);
           
       }
       else if(Input.GetKeyDown(KeyCode.A)){
           if(rotateIndex < 0) rotateIndex--; else rotateIndex = 3;
           rotateTo = rotateIndex-1;
           if(rotateTo == -1) rotateTo = degrees.Length;
           Debug.Log(rotateTo);
           
           
       }
   }
   void rotating(int b){
       Quaternion from = Quaternion.Euler(30,degrees[b],0);
       transform.rotation = Quaternion.Lerp(transform.rotation,from,rotateSpeed*Time.deltaTime);
   }
}
