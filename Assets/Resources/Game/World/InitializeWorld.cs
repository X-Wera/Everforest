using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeWorld : MonoBehaviour
{
    public Grid grid;
    //public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        initGrid();
        createHub();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void initGrid()
    {
        grid = new GameObject("Grid").AddComponent<Grid>();
        //var tilemap = new GameObject("Tilemap").AddComponent<Tilemap>();
        //tilemap.transform.SetParent(grid.gameObject);
    }

    void createHub()
    {

    }
}
