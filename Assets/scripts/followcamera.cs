using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour
{
    public Transform followcar;
    public Vector3 offset;
    public float speedfollow;
    public float lookspeed;
   
    public void lookdirection()
    {
        Vector3 _lookdirection = followcar.transform.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookdirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookspeed * Time.deltaTime);
    }
    public void towardsdirection()
    {
        Vector3 direction = followcar.position + followcar.forward * offset.z + followcar.right * offset.x + followcar.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, direction, speedfollow * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        lookdirection();
        towardsdirection();

     
    }
    private void Update()
    {
        followcar = spawnmanager.instance.clone.transform;
    }
}
