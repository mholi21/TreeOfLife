using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D _pBody;
    Animator _pAnim;
    public float pSpeed;

    void Start()
    {
        _pBody = GetComponent<Rigidbody2D>();
        _pAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementVector != Vector2.zero && !_pAnim.GetBool("IsDead"))
        {
            _pAnim.SetBool("IsWalking", true);
            _pAnim.SetFloat("Input_x", movementVector.x);
            _pAnim.SetFloat("Input_y", movementVector.y);
        }
        else
        {
            _pAnim.SetBool("IsWalking", false);
        }

        if (_pAnim.GetBool("IsWalking"))
        {
            _pBody.MovePosition(_pBody.position + movementVector * Time.deltaTime * pSpeed);
        }
        _pAnim.speed = pSpeed;

    }
    
}
