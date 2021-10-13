using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    public GameManager manager;

    [SerializeField]
    private float minHeight;

    [SerializeField]
    private float maxHeight;

    // Start is called before the first frame update
    void Start()
    {

        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float up = Input.GetAxis("Up");
        transform.position += new Vector3(horizontal, up, vertical) * Time.deltaTime * speed;

        if (transform.position.y <= minHeight)
        {
            transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
        }
        else if (transform.position.y >= maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            //pour ouvrir le shop des améliorations il faut modifier l'operateur binaire dans le script caméra pour qu'il puisse vérifier si il touche une tourelle ou un slot de tourelle 
            //1 << layer..............

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Position") | 1 << LayerMask.NameToLayer("Upgrade"))))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Position"))
                {
                    manager.PlaceTower(hit);
                }
                else
                {
                    manager.UpgradeMenu(hit);
                }
            }
        }
    }
}