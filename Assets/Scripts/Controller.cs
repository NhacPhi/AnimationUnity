using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Animator m_animator;
    CharacterController m_character;

    public float PlayerSpeed = 5.0f;
    public float RuningSpeed = 7.0f;

    float Vertical = 0;
    float Horizontal = 0;
    Vector3 Move;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();

        m_character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        m_animator.SetFloat("VelocityY", Vertical);
        m_animator.SetFloat("VelocityX", Horizontal);
        
        Move = Vector3.zero;
        Move = new Vector3(Horizontal,0, Vertical);

        if (Move.sqrMagnitude > 0)
        {
            Move.Normalize();
            //Weapon.Walk = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Vertical!=0)
        {
            Move = Move * Time.deltaTime * RuningSpeed;
            //m_animator.SetBool("IsRun", true);
            m_animator.SetFloat("VelocityY", 2);
        }
        else
        {
            Move = Move * Time.deltaTime * PlayerSpeed;
            //m_animator.SetBool("IsRun", false);
        }

        Move = transform.TransformDirection(Move);

        m_character.Move(Move);
    }
}
