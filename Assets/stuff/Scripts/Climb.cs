using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class Climb : MonoBehaviour
{
    public float gravity = 45.0f;
    public float senstivity = 45.0f;

    public HandHandler currentHand = null;
    //private CharacterController controller = null;

    private void Awake()
    {
        
    }
    private void Update()
    {
        CalculateMovement();
    }

     Vector3 movement = Vector3.zero;
    void CalculateMovement()
    {

        if (currentHand)    
        {
            movement = currentHand.Delta;

            transform.position += movement;
        }
        // if (movement == Vector3.zero)
        // {
        //     movement.y -= gravity * Time.deltaTime;
        // }

        //Debug.Log(currentHand?.Delta);
    }
    public void SetHand(HandHandler hand)
    {
        currentHand = hand;

        //Debug.Log(hand.gameObject.name);
        // if (currentHand)
        // {
        //     currentHand.ReleasePoint();
        // }
    }
    public void ClearHand()
    {
        currentHand = null;
    }
}
