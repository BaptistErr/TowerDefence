using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVisiblity : MonoBehaviour
{
    private bool _visible = false;

    public float duree = 0.4f;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toggle()
    {
        var _canvasgroup = GetComponent<CanvasGroup>();
        // change la valeur finale dépendant de l'etat du booleen
        StartCoroutine(cache(_canvasgroup, _canvasgroup.alpha, _visible ? 1 : 0));
        //changement d'etat
        _visible = !_visible;
    }
    public IEnumerator cache(CanvasGroup _canvasGroup,float start, float end)
    {
        float counter = 0f;
        while(counter<duree)
        {
            counter += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(start, end, counter / duree);
            yield return null;
        }
    }
}
