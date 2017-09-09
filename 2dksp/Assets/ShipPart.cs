using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
  Cabin,
  Booster,
  CargoHold,
  Engine,
  Stager

}

public class ShipPart : MonoBehaviour 
{
  StageState partState;
  public double weight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
  {
    // at some point we'll get to end state here		
	}

  public virtual StageState GetState()
  {
    return partState;
  }

  public void Launch()
  {

  }
}
