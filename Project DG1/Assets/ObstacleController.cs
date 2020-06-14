using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    DinoController player;
    private void Start()
    {
        player = FindObjectOfType<DinoController>();
    }

    void Update()
    {
        transform.position -= new Vector3(player.speed * Time.deltaTime, 0, 0);

        if(transform.position.x < player.transform.position.x - 5f)
        {
            Destroy(gameObject);
        }
    }

    
}
