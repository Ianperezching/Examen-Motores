using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Rigidbody myRBD2;
    
    
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float detectionRange = 5f;
    private Transform currentPositionTarget;
    private int patrolPos = 0;
    private bool playerDetected = false;

    private void Start()
    {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }

    private void Update()
    {
        
            Patrol();
        if (!playerDetected)
            Patrol();
        
            



    }

    private void Patrol()
    {
        CheckNewPoint();
        // Dibuja el raycast en la escena para visualizarlo
        Debug.DrawRay(transform.position, currentPositionTarget.position - transform.position, Color.green);

        // Aquí puedes agregar el código para el raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, currentPositionTarget.position - transform.position, detectionRange);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            playerDetected = true;
        }
    }

    private void CheckNewPoint()
    {
        if (Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25)
        {
            patrolPos = (patrolPos + 1) % checkpointsPatrol.Length;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * velocityModifier;
           
        }
    }

   
}
