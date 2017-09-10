using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStateType
{
  MainMenu,
  Editor,
  Simulation,
  End
}
public class GameStateManager : MonoBehaviour 
{
  public GameStateType gameState = GameStateType.MainMenu;
  public List<GameState> states = new List<GameState>();
  void Start () 
  {
    states.Add(new MenuState());
    states.Add(new EditorState());
    states.Add(new SimulationState());
    states.Add(new EndState());
    states[(int)gameState].Start();


    // generate some planets
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
