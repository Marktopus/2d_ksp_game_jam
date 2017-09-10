using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationState : GameState 
{
  public float planetRad = 300.0f;
  public Vector2 planetPosition = new Vector2();
	// Use this for initialization
	public override void Start () 
  {
    base.Start();
    GameObject ship = GameObject.Find("Player");
    ShipClass shipComp = ship.GetComponent<ShipClass>();
    LaunchStage newStage = new LaunchStage();
    List<ShipPart> partList = newStage.parts;
    ShipPart part = (ShipPart)ship.GetComponent<CabinPart>();
    if(part) 
    {
      partList.Add(part);
    }
    GameObject engineObj = GameObject.Find("Engine");
    part = engineObj.GetComponent<ShipPart>();
    if(part) 
    {
      partList.Add(part);
    }
    GameObject fuelObj = GameObject.Find("FuelTank");
    part = fuelObj.GetComponent<ShipPart>();
    if(part) 
    {
      partList.Add(part);
    }
    shipComp.stages.Add(newStage);
    Debug.Log("sim");

    planetPosition.x = Random.Range(-10000.0f, 10000.0f);
    planetPosition.y = Random.Range(-10000.0f, 10000.0f);

    
	}
	
	// Update is called once per frame
	public override void Update () 
  {
    base.Update();
    if(Input.GetKeyDown(KeyCode.Space))
    {
      GameObject player = GameObject.Find("Player");
      player.GetComponent<ShipClass>().Launch();
      Debug.Log("launch");
    }

    GameObject spacePlayer = GameObject.Find("SpacePlayer");
    GameObject spaceCamObj = GameObject.Find("SpaceCamera");
    Camera spaceCam = spaceCamObj.GetComponent<Camera>();
    float scale = spaceCam.orthographicSize * 0.025f;
    spacePlayer.transform.localScale = new Vector3(scale, scale, 1.0f);
	}

  public override void End()
  {
    base.End();
  }
}
