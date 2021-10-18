
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
    public GameObject canvasGrpVictoire;
    public GameObject canvasGrpDefaite;
   
    private List<Collider> slotsOccupied = new List<Collider>();
    public int? vieobjectif ;
    public int nbMaxEnnemi;
    //public int lvl=0;

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

        canvasGroupV = canvasGrpVictoire?.GetComponent<CanvasGroup>();
        
        
        canvasGroupD = canvasGrpDefaite?.GetComponent<CanvasGroup>();
     

        Reinitialiser();



    }
    public void Reinitialiser()
    {
        canvasGrpVictoire.SetActive(false);
        canvasGrpDefaite.SetActive(false);
        bvictoire = false;
        bdefaite = false;
        vieobjectif = objective?.health;
        nbMaxEnnemi = 2;
        money = 100;
        ennemiMort = 0;
        canvasGroupV.alpha = 0;
        canvasGroupD.alpha = 0;
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
        canvasGrpVictoire.SetActive(true);
        bvictoire = true;
        Debug.Log("c'est une victoire !");
        canvasGroupV.alpha = 1;
       
    }
    private void defaite()
    {
        canvasGrpDefaite.SetActive(true);
        bdefaite = true;
        Debug.Log("c'est une Défaite");
        cam.transform.position = new Vector3(0,45,-90);
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
    public void BackToM()
    {
        //lvl = 0;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void Continue()
    {
        //lvl += 1;
        SceneManager.LoadScene(2, LoadSceneMode.Single);
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
