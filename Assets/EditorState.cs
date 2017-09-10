using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorState : GameState 
{
  // Use this for initialization
  public override void Start () 
  {
    base.Start();
    Debug.Log("editor");
  }
  
  // Update is called once per frame
  public override void Update () 
  {
    base.Update();
    if(Input.GetKeyDown(KeyCode.Space))
    {
      GameObject world = GameObject.Find("World");
      GameStateManager gsm = world.GetComponent<GameStateManager>();
      gsm.ChangeState(GameStateType.Simulation);
    }
  }

  public override void End()
  {
    base.End();
  }
}
