using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movi : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5f;

    [Header("Raycast Properties")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float rayDistance = 2f;
    [SerializeField] private Color rayDebugColor = Color.red;

    
    private Rigidbody myRB;
    [SerializeField] private bool canJump;
    private bool suelo;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement = new Vector3(Input.GetAxisRaw("Horizontal"), myRB.velocity.y, Input.GetAxisRaw("Vertical"));

        canJump = Physics.Raycast(transform.position, Vector3.down, rayDistance, groundLayers);

        Debug.DrawRay(transform.position, Vector3.down * rayDistance, rayDebugColor);


    }

    public void Movimiento(InputAction.CallbackContext context)
    {
        Vector3 movementPlayer = context.ReadValue<Vector3>();
        Debug.Log(movementPlayer);
        if (canJump)
        {
            myRB.velocity = movementPlayer * speed;
            //myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //myRB.velocity = movementPlayer * speed;

        Debug.Log(canJump);

       
       
    }
}
