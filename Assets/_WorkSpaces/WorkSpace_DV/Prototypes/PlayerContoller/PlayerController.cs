using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public GameObject player1;
    public GameObject player2;
    public float horizontalInputP1;
    public float verticalInputP1;
    public float horizontalInputP2;
    public float verticalInputP2;
    public float speedP1;
    public float speedP2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Player 1
        horizontalInputP1 = Input.GetAxis("Horizontal");
        player1.transform.Translate(Vector3.right * horizontalInputP1 * Time.deltaTime * speedP1);
        verticalInputP1 = Input.GetAxis("Vertical");
        player1.transform.Translate(Vector3.up * verticalInputP1 * Time.deltaTime * speedP1);

        // Player 1
        horizontalInputP2 = Input.GetAxis("Horizontal");
        player1.transform.Translate(Vector3.right * horizontalInputP2 * Time.deltaTime * speedP2);
        verticalInputP2 = Input.GetAxis("Vertical");
        player1.transform.Translate(Vector3.up * verticalInputP2 * Time.deltaTime * speedP2);
    }
}
