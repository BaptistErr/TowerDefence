using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // tourelle pour les placements sur les slots 
    public Object tower;
    CanvasGroup _canvasgroup;
    

    // variable pour la victoire / d�faite 
    public int nbEnnemiMax;
    private int ennemiMort;
    
    
    public int getNbEnnemiMax()
    {
        return nbEnnemiMax;
    }
   
    public void setNbEnnemiMax(int nbEnnemiMax_)
    {
        nbEnnemiMax = nbEnnemiMax_;
    }

    private List<Collider> slotsOccupied = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
       
     
   
     
    }

    // Update is called once per frame
    void Update()
    {
       //victoire � travailler 
       if(nbEnnemiMax==ennemiMort)
        {

        }
       //defaite � travailler 
       //if(Health <=0)
       //toggle()

        
    }
    //fct qui fait apparaitre les menus sur les tourelles 
    /*
     * 
     * 
     * 
     * 
     * */
    public void PlaceTower(RaycastHit slot)
    {
        if (!slotsOccupied.Contains(slot.collider))
        {
            Instantiate(tower, slot.transform.position + new Vector3(0f, 3f), Quaternion.identity);
            slotsOccupied.Add(slot.collider);
        }
    }

  
}
