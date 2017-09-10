using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustPart : ShipPart 
{
  public List<FuelPart> fuelParts = new List<FuelPart>();
  public float consumptionRate;
  public float massToForce;
	// Use this for initialization
	public override void Start () 
  {
    base.Start();	
	}
	
	// Update is called once per frame
	public override void Update () 
  {
    if(partState == StageState.Started)
    {
      base.Update();
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

      newForce = gameObject.transform.TransformVector(newForce);
      body.AddForceAtPosition(newForce, gameObject.transform.position);
    }
	}

  public override float GetMass()
  {
    float curMass = mass;
    foreach(FuelPart p in fuelParts)
    {
      curMass += p.fuelMass + p.mass;
    }
    return curMass;
  }
}
