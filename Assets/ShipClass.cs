using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
  public List<LaunchStage> stages = new List<LaunchStage>();
  public int currentStage = -1;
  public float throttle = 0.0f;
  // Use this for initialization
  void Start()
  {
    
  }
  
  // Update is called once per frame
  void Update()
  {
    if(currentStage >= 0)
    {
      for(int i = currentStage; i < stages.Count; ++i)
      {
        stages[i].UpdateStage();
      }
    }
    ComputeMass();
    if(stages.Count > currentStage)
    {
      if(stages[currentStage].stageState == StageState.Finished)
      {
        ++currentStage;
      }
    }
  }

  void ComputeMass()
  {
    Rigidbody2D body = GetComponent<Rigidbody2D>();
    body.mass = 0;
    foreach(LaunchStage stage in stages)
    {
      body.mass += stage.ComputeMass();
    }
  }

  public void Launch()
  {
    currentStage = stages.Count - 1;
    LaunchStage stageInst = stages[currentStage];
    stageInst.BeginStage();
  }
}
