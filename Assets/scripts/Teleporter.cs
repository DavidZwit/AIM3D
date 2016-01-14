using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    private GameObject otherPortal;
    private bool oneWay = false;

    private Teleporter otherPortalHandeler;
    private bool justSpawned = false;

    void Awake()
    {
        if (otherPortal.GetComponent<Teleporter>() != null) oneWay = false;
        else oneWay = true;

        if (!oneWay) otherPortalHandeler = otherPortal.GetComponent<Teleporter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && justSpawned == false)
        {
            if (!oneWay) otherPortalHandeler.spawned = true;
            other.transform.position = otherPortal.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !oneWay)
        {
            justSpawned = false;
        }
    }

    public bool spawned
    {
        get { return justSpawned; }
        set { justSpawned = value; }
    }
}

