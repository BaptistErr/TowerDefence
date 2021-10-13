using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // tourelle pour les placements sur les slots 
    public Object tower;
    
    // variable pour la victoire / défaite 
   
    private int ennemiMort;
    
    
   

    private List<Collider> slotsOccupied = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       //victoire 
       /*if(nbEnnemiMax==ennemiMort)
        {

        }
       */
       //defaite 
       //if(Health <=0)


        
    }

    public void PlaceTower(RaycastHit slot)
    {
        if (!slotsOccupied.Contains(slot.collider))
        {
            Instantiate(tower, slot.transform.position + new Vector3(0f, 3f), Quaternion.identity);
            slotsOccupied.Add(slot.collider);
        }
    }
}
