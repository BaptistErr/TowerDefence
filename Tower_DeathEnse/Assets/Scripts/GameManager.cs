
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //test money
    public HealthBase lvlui;

    // Manager 
    public static GameManager instance { get; private set; }
    public UiManager uiManager;

    //autre classe
  
    ObjectiveBehaviour objective;
    
    
    //regle du jeu
    public int money=100;
    public int vieobjectif;
    public int nbMaxEnnemi;
    public int ennemiMort;
    public int level=0;

    //son victoire/defaite
    //public AudioSource sonVictoire;
    //public AudioSource sonDefaite;


    // tourelle pour les placements sur les slots 
    public UnityEngine.Object tower;
    private Collider towerUpgradeMenu;
    [SerializeField]
    private UnityEngine.Object uiUpgrade;

    public GameObject upgradeMenu;

    [SerializeField]
    private Object betterTower;

    [SerializeField]
    private GameObject smoke;

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
        //sonVictoire = GetComponent<AudioSource>();
        //sonDefaite = GetComponent<AudioSource();
       
        
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();
        

        initialiser();
    }
    
    public void initialiser()
    {
       
        bvictoire = false;
        bdefaite = false;
        vieobjectif = 1000;
        nbMaxEnnemi = 8;
        money = 100;
        
        ennemiMort = 0;
       
    }

    
    private void FixedUpdate()
    {
       
        if ( ennemiMort == nbMaxEnnemi)
        {
            if (bvictoire == false)
            {
                victoire();
                initialiser();
            }
        }
        if (vieobjectif <= 0 )
        {


            if (bdefaite == false)
            {   
                defaite();
                initialiser();
            }
            
               
            
            }
       


    }
    private void victoire()
    {
        //sonVictoire.play();
        uiManager.SpawnUiV();
        bvictoire = true;
    }
    private void defaite()
    {

        //sonDefaite.play();
        uiManager.SpawnUiD();
        bdefaite = true;
    }

    public void PlaceTower(RaycastHit slot)
    {
        if (!slotsOccupied.Contains(slot.collider) && money >= 50)
        {
            GameObject smokeSpawned = Instantiate(smoke, slot.transform.position, Quaternion.identity);
            Destroy(smokeSpawned, 3);
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
            upgradeMenu.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
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
                upgradeMenu.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
                towerUpgradeMenu = tower.collider;
            }
        }
    }
    public void BackToM()
    {
        level = 0;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
    public void Continue()
    {
        level += 1;
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void UpgradeButton(GameObject ui)
    {
        if (money >= 70)
        {
            SetMoney(-70);
            GameObject upgradedTower = ui.transform.parent.parent.parent.gameObject;
            Destroy(upgradedTower);
            GameObject upgrade = (GameObject) Instantiate(betterTower, upgradedTower.transform.position, upgradedTower.transform.rotation);
            upgrade.GetComponentInChildren<TowerBehaviour>().level++;
        }
        /*RaycastHit
        Instantiate(upgradetower,cible.transform.position + new Vector3(0f, 3f), Quaternion.identity);*/
    }

     public void SellButton(GameObject ui)
    {
        SetMoney(30);
        GameObject selledTower = ui.transform.parent.parent.parent.gameObject;
        Destroy(selledTower);
    }
    public int GetMoney()
    {
        return money;
    }
    public void SetMoney(int value)
    {
        money += value;
    }
}
