using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipClass : MonoBehaviour
{
  public List<LaunchStage> stages = new List<LaunchStage>();
  public int currentStage = 0;

  // Use this for initialization
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    if(stages.Count > currentStage)
    {
      if(stages[currentStage].stageState == StageState.Finished)
      {
        ++currentStage;
      }
    }
  }

  void Launch()
  {
    LaunchStage stageInst = stages[currentStage];
    stageInst.BeginStage();
  }
}
