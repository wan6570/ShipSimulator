using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float delay = 0.5f;

    public List<Vector2> direction;

    GameObject simulatorManager;
    int NodeNum; 

    // Start is called before the first frame update
    void Start()
    {
        simulatorManager = GameObject.Find("SimulatorManager");

        
    }

    // Update is called once per frame


    void DebugMove()
    {
        Debug.Log("Move");
    }
}
