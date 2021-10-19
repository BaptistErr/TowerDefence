using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    
    public GameObject CanvasVictoire;
    public GameObject CanvasDefaite;


    public static UiManager instance { get; private set; }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnUiV()
    {
        CanvasVictoire = (GameObject)Instantiate(CanvasVictoire, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }
    public void SpawnUiD()
    {
        CanvasDefaite = (GameObject)Instantiate(CanvasDefaite, new Vector3(0, 45, -90), new Quaternion(45, 0, 0, 0));
    }
   
     public void DestructionUi()
    {
        Destroy(CanvasVictoire);
        Destroy(CanvasDefaite);
    }
    public void ChangeStateUi(int index)
    {
        if( index==0)
        {
            CanvasVictoire.SetActive(!CanvasVictoire);
        }
        else
        {
            CanvasDefaite.SetActive(!CanvasDefaite);
        }
        
    }
        
        
   


}

