using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class spawnmanager : MonoBehaviour
{
    public GameObject[] carprefabs;
    public GameObject prefabs;
    public Transform spawnpoint;
    public TMP_Text label;
    public GameObject clone;
    public static spawnmanager instance;
   
    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        int selectcar = PlayerPrefs.GetInt("Carselected");
          prefabs = carprefabs[selectcar];
         clone = Instantiate(prefabs, spawnpoint.position, Quaternion.Euler(0, 90, 0));
        label.text = prefabs.name;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
