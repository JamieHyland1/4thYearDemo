using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDemo : MonoBehaviour
{
     public float searchRadius;

   [SerializeField]
    float xRad;

    [SerializeField]
    float yRad;
    LineRenderer line;

   [SerializeField]
   int numSegments;

    // Start is called before the first frame update
    void Start()
    {
       line = GetComponent<LineRenderer>();
       line.positionCount = (numSegments+1);
       line.useWorldSpace = false;
       createPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createPoints(){
      float x = 0;
      float y = 0;
      float z = 0f;
      float angle = 20f;
      for(int i =0; i < (numSegments + 1); i++){

         x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRad;
         y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRad;
         line.SetPosition(i,new Vector3(x,y,z));
         angle += (numSegments/360f);

      }
    }
}
