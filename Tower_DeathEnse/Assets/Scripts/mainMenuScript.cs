using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jouer()
    {
        SceneManager.LoadScene("towerDefense");
    }
    public void quitter()
    {
        Debug.Log("l'application se ferme !!!");
        Application.Quit();
    }
}