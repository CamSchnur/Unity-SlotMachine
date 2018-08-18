using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour {


    private float spinSpeed = 50;
    private Rigidbody wheelBody;
    private float rotDegrees;
    private int rotDegreesNormalized;

    private Material faceGreen;
    private Material faceYellow;
    private Material faceRed;

	// Use this for initialization
	void Start ()
    {
        rotDegrees = 0.0f;
        wheelBody = GetComponent<Rigidbody>();

        
        faceRed = Resources.Load("wheelSurface", typeof(Material)) as Material;
        faceYellow = Resources.Load("wheelSurfaceYellow", typeof(Material)) as Material;
        faceGreen = Resources.Load("wheelSurfaceGreen", typeof(Material)) as Material;
    }

	
	// Update is called once per frame
	void Update ()
    {
        //   Spin();
        AdjustSpin();
	}

    private void FixedUpdate()
    {
       
    }

    private List<GameObject> GetFaces()
    {
        List<GameObject> faces = new List<GameObject>();
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.CompareTag("face"))
            {
                faces.Add(child.gameObject);
            }
        }
        return faces;
    }
    /// <summary>
    /// while wheel is spinning, increase/decrease angular drag to get it to stop nearer a face
    /// </summary>
    private void AdjustSpin()
    {
        rotDegrees = wheelBody.transform.eulerAngles.x;
        //shows face at ~0, ~45, ~90, etc
        rotDegreesNormalized = (int)rotDegrees % 45;
        if (/*rotDegreesNormalized < 5 ||*/ rotDegreesNormalized > 40)
        {
            wheelBody.angularDrag = 2.5f;
            //within 5 degrees of showing a face, let's slow it down.
            SetMaterial(faceRed);

        }
        else if (/*rotDegreesNormalized < 15 ||*/ rotDegreesNormalized > 30)
        {
            //closer but not quite there

            wheelBody.angularDrag = 1.87f;
            SetMaterial(faceYellow);
        }
        else
        {
            //should spin faster
            wheelBody.angularDrag = 0.4f;
            SetMaterial(faceGreen);
        }

    }

    private void SetMaterial(Material m)
    {
        foreach (GameObject go in GetFaces())
        {
            go.GetComponent<Renderer>().material = m;
        }
    }

    public void Spin()
    {
        //roughly 20-50 is a good value for torque
        spinSpeed = (-1.0f) * ((Random.value * 30.0f) + 20.0f);

        wheelBody.AddTorque(spinSpeed, 0, 0);

        //maybe should cook my own rotation rather than use AddTorque so that I can make the wheels stop in a more-centered fashion?

      // wheelBody.transform.Rotate(0)

    }
}
