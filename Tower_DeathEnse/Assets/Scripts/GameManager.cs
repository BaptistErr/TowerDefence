using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class GameManager : MonoBehaviour
{
    public int money;

    public static GameManager instance { get;private set; }

    SpawnEnnemi spawnEnnemi;
    ObjectiveBehaviour objective;
    
    private Collider towerUpgradeMenu;

    [SerializeField]
    private Object uiUpgrade;

    public GameObject upgradeMenu;

    // tourelle pour les placements sur les slots 
    public Object tower;
    
    
    // variable pour la victoire / défaite 
   
    public int ennemiMort;
    public CanvasGroup canvasGroupV;
    public CanvasGroup canvasGroupD;
    public GameObject canvasGrpVictoire;
    public GameObject canvasGrpDefaite;
   
    private List<Collider> slotsOccupied = new List<Collider>();
    public int vieobjectif ;
    public int nbMaxEnnemi;

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
        objective = FindObjectOfType<ObjectiveBehaviour>();
        canvasGroupV = canvasGrpVictoire.GetComponent<CanvasGroup>();
        canvasGroupD = canvasGrpDefaite.GetComponent<CanvasGroup>();
        vieobjectif = objective.health;
        nbMaxEnnemi = 10;
        money = 100;
        ennemiMort = 0;
    }
    private void FixedUpdate()
    {
        if ( ennemiMort == Math.Floor(nbMaxEnnemi/3f))
        {
            victoire();
        }
        if (vieobjectif <= 0 )
        {
            defaite();
        }

    }
    private void victoire()
    {
        Debug.Log("c'est une victoire !");
        canvasGroupV.alpha = 1;
    }
    private void defaite()
    {
        Debug.Log("c'est une Défaite");
        canvasGroupD.alpha = 1;
    }

    public void PlaceTower(RaycastHit slot)
    {
        if (!slotsOccupied.Contains(slot.collider) && money >= 50)
        {
            Instantiate(tower, slot.transform.position, Quaternion.identity);
            slotsOccupied.Add(slot.collider);
            money -= 50;
        }
    }
    

    public void UpgradeMenu(RaycastHit tower)
    {
        if(!towerUpgradeMenu)
        {
            upgradeMenu = (GameObject) Instantiate(uiUpgrade, tower.collider.gameObject.transform.position + new Vector3(0, 10, 0), tower.collider.gameObject.transform.rotation, tower.collider.gameObject.transform);
            towerUpgradeMenu = tower.collider;
        }
        else
        {
            Destroy(upgradeMenu);
            if (towerUpgradeMenu == tower.collider)
            {
                towerUpgradeMenu = null;
            }
            else
            {
                upgradeMenu = (GameObject) Instantiate(uiUpgrade, tower.collider.gameObject.transform.position + new Vector3(0, 10, 0), tower.collider.gameObject.transform.rotation, tower.collider.gameObject.transform);
                towerUpgradeMenu = tower.collider;
            }
        }
    }

   /* public void UpgradeButton(GameObject upgradetower)
    {
        Debug.Log("amelioration");
        RaycastHit
        Instantiate(upgradetower,cible.transform.position + new Vector3(0f, 3f), Quaternion.identity);
            
        
    }
    public void SellButton()
    {
        Debug.Log("Vente");
    }
   */
}
