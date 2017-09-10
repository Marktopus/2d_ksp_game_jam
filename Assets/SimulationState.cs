using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationState : GameState 
{
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
	}

  public override void End()
  {
    base.End();
  }
}
