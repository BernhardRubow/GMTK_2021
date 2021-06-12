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

    private Rigidbody rbPlayer1;
    private Rigidbody rbPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer1 = player1.GetComponent<Rigidbody>();
        rbPlayer2 = player2.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player 1
        horizontalInputP1 = Input.GetAxis("Horizontal1");
        verticalInputP1 = Input.GetAxis("Vertical1");
        rbPlayer1.AddForce(new Vector3(horizontalInputP1,0f, verticalInputP1) * speedP1, ForceMode.Force);

        //player1.transform.Translate(Vector3.right * horizontalInputP1 * Time.deltaTime * speedP1);
        //player1.transform.Translate(Vector3.forward * verticalInputP1 * Time.deltaTime * speedP1);

        // Player 2
        horizontalInputP2 = Input.GetAxis("Horizontal2");
        verticalInputP2 = Input.GetAxis("Vertical2");
        rbPlayer2.AddForce(new Vector3(horizontalInputP2, 0f, verticalInputP2) * speedP2, ForceMode.Force);

        //player2.transform.Translate(Vector3.right * horizontalInputP2 * Time.deltaTime * speedP2);
        //player2.transform.Translate(Vector3.forward * verticalInputP2 * Time.deltaTime * speedP2);
    }
}
