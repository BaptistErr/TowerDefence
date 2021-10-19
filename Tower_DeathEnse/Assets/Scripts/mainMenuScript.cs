using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuScript : MonoBehaviour
{
    
    public AudioSource sondDeBouton;
    
    // Start is called before the first frame update
    void Start()
    {
        sondDeBouton = GetComponent<AudioSource>();
       
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