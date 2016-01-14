using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour
{
    Vector2 gridSize = new Vector2(20, 12);
    Vector2 gridBegin = new Vector2(0, 0);
    Vector2 steps = new Vector2(1, 1);
    [SerializeField]
    BoxCollider gridBlock;
    int distanceBetween;

    void Start()
    {
        for (float x = gridBegin.x; x < gridSize.x; x += steps.x)
        {
            for (float y = gridBegin.y; y < gridSize.y; y += steps.y)
            {
                Instantiate(gridBlock, new Vector3(x+0.5f, 0, y+0.5f), Quaternion.identity);
            }
        }
    }
}
