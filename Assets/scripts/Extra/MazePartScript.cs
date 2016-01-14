using UnityEngine;
using System.Collections;

public class MazePartScript : MonoBehaviour {

    [SerializeField]
    private int[] gaps;

    public int[] Gaps
    {
        get { return gaps; }
        set { gaps = value; }
    }
}
