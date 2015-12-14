using UnityEngine;
using System.Collections;

public class MapGenarator : MonoBehaviour {

    [SerializeField]
    private GameObject[] chunks;
    [SerializeField]
    private Vector2 mapSize;

    private GameObject[,] chunckGrid = new GameObject[20, 20];
    private int chunckSizes = 4;

    void Start()
    {
        chunckGrid[10, 10] = Instantiate(chunks[Random.Range(0, chunks.Length)], new Vector3(10 * chunckSizes, 0, 10 * chunckSizes), Quaternion.identity) as GameObject;

        GenerateChuncsAroundChunck(chunckGrid[10, 10]);        
    }

    void createChunck(Vector2 chunckPos)
    {

    }

    void GenerateChuncsAroundChunck(GameObject chunck)
    {
        MazePartScript lastChunckScript = chunck.GetComponent<MazePartScript>();

        if (chunck != chunks[0]) { 
            //The checking for the 4 sides
            for (int i = 0; i < 4; i++)
            {
                Vector2 offset = Vector2.zero;
                if (i == 0) offset.x = -1; else if (i == 1) offset.y = -1;
                else if (i == 2) offset.x = 1; else if (i == 3) offset.y = 1;

                //Checking the new position the chunck needs to be put in in the chunck array
                Vector2 newChunckPos = new Vector3((chunck.transform.position.x / chunckSizes) + offset.x,
                    (chunck.transform.position.z / chunckSizes) + offset.y);

                if (newChunckPos.x > -1 && newChunckPos.y > -1 && !chunckGrid[(int)newChunckPos.x, (int)newChunckPos.y]) {

                    //Looping through all the chuncks to find one good
                    for (int o = 1; o < chunks.Length; o++)
                    {
                        //Finding the opisite side to check the other chunck
                        int checkSide = 4;
                        if (i < 2) checkSide = i + 2;
                        else if (i > 1) checkSide = i - 2;

                        //Checking if it fits
                        if (chunks[o] != chunck && lastChunckScript.Gaps[i] != 0 && 
                            lastChunckScript.Gaps[i] == chunks[o].GetComponent<MazePartScript>().Gaps[checkSide])
                        {
                            chunckGrid[(int)newChunckPos.x, (int) newChunckPos.y] = 
                            Instantiate(chunks[o], spawnPos(i, chunck), Quaternion.identity) as GameObject;
                            break;
                        } else if (o == chunks.Length - 1) {
                            chunckGrid[(int)newChunckPos.x, (int)newChunckPos.y] =
                            Instantiate(chunks[0], spawnPos(i, chunck), Quaternion.identity) as GameObject;
                        }
                    }
                }
            }
        } else {

        }
    }

    Vector3 spawnPos(int side, GameObject chunck)
    {
        Vector3 spawnPos = chunck.transform.position;

        if (side == 0) spawnPos.x -= chunckSizes;
        else if (side == 1) spawnPos.z -= chunckSizes;
        else if (side == 2) spawnPos.x += chunckSizes;
        else if (side == 3) spawnPos.z += chunckSizes;

        return spawnPos;
    }
}
