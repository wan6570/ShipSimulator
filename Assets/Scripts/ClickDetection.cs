using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickDetection : MonoBehaviour
{
    // Assign your tilemaps here in inspector
    public Tilemap[] tilemaps;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Mouse Button Clicked
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
                    // Log the tile information
                    Debug.Log("Clicked Tile in Tilemap '" + tilemap.name + "': " + clickedTile.name);
                }
            }
        }
    }
}
