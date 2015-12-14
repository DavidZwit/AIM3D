using UnityEngine;
using XboxCtrlrInput;
using System.Collections;
using System.Collections.Generic;

public class ControllerCounter : MonoBehaviour {
    public int ControllerCount;
    [SerializeField]
    private GameObject player;
    private int jLength;

    void Update()
    {

        jLength = XCI.GetNumPluggedCtrlrs();

        if (ControllerCount < jLength)
        {
            ControllerCount ++;
            GameObject newPlayer = Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject;

            if (!GameObject.Find("1")) newPlayer.name = "1";
            else if (!GameObject.Find("2")) newPlayer.name = "2";
            else if (!GameObject.Find("3")) newPlayer.name = "3";
            else if (!GameObject.Find("4")) newPlayer.name = "4";

            print("new controller conected");
        } else if (ControllerCount > jLength) {

            print("controler disconected");
            ControllerCount--;
        }
    }
}
