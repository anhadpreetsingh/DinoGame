using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    
    [SerializeField] PlatformControl platformPrefab;

    public bool nextPlatformGenerated = false; // todo make private
    DinoController player;
    void Start()
    {
        player = FindObjectOfType<DinoController>();
    }

    
    void Update()
    {
        
        transform.position -= new Vector3(player.speed * Time.deltaTime, 0, 0);
        if(transform.position.x - player.transform.position.x <= 0.5f && !nextPlatformGenerated)
        {
            Instantiate(platformPrefab, transform.position + new Vector3(5, 0, 0), Quaternion.identity);

            nextPlatformGenerated = true;
        }

        if(transform.position.x <= player.transform.position.x - 5f)
        {
            Destroy(gameObject);
        }
    }
}
