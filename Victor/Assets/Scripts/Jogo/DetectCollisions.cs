using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    private menuManagerGame menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }    

    private void OnTriggerEnter(Collider other)
    {

       Destroy(gameObject);


        if(other.CompareTag("Player"))
        {
            menu.vidas--;
        }
        
        if(other.CompareTag("killer"))
        {

            Destroy(other.gameObject);
        }
    }
}
