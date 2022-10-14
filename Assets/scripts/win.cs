using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class win : MonoBehaviour
{
    public GameObject youwinpanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            Debug.Log("collided");
            youwinpanel.SetActive(true);
            Time.timeScale = 0f;
          
        }
    }
}