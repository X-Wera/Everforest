using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilemapScript : MonoBehaviour
{

    void Start()
    {
        int i = 0;
        int colunms = 0;
        int rows = 0;
        string xxx = "";
        Tilemap tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    xxx += ("x:" + x + " y:" + y + " tile:" + tile.name + System.Environment.NewLine);
                    i++;
                    colunms = x;
                    rows = y;
                }
            }
        }
        print(xxx);
        print("Total Tiles = " + i);
        print("Total Colunms = " + colunms);
        print("Total Rows = " + rows);
    }
}
