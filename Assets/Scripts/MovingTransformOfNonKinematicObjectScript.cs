using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTransformOfNonKinematicObjectScript : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    private bool wantToMoveLeft;

    private bool wantToMoveRight;
    
    private bool wantToMoveForward;
    
    private bool wantToMoveBack;
	

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wantToMoveLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            wantToMoveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            wantToMoveRight = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            wantToMoveRight = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            wantToMoveForward = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            wantToMoveForward = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            wantToMoveBack = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            wantToMoveBack = false;
        }
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wantToMoveLeft)
        {
            targetTransform.position += Vector3.left * 5f * Time.deltaTime;
        }

        if (wantToMoveRight)
        {
            targetTransform.position += Vector3.right * 5f * Time.deltaTime;
        }
        
        if (wantToMoveForward)
        {
            targetTransform.position += Vector3.forward * 5f * Time.deltaTime;
        }
        
        if (wantToMoveBack)
        {
            targetTransform.position += Vector3.back * 5f * Time.deltaTime;
        }
        
		
    }
}
