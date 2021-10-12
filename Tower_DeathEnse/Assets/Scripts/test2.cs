using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    test1 variable1;
    // Start is called before the first frame update
    void Start()
    {
        variable1 = GetComponent<test1>();
        variable1.text();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void malware()
    {
        Debug.Log("ceci est un test de la classe 2");
    }
}
