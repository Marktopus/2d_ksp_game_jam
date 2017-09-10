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
  GameStateType gameState = GameStateType.MainMenu;
  List<GameState> states = new List<GameState>();
  public Sprite planetSprite;
  public List<GameObject> planets = new List<GameObject>();
  public Vector2 startPos = new Vector2();
  void Start () 
  {
    states.Add(new MenuState());
    states.Add(new EditorState());
    states.Add(new SimulationState());
    states.Add(new EndState());
    states[(int)gameState].Start();


    // generate some planets
    for(int i = 0; i < 10; ++i)
    {
      GameObject newObj = new GameObject();
      float radius = Random.Range(100.0f, 500.0f);
      newObj.transform.localScale = new Vector3(radius, radius, 1.0f);
      newObj.transform.position = 
        new Vector3(
          Random.Range(-10000.0f, 10000.0f), 
          Random.Range(-10000.0f, 10000.0f), 
          0.0f);
      newObj.AddComponent<SpriteRenderer>();
      newObj.GetComponent<SpriteRenderer>().sprite = planetSprite;
      planets.Add(newObj);
    }

    int startingPlanet = Random.Range(0, planets.Count - 1);
    Vector2 startDir = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    startDir.Normalize();
    startPos = (startDir * planets[startingPlanet].transform.localScale.x) + 
                (Vector2)planets[startingPlanet].transform.position;
    GameObject spacePlayer = GameObject.Find("SpacePlayer");
    spacePlayer.transform.localPosition = new Vector3(startPos.x, startPos.y, 0.0f);
    spacePlayer.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Vector2.Angle(new Vector2(0.0f, 1.0f), startDir));
    GameObject spaceObj = GameObject.Find("Space");
    spacePlayer.transform.parent = spaceObj.transform;
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
