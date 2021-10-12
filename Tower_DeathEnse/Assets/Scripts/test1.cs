using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    test2 variable2;
    // Start is called before the first frame update
    void Start()
    {
        variable2 = GetComponent<test2>();
        variable2.malware();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void text()
    {
        Debug.Log("ceci est un test de la classe 1");
    }
}
