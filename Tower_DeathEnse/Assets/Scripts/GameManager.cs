using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get;private set; }
    
    private Collider towerUpgradeMenu;

    [SerializeField]
    private Object uiUpgrade;

    private GameObject upgradeMenu;

    // tourelle pour les placements sur les slots 
    public Object tower;
    
    // variable pour la victoire / défaite 
   
    private int ennemiMort;

    public GameObject victoryUi;
   
    private List<Collider> slotsOccupied = new List<Collider>();

<<<<<<< HEAD
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
=======
   
    void Start()
    {
    }

   
    void Update()
    {
       

        
>>>>>>> parent of d541600 (animation attaque)
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
<<<<<<< HEAD
    }

    public void UpgradeMenu(RaycastHit tower)
    {
        if(!towerUpgradeMenu)
        {
            upgradeMenu = (GameObject) Instantiate(uiUpgrade, tower.collider.gameObject.transform.position += new Vector3(0, 10, 0), tower.collider.gameObject.transform.rotation, tower.collider.gameObject.transform);
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
                Instantiate(uiUpgrade, tower.collider.gameObject.transform.position += new Vector3(0, 10, 0), tower.collider.gameObject.transform.rotation, tower.collider.gameObject.transform);
                towerUpgradeMenu = tower.collider;
            }
        }
=======
>>>>>>> parent of d541600 (animation attaque)
    }
}
