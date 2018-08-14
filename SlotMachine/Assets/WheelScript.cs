using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour {


    private float spinSpeed = 40;
    private Rigidbody wheelBody;
    private float rotDegrees;
	// Use this for initialization
	void Start ()
    {
        rotDegrees = 0.0f;
        wheelBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
     //   Spin();
	}

    private void FixedUpdate()
    {
       
    }
    public void Spin()
    {
        //roughly 30-50 is a good value for torque
        spinSpeed = (Random.value * 20) + 30;

        wheelBody.AddTorque(spinSpeed, 0, 0);
      // wheelBody.transform.Rotate(0)

    }
}
