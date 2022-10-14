using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmovement : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Transform centerOfMass;
    Rigidbody rb;
    bool brake;
    bool reverse;
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;
      
    }
    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
        rb = GetComponent<Rigidbody>();
    }
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
        float localVelocity = transform.InverseTransformDirection(rb.velocity).z + 0.1f;
        reverse = false;
        brake = false;
        if (localVelocity < 0)
        {
            reverse = true;
        }

        if (motor < 0)
        {
            if (localVelocity > 0)
            {
                brake = true;
            }
        }
        else
        {
            if (motor > 0)
            {
                if (localVelocity < 0)
                {
                    brake = true;
                }
            }
        }

    }
    void Update()
    {
        
    }
}
