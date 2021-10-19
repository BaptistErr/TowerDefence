
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Manager 
    public static GameManager instance { get; private set; }
    public UiManager uiManager;

    //autre classe
    Camera cam;
    ObjectiveBehaviour objective;

    //regle du jeu
    public int money=100;
    public int? vieobjectif;
    public int nbMaxEnnemi=2;
    public int ennemiMort=0;

    


    // tourelle pour les placements sur les slots 
    public UnityEngine.Object tower;
    private Collider towerUpgradeMenu;
    [SerializeField]
    private UnityEngine.Object uiUpgrade;

    public GameObject upgradeMenu;

    // variable pour la victoire / défaite 
    bool bvictoire = false;
    bool bdefaite = false;
    
    
    private List<Collider> slotsOccupied = new List<Collider>();
   
    

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
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        objective = GameObject.Find("Objective").GetComponent<ObjectiveBehaviour>();
        
        initialiser();
    }
    
    public void initialiser()
    {
        
        bvictoire = false;
        bdefaite = false;
        vieobjectif = objective?.health;
        nbMaxEnnemi = 2;
        money = 100;
        
        ennemiMort = 0;
       
    }
    private void FixedUpdate()
    {
        if ( ennemiMort == nbMaxEnnemi)
        {
            if (bvictoire == false)
            {
                initialiser();
                victoire();
            }
        }
        if (vieobjectif <= 0 )
        {
            if (bdefaite == false)
            {
                initialiser();
                defaite();
            }
            }


    }
    private void victoire()
    {
        uiManager.SpawnUiV();
        bvictoire = true;
        Debug.Log("c'est une victoire !");
        
       
    }
    private void defaite()
    {
        uiManager.SpawnUiD();
        bdefaite = true;
        Debug.Log("c'est une Défaite");
        
       
        
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
    public void BackToM()
    {
        
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
    public void Continue()
    {
       
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    /* public void UpgradeButton(GameObject upgradetower)
     {
         Debug.Log("amelioration");
         RaycastHit
         Instantiate(upgradetower,cible.transform.position + new Vector3(0f, 3f), Quaternion.identity);


     }*/

     public void SellButton()
     {
         Debug.Log("Vente");
     }
}
