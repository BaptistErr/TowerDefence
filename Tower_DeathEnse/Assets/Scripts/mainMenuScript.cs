using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuScript : MonoBehaviour
{
    AudioSource sondDeBouton;
    
    // Start is called before the first frame update
    void Start()
    {
        sondDeBouton = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jouer()
    {
        sondDeBouton.Play();
  
        SceneManager.LoadScene("towerDefense", LoadSceneMode.Single);
    }
    public void quitter()
    {
        Debug.Log("l'application se ferme !!!");
        Application.Quit();
    }
    public void BackToM()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}