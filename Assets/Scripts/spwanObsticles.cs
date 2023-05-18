using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanObsticles : MonoBehaviour
{
    public GameObject [] obsticles;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addObsticle", 0.5f ,Random.Range(1.0f, 3.0f));
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addObsticle()
    {
        if (!playerControllerScript.gameOver)
        {
            GameObject ob = obsticles[Random.Range(0, obsticles.Length)];
            Instantiate(ob, new Vector3(35, 0, 0), ob.transform.rotation);
        }
        
    }
}
