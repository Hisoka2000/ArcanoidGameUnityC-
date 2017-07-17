using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float BallInitalVelocity = 600f;
    private Rigidbody RB;
    private bool BallInPlay;

	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1") && BallInPlay == false)
        {
            transform.parent = null;
            BallInPlay = true;
            RB.isKinematic = false;
            RB.AddForce(new Vector3(BallInitalVelocity, BallInitalVelocity, 0));
        }

	}
}
