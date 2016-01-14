using UnityEngine;
using System.Collections;

public class MovableWall : MonoBehaviour {
    private bool goingBack;
    private Vector3 begin, end;
    [SerializeField]
    private float moveSpeed = 0.1f;

    void Awake()
    {
        begin = transform.Find("Begin").position;
        end = transform.Find("End").position;
    }

	void DoEvent() {
        if (!goingBack) {
            goingBack = true;
            StopCoroutine("MoveTo");
            StartCoroutine("MoveTo", end);
        } else {
            goingBack = false;
            StopCoroutine("MoveTo");
            StartCoroutine("MoveTo", begin);
        }
    }

    IEnumerator MoveTo (Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0) {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
            yield return null;
        }
    }
}
