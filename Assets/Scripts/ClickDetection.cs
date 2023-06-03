using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    // Assign your tilemaps here in inspector
    public Tilemap[] tilemaps;
    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject Ship;
    
    private GameManager gameManager;

    private bool isStartAvailable = false;
    private bool isStartPointAvailable = false;

    private bool isEndAvailable = false;
    private bool isEndPointAvailable = false;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        Ship = GameObject.Find("Ship");
    }

    private void Update()
    {
        if (isStartAvailable == true && Input.GetMouseButtonDown(0)) // 생성 모드일 때, 마우스 왼쪽 버튼 클릭 시
        {
            SpawnStartPoint();
            isStartPointAvailable=true;
            isStartAvailable = false;
        }

        if (isEndAvailable == true && Input.GetMouseButtonDown(0))
        {
            SpawnEndPoint();
            isEndPointAvailable=true;
            isEndAvailable = false;
        }

        

    }



    public void SpawnStartPoint()
    {

        Vector3 clickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (var tilemap in tilemaps)
        {
            // Change it to grid position
            Vector3Int clickCellPosition = tilemap.WorldToCell(clickWorldPosition);

            // Get the tile at the cell position
            TileBase clickedTile = tilemap.GetTile(clickCellPosition);

            if (clickedTile != null)
            {
                if(tilemap.name == "Ocean")
                {
                    Instantiate(StartPoint, clickCellPosition, Quaternion.identity);
                    Ship.transform.position = clickCellPosition;
                    gameManager.startPos = new Vector2Int(clickCellPosition.x, clickCellPosition.y);
                }
                else
                {
                    // Log the tile information
                    Debug.Log("Clicked Tile in Tilemap '" + tilemap.name + "': " + clickedTile.name);
                }
            }
        }
    }

    public void SpawnEndPoint()
    {

        Vector3 clickWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        foreach (var tilemap in tilemaps)
        {
            // Change it to grid position
            Vector3Int clickCellPosition = tilemap.WorldToCell(clickWorldPosition);

            // Get the tile at the cell position
            TileBase clickedTile = tilemap.GetTile(clickCellPosition);

            if (clickedTile != null)
            {
                if (tilemap.name == "Ocean")
                {
                    Instantiate(EndPoint, clickCellPosition, Quaternion.identity);
                    gameManager.targetPos = new Vector2Int(clickCellPosition.x, clickCellPosition.y);
                }
                else
                {
                    // Log the tile information
                    Debug.Log("Clicked Tile in Tilemap '" + tilemap.name + "': " + clickedTile.name);
                }
            }
        }
    }


    public void setStartTrue()
    {
        if(isStartPointAvailable == false)
        {
            isStartAvailable = true;
      
        }
            
    }

    public void setEndTrue()
    {
        if(!isEndPointAvailable)
        {
            isEndAvailable = true;
        }
            
    }



}
