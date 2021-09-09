using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizantalInout;
    private Rigidbody rigibodyCompoment;
    private int superJumpesRemining;
    




    // Start is called before the first frame update
    void Start()
    {
        rigibodyCompoment = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //Check if space key is pressed down
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizantalInout = Input.GetAxis("Horizontal");

    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        rigibodyCompoment.velocity = new Vector3(horizantalInout, rigibodyCompoment.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
       
        //Check if space key is pressed down
        if (jumpKeyWasPressed)
        {
            float jumpPower = 5f;
            if (superJumpesRemining > 0)
            {
                jumpPower *= 2;
                superJumpesRemining--;
            }

            rigibodyCompoment.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            superJumpesRemining ++;
        }
    }
}


   
