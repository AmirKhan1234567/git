using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathmovement : MonoBehaviour
{
    public Transform[] targetpoint;
    public float speed;
    private int current;
    void Start()
    {
    }
    void Update()
    {

        if (transform.position != targetpoint[current].position)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, targetpoint[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(position);
        }
        else current = (current + 1);
    }
}
