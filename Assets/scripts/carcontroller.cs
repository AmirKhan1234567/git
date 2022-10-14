using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public Rigidbody motorRb;
    private float moveInput;
    private float turnInput;
    public float fwdspeed;
    public float revspeed;
    public float turnspeed;
    private bool isgrounded;
    public LayerMask groundlayer;
    public float airDrag;
    public float groundDrag;
    void Start()
    {
        motorRb.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            moveInput *= fwdspeed;
        }
        else
        {
            moveInput *= revspeed;
        }
        float newrotate = turnInput * turnspeed * Time.deltaTime;
        transform.Rotate(0, newrotate, 0, Space.World);
        RaycastHit hit;
        isgrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundlayer);
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.position = motorRb.transform.position;
        if (isgrounded)
        {
            motorRb.drag = groundDrag;
        }
        else
        {
            motorRb.drag = airDrag;
        }
    }
    private void FixedUpdate()
    {
        if (isgrounded)
        {
            motorRb.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            motorRb.AddForce(transform.up* -30f);
        }
    }
}
