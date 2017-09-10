using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustPart : ShipPart 
{
  List<FuelPart> fuelParts = new List<FuelPart>();
  public float consumptionRate;
  public float massToForce;
	// Use this for initialization
	void Start () 
  {
		
	}
	
	// Update is called once per frame
	void Update () 
  {
    float consumed = 0.0f;
	  foreach(FuelPart part in fuelParts)	
    {
      if(part.fuelMass >= 0.0f) 
      {
        consumed = Mathf.Max(consumptionRate * Time.deltaTime, 0.0f);
        part.fuelMass -= consumed;
        break;
      }
    }
    GameObject player = GameObject.Find("Player");
    Rigidbody2D body = player.GetComponent<Rigidbody2D>();
    Vector2 newForce = new Vector2(0, massToForce * consumed);
    Debug.Log(newForce);
    body.AddForceAtPosition(newForce, gameObject.GetComponent<Transform>().position);
	}

  public double GetTotalMass()
  {
    double curMass = mass;
    foreach(FuelPart p in fuelParts)
    {
      curMass += p.fuelMass + p.mass;
    }
    return curMass;
  }
}
