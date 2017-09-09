using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysicsContoller : MonoBehaviour {
	private Rigidbody2D parentBody;

	public float throttle = 0;

	public float wetMass = 1;
	public float dryMass = 1;
	public float wetMassConsumptionRate = 0.01f;
	public float maxForcePerUpate = 1f;

	// Use this for initialization
	public void Start () {
		parentBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		float massDelt = wetMassConsumptionRate * throttle;
		float updateForce = maxForcePerUpate * throttle;

		wetMass = Math.Max(0, wetMass - massDelt);

		parentBody.AddRelativeForce(new Vector2(0, updateForce));
	}
}
