using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPhysicsController : MonoBehaviour {
	private Rigidbody2D parentBody;

	public float throttle = 0;

	public float wetMass = 0.1f;
	public float dryMass = 0.1f;
	public float wetMassConsumptionRate = 0.001f;
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
		parentBody.mass = wetMass + dryMass;

		if (wetMass > 0) {
			parentBody.AddRelativeForce(new Vector2(0, updateForce));
		}
	}

	public void SetThrottle (float throttle) {
		this.throttle = throttle;
	}
}
