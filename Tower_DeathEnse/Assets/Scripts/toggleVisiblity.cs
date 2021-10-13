using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVisiblity : MonoBehaviour
{
    CanvasGroup _canvasgroup;
    // Start is called before the first frame update
    void Start()
    {
        _canvasgroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggle()
    {
        _canvasgroup.alpha = 0.5f;
    }
}
