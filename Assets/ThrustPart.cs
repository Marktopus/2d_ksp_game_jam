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
      Debug.Log("butts");
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

      Vector3 toRotate = gameObject.transform.position - player.transform.position;


      GameStateManager gsm = GameObject.Find("World").GetComponent<GameStateManager>();
      GameObject spacePlayer = GameObject.Find("SpacePlayer");
      Rigidbody2D spaceBody = spacePlayer.GetComponent<Rigidbody2D>();
      Vector3 playerRot = player.transform.localEulerAngles;
      Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, player.transform.localEulerAngles.z - spacePlayer.transform.localEulerAngles.z);

      toRotate = rotation * toRotate;
      newForce = rotation * newForce;

      
      spaceBody.AddForceAtPosition(newForce * 0.01f, spaceBody.transform.position + toRotate);
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
