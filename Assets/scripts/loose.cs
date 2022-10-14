using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loose : MonoBehaviour
{
    public GameObject youloosepanel;

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("enemy"))
            Debug.Log("collided");
        youloosepanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        
    }
}
