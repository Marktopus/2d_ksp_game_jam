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
  public StageState partState;
  public float mass;
  public Vector2 centerOfMass;
  public List<ShipPart> connectingParts;
	// Use this for initialization
	public virtual void Start () 
  {
		
	}
	
	// Update is called once per frame
	public virtual void Update () 
  {
    // at some point we'll get to end state here		
    if(partState == StageState.Started)
    {
      // do things i guess
    }
	}

  public virtual StageState GetState()
  {
    return partState;
  }
  
  public virtual void Launch()
  {
    partState = StageState.Started;
  }

  public virtual void Detach()
  {
    partState = StageState.Finished;
  }

  public virtual float GetMass()
  {
    return mass;
  }
}
