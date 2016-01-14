using UnityEngine;
using System.Collections;

public class FireWorkSarkle : MonoBehaviour {

    private MeshRenderer meshRenderer;
    private float speed = 1f;
    private float duration = 200;
    private Rigidbody rb;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    void FixedUpdate() {
        duration--;

        if (duration > 0) rb.transform.Translate(Vector3.down * Time.deltaTime * speed);
        else Destroy(gameObject);
    }
}
