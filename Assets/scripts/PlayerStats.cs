using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    private int balloons;

    public int Balloons
    {
        get { return balloons; }
        set { balloons = value; }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            Balloons--;
        }
    }
}
