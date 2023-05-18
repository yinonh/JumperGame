using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed += 15;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            speed -= 15;
        }

        if(! playerControllerScript.gameOver)
            transform.Translate(Vector3.left * (speed + playerControllerScript.addSpeed) * Time.deltaTime);
    }
}
