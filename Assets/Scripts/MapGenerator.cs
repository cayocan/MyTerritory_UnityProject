using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapGenerator : MonoBehaviour {
    public int height;
    public int width;
    [Space(10)]

    public float xOffset = 10;
    public float zOffset = 10;
    [Space(10)]

    public GameObject testTile;


    /*
    public List<GameObject> edgeTile;
    public List<GameObject> cornerTiles;
    public List<GameObject> midTiles;
    */

    const int upperLeftEdge = 0;
    const int upperRightEdge = 90;
    const int bottomLeftEdge = 180;
    const int bottomRightEdge = 270;

    const int upperCorner = 0;
    const int rightCorner = 90;
    const int bottomCorner = 180;
    const int leftCorner = 270;

    Vector3[,] tilesPosition;

    [HideInInspector]
    public UnityEvent OnSetTilesEnd;
    [HideInInspector]
    public UnityEvent OnInstantiateTilesEnd;

    private void Start()//Only for tests.
    {
        SetTilesPosition(height, width);
    }

    void SetTilesPosition(int _height, int _width)
    {
        tilesPosition = new Vector3[_height, _width];
        Vector3 lastPositionAdded = new Vector3(0,0,0);

        for (int h = 0; h < _height; h++)
        {
            //tilesPosition[h] = new List<Vector3>();

            for (int w = 0; w < _width; w++)
            {
                tilesPosition[h, w] = new Vector3(lastPositionAdded.x += xOffset, 0, lastPositionAdded.z);
            }

            lastPositionAdded.x = 0;
            lastPositionAdded.z += zOffset;
        }

        OnSetTilesEnd.Invoke();

        InstantiateTiles(_height, _width);
    }

    void InstantiateTiles(int _height, int _width)
    {       
        for (int h = 0; h < _height; h++)
        {
            for (int w = 0; w < _width; w++)
            {
                Vector3 tilePos = tilesPosition[h, w];

                #region EDGE AND CORNER TESTS

                //EDGE TESTS
                if (h == 0 && w == 0)//Upper left edge.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h == 0 && w == _width - 1)//Upper right edge.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h == _height - 1 && _width == 0)//Bottom left edge.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h == _height - 1 && w == _width - 1)//Bottom right edge.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }

                //CORNER TESTS

                else if (h == 0 && w != 0 && w != _width - 1)//Upper corner.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h != 0 && h != _height - 1 && w == _width - 1)//Right corner.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h == _height - 1 && w != 0 && w != _width -1)//Bottom corner.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                else if (h != 0 && h != _height && w == 0)//Left corner.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }

                //If tilePos is not Edge or Corner.

                else if (true)//Middle standard tile.
                {
                    Instantiate(testTile, tilePos, Quaternion.identity);
                }
                #endregion
            }
        }
        
        OnInstantiateTilesEnd.Invoke();
    }
}
