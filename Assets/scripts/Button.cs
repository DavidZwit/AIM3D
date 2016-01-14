using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    [SerializeField]
    private GameObject interactObject;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player") {
            interactObject.SendMessage("DoEvent");
        }
    }
}
