using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorState : GameState 
{
  GameObject EditorUI;
  GameObject World;
  Editor Editor;

  public EditorState () : base () {
    World = GameObject.Find("World");
    Editor = new Editor(World);
    EditorUI = GameObject.Find("EditorUI");
    EditorUI.SetActive(false);
  }

  // Use this for initialization
  public override void Start () 
  {
    base.Start();
    Debug.Log("editor");
    EditorUI.SetActive(true);
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
    EditorUI.SetActive(false);
    base.End();
  }
}
