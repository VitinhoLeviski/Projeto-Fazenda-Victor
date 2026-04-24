using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyOutOfBounds : MonoBehaviour
{
    LifendPoints player;
    private float topBound = 30f;
    private float lowerBound = -14f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<LifendPoints>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < lowerBound)
        {            
            player.takeDamage();
            Destroy(gameObject);
        }
    }
}
