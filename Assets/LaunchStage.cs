using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageState
{
  Waiting,
  Started,
  Finished
};

public class LaunchStage : MonoBehaviour
{
  public List<ShipPart> parts;
  public StageState stageState = StageState.Waiting;
  public void Start(){ }
  public void Update(){ }
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
}
