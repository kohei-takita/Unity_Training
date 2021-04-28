using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 10.0f;
    public float jumpSpeed = 50.0f;
    private Rigidbody Rb;
    public float brake = 1.0f;
    public float moveTurnSpeed = 10.0f;
    private int JumpQuantity = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
        if (JumpQuantity <= 1)
            {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpQuantity ++;
                //direction.y = 5.0f * jumpSpeed;
                //Rb.AddForce(0.0f, direction.y, 0.0f);
                Rb.AddForce(0.0f, jumpSpeed * 5.0f, 0.0f);
            }
        }
        if(direction.magnitude > 0.01f && !(Input.GetKey(KeyCode.LeftShift)))
        {
            Quaternion moveRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, moveRot, Time.deltaTime * moveTurnSpeed);
        }
        Rb.AddForce(direction.x * Speed - Rb.velocity.x * brake, 0, direction.z * Speed - Rb.velocity.z * brake, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stage" || other.gameObject.tag == "Target")
        {
            JumpQuantity = 0;
        }
    }

}
