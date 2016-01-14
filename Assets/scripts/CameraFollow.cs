using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    float extraCameraSize;

    private GameObject[] actors;
    private Vector3 distanceFromZero;

    void Update()
    {
        //Finding the actors
        actors = GameObject.FindGameObjectsWithTag("Player");

        if (actors.Length > 0) CalculateCamPos(actors, offset);
    }

    void CalculateCamPos(GameObject[] actors, Vector3 offset)
    {
        //Setting the highest distance to the first one
        Vector3 highestPos = actors[0].transform.position;
        Vector3 lowestPos = actors[0].transform.position;

        for (var i = 0; i < actors.Length; i++)
        {
            //Adding all the distancese
            distanceFromZero += actors[i].transform.position;

            if (actors[i].transform.position.x > highestPos.x) highestPos.x = actors[i].transform.position.x;
            if (actors[i].transform.position.x < lowestPos.x) lowestPos.x = actors[i].transform.position.x;
            if (actors[i].transform.position.y > highestPos.y) highestPos.y = actors[i].transform.position.y;
            if (actors[i].transform.position.y < lowestPos.y) lowestPos.y = actors[i].transform.position.y;
            if (actors[i].transform.position.z > highestPos.z) highestPos.z = actors[i].transform.position.z;
            if (actors[i].transform.position.z < lowestPos.z) lowestPos.z = actors[i].transform.position.z;
        }
        //Dividing the distances by the amound of objects
        distanceFromZero /= actors.Length + 1;

        Vector3 HighesLowestPoints = highestPos - lowestPos;
        float distanceLowHigh = Mathf.Sqrt(HighesLowestPoints.x * HighesLowestPoints.x +
            HighesLowestPoints.z * HighesLowestPoints.z);

        //Applying the transformations
        transform.position = new Vector3(distanceFromZero.x, 10, distanceFromZero.z) + offset;

        

        if (Mathf.Abs(distanceLowHigh) > 0) Camera.main.orthographicSize = Mathf.Abs(distanceLowHigh + extraCameraSize) / 1.8f;
    }
}