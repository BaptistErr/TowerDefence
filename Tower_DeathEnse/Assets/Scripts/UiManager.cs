using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    
    public GameObject CanvasVictoire;
    public GameObject CanvasDefaite;


    public static UiManager instance { get; private set; }


    void awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }

    public void SpawnUi()
    {
        CanvasVictoire = (GameObject)Instantiate(CanvasVictoire, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        CanvasDefaite = (GameObject)Instantiate(CanvasDefaite, new Vector3(0, 45, -90), new Quaternion(45, 0, 0, 0));
    }
   
     public void DestructionUi()
    {
        Destroy(CanvasVictoire);
        Destroy(CanvasDefaite);
    }
    public void ChangeStateUi(GameObject Canvas)
    {
        Canvas.SetActive(!Canvas);
    }
        
        
   


}

