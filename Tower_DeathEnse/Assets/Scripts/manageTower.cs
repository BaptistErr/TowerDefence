using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        FindObjectOfType<GameManager>().UpgradeButton(gameObject);
    }

    public void Sell()
    {
        FindObjectOfType<GameManager>().SellButton(gameObject);
    }
}
