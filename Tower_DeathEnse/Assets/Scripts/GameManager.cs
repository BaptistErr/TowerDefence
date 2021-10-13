using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get;private set; }
    private void Awake()
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
    // tourelle pour les placements sur les slots 
    public Object tower;
    
    // variable pour la victoire / défaite 
   
    public int ennemiMort;

    public GameObject victoryUi;
   

    private List<Collider> slotsOccupied = new List<Collider>();

   
    void Start()
    {
    }


    void Update()
    {
        if (ennemiMort >= 1)
        {
            victoire();
        }
    }
    public void PlaceTower(RaycastHit slot)
    {
        if (!slotsOccupied.Contains(slot.collider))
        {
            Instantiate(tower, slot.transform.position + new Vector3(0f, 3f), Quaternion.identity);
            slotsOccupied.Add(slot.collider);
        }
    }
    public void victoire()
    {
        
            Debug.Log("you won");
            victoryUi.SetActive(true);
        
    }
}
