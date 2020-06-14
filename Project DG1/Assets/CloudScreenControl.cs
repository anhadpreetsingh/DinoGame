using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScreenControl : MonoBehaviour
{
    [SerializeField] float speedReducer = 0.5f;
    [SerializeField] CloudScreenControl cloudScreenPrefab;


    DinoController player;
    bool nextScreenGenerated;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<DinoController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3((player.speed - speedReducer) * Time.deltaTime, 0);

        if (transform.position.x - player.transform.position.x <= 0.5f && !nextScreenGenerated)
        {
            Instantiate(cloudScreenPrefab, transform.position + new Vector3(5, 0, 0), Quaternion.identity);

            nextScreenGenerated = true;
        }

        if (transform.position.x <= player.transform.position.x - 5f)
        {
            Destroy(gameObject);
        }
    }
}
