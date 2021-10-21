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
        Instantiate(CanvasVictoire, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }
    public void SpawnUiD()
    {
        Instantiate(CanvasDefaite, new Vector3(0, 45, 0), new Quaternion(0, 0, 0, 0));
    }
   
     public void DestructionUi()
    {
        Destroy(CanvasVictoire);
        Destroy(CanvasDefaite);
    }
   
   
        
   


}

