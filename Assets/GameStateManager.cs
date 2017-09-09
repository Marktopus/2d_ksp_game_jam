using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStateType
{
  MainMenu,
  Editor,
  Game,
  End
}
public class GameStateManager : MonoBehaviour 
{
  GameStateType gameState = GameStateType.Editor;
  List<GameState> states; 
	void Start () 
  {
	}
	
	// Update is called once per frame
	void Update () 
  {
    states[(int)gameState].Update();
	}

  public void ChangeState(GameStateType newState)
  {
    states[(int)gameState].End();
    gameState = newState;
    states[(int)gameState].Start();
  }
}
