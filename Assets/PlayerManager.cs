using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float speed;
    [SerializeField] bool isTurnedAround = false;
    [SerializeField] bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            anim.SetBool("IsWalking", false);
        if (Input.GetAxis("Vertical") > 0)
        {
            GoingForward();
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            TurnAround();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }

    void GoingForward()
    {
        anim.SetBool("IsWalking", true);
        if (isTurnedAround)
        {
            transform.Rotate(Vector3.up, -180);
            isTurnedAround = false;
        }
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }    

    void TurnAround()
    {
        anim.SetBool("IsWalking", true);
        if (!isTurnedAround)
        {
            transform.Rotate(Vector3.up, -180);
            isTurnedAround = true;
        }
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * -1 * Time.deltaTime);
    }

    void Jump()
    {
        if (!isJumping)
        {
            anim.SetBool("IsJumping", true);
            isJumping = true;
            anim.SetBool("IsFalling", false);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            isJumping = false;
            anim.SetBool("IsFalling", true);
        }
    }
}
