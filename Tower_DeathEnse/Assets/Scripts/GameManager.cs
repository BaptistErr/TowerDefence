
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int money;
    Camera cam;
    bool bvictoire ;
    bool bdefaite ;
    public static GameManager instance { get;private set; }

    SpawnEnnemi spawnEnnemi;
    ObjectiveBehaviour objective;
    
    private Collider towerUpgradeMenu;

    [SerializeField]
    private UnityEngine.Object uiUpgrade;

    public GameObject upgradeMenu;

    // tourelle pour les placements sur les slots 
    public UnityEngine.Object tower;
    
    
    // variable pour la victoire / défaite 
   
    public int ennemiMort;
    public CanvasGroup canvasGroupV;
    public CanvasGroup canvasGroupD;
    public GameObject CanvasVictoire;
    public GameObject CanvasDefaite;
   
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
        cam = GetComponent<Camera>();
        objective = FindObjectOfType<ObjectiveBehaviour>();
        
      
            
        
        Reinitialiser();

        

    }
    
    public void Reinitialiser()
    {
        CanvasVictoire = (GameObject)Instantiate(CanvasVictoire, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        CanvasDefaite = (GameObject)Instantiate(CanvasDefaite, new Vector3(0, 45, -90), new Quaternion(45, 0, 0, 0));
        canvasGroupV = CanvasVictoire.GetComponent<CanvasGroup>();

        canvasGroupD = CanvasDefaite.GetComponent<CanvasGroup>();
        CanvasVictoire.SetActive(false);
        CanvasDefaite.SetActive(false);
        bvictoire = false;
        bdefaite = false;
        vieobjectif = objective.health;
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
                victoire();
            }
        }
        if (vieobjectif <= 0 )
        {
            if (bdefaite == false)
            {
                defaite();
            }
            }


    }
    private void victoire()
    {
        CanvasVictoire.SetActive(true);
        bvictoire = true;
        Debug.Log("c'est une victoire !");
        
       
    }
    private void defaite()
    {
        CanvasDefaite.SetActive(true);
        bdefaite = true;
        Debug.Log("c'est une Défaite");
        cam.transform.position = new Vector3(0,45,-90);
       
        
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
        Destroy(CanvasVictoire);
        Destroy(CanvasDefaite);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        
    }
    public void Continue()
    {
        Destroy(CanvasVictoire);
        Destroy(CanvasDefaite);
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
