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
        //roughly 20-50 is a good value for torque
        spinSpeed = (Random.value * 30.0f) + 20.0f;

        wheelBody.AddTorque(spinSpeed, 0, 0);

        //maybe should cook my own rotation rather than use AddTorque so that I can make the wheels stop in a more-centered fashion?

      // wheelBody.transform.Rotate(0)

    }
}
