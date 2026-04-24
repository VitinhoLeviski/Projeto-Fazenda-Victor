using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    public LifendPoints player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<LifendPoints>();
    }

    // Update is called once per frame
    void Update()
    {

    }    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.takeDamage();
        }
        
        if(other.CompareTag("killer"))
        {
            Destroy(other.gameObject);
            player.plusPoints();
        }
        
        Destroy(gameObject);

    }
}
