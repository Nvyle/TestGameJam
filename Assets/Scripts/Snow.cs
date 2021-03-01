using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public float speedMov;
    public float speedRot;
    public float timeDestroy;

    public Transform snowBall;

    void Start() 
    {
        Destroy(gameObject, timeDestroy);
    }
    
     void Update() 
    {
        transform.Translate(Vector3.right * speedMov * Time.deltaTime);

        snowBall.transform.Rotate(Vector3.forward * speedRot * Time.deltaTime);
    }

}
