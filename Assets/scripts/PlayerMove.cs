using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class PlayerMove : MonoBehaviour {

    
    Rigidbody Rig;
    Vector3 moveDelta;
    Vector3 moveDirection = new Vector3(0, 0, 0);
    [SerializeField]
    float maxInputDelay = 0.5f;
    float inputDelay = 0;
    [SerializeField]
    float maxMoveSpeed;
    float moveSpeed = 0;
    int playerId;

    [SerializeField]
    float maxBoostDuration = 5;
    float boostDuration = 0;
    public float boostPower = 500;

    // Use this for initialization
    void Start () {
        moveSpeed = maxMoveSpeed;
        playerId = int.Parse(gameObject.name);
        Rig = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveDelta = new Vector3(Mathf.Round(XCI.GetAxis(XboxAxis.LeftStickX, playerId)), 0, Mathf.Round(XCI.GetAxis(XboxAxis.LeftStickY, playerId)));

        if (boostDuration > 0 && XCI.GetButton(XboxButton.A, playerId))
        {
            boostDuration -= Time.deltaTime;
            inputDelay = Time.time + maxInputDelay;
            moveSpeed = boostPower;
        }
        else
        {
            if (inputDelay <= Time.time && boostDuration < maxBoostDuration)
                    boostDuration += 0.25f * Time.deltaTime;
            moveSpeed = maxMoveSpeed;
        }

        if (inputDelay <= Time.time)
        {
            if (moveDirection.x == 0 && moveDelta.x != 0 && Physics.OverlapSphere(transform.position + new Vector3(moveDelta.x, 0, 0), 0.45f).Length == 0)
            {
                moveDirection.z = 0;
                moveDirection.x = moveDelta.x;
                inputDelay = Time.time + maxInputDelay;
            }
            else if (moveDirection.z == 0 && moveDelta.z != 0 && Physics.OverlapSphere(transform.position + new Vector3(0, 0, moveDelta.z), 0.45f).Length == 0)
            {
                moveDirection.x = 0;
                moveDirection.z = moveDelta.z;
                inputDelay = Time.time + maxInputDelay;
            }
        }

        Rig.velocity = moveDirection * moveSpeed * Time.deltaTime;
        //CharController.Move(new Vector3(0,0,0));

        Debug.DrawLine(transform.position, transform.position + Rig.velocity, Color.blue);
        Debug.DrawLine(transform.position, transform.position + moveDirection, Color.white);
        Debug.DrawLine(transform.position, transform.position + moveDelta, Color.red);
    }
}
