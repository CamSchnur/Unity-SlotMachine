using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        //todo: add slot machine handle that is pulled when spin is pressed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Spin();
        }
    }
    private void Spin()
    {
        foreach (Transform child in this.GetComponentsInChildren<Transform>())
        {
            WheelScript script = child.gameObject.GetComponent<WheelScript>();
            if (script != null)
            {
                script.Spin();
            }
        }
    }
}
