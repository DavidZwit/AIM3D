using UnityEngine;
using System.Collections;

public class fireWork : MonoBehaviour {

    private float flySpeed = 0.2f;
    private int activationHeight = 20;
    private int SparkleArmound = 500;
    [SerializeField]
    private GameObject Sparkles;

	void Update () {
        if (transform.position.y < activationHeight) transform.position += new Vector3(0, flySpeed, 0);
        else {
            for (int i = 0; i < SparkleArmound; i ++) {
                Instantiate(Sparkles, transform.position, Random.rotation);
            }
            Destroy(gameObject);
        }
	}
}
