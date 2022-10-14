using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carselection : MonoBehaviour
{
    public GameObject[] Car;
    public int Carselected = 0;

    public void nextCar()
    {
        Car[Carselected].SetActive(false);
        Carselected = (Carselected + 1) % Car.Length;
        Car[Carselected].SetActive(true);
    }
    public void previousCar()
    {
        Car[Carselected].SetActive(false);
        Carselected--;
        if (Carselected < 0)
        {
            Carselected += Car.Length;
        }
        Car[Carselected].SetActive(true);
    }
    public void startgame()
    {
        PlayerPrefs.SetInt("Carselected", Carselected);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
