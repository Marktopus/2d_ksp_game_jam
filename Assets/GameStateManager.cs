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
    for(int i = 0; i < 1; ++i)
    {
      GameObject newObj = new GameObject();
      float radius = Random.Range(100.0f, 1000.0f);
      newObj.transform.localScale = new Vector3(radius * 2.0f, radius * 2.0f, 1.0f);
      newObj.transform.position = 
        new Vector3(
          Random.Range(-100000.0f, 100000.0f), 
          Random.Range(-100000.0f, 100000.0f), 
          -41.0f);

      newObj.AddComponent<SpriteRenderer>().sprite = planetSprite;
      Rigidbody2D body = newObj.AddComponent<Rigidbody2D>();
      CircleCollider2D collider = newObj.AddComponent<CircleCollider2D>();
      collider.radius = 1.0f;

      float density = 200.0f;
      body.gravityScale = 0.0f;
      body.mass = density * Mathf.PI * radius * radius;
      planets.Add(newObj);
    }

    int startingPlanet = Random.Range(0, planets.Count - 1);
    Vector2 startDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    startDir.Normalize();
    startPos = (startDir * (planets[startingPlanet].transform.localScale.x + 4.0f)) + 
                (Vector2)planets[startingPlanet].transform.position;
    GameObject player = GameObject.Find("Player");
    player.transform.localPosition = new Vector3(startPos.x, startPos.y, player.transform.position.z);
    player.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(new Vector2(0.0f, 1.0f), startDir));

    GameObject farCam = GameObject.Find("Main Camera");
    farCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, farCam.transform.position.z);
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
