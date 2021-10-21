using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLevels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        FindObjectOfType<GameManager>().Continue();
        FindObjectOfType<GameManager>().initialiser();
    }

    public void BackToMenu()
    {
        FindObjectOfType<GameManager>().BackToM();
        FindObjectOfType<GameManager>().initialiser();
    }
}
