using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageState
{
  Waiting,
  Started,
  Finished
};

public class LaunchStage
{
  public List<ShipPart> parts = new List<ShipPart>();
  public StageState stageState = StageState.Waiting;
  public void BeginStage()
  {
    stageState = StageState.Started;
    foreach(ShipPart p in parts)
    {
      p.Launch();
    }
  }

  public void UpdateStage()
  {
    int partsRunning = 0;
    foreach(ShipPart p in parts)
    {
      if(p.GetState() != StageState.Finished) {
        partsRunning += 1;
      }
    }
    if(partsRunning == 0) 
    {
      stageState = StageState.Finished;
    }
  }

  public void EndStage()
  {
    stageState = StageState.Finished;
    foreach(ShipPart p in parts)
    {
      p.Detach();
    }
  }

  public float ComputeMass()
  {
    float mass = 0.0f;
    foreach(ShipPart p in parts)
    {
      mass += p.GetMass();
    }
    return mass;
  }

  public Vector2 ComputeCenterOfMass()
  {
    Vector2 center = new Vector2();
    foreach(ShipPart p in parts)
    {
      center += p.centerOfMass + (Vector2)p.GetComponent<Transform>().position;
    }
    return center;
  }
}
