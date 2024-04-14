using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsDie, IsFinish;
    public Animator animator;
    public CharacterMove CharacterMove;
    private void Awake()
    {
        CharacterMove = GetComponent<CharacterMove>();
    }
        // Start is called before the first frame update
        void Start()
    {
        IsDie = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            IsFinish = true;
            //CharacterMove.RunSpeed = 0;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsDie = true;
            CharacterMove.AnimationControl("Die");
            //CharacterMove.RunSpeed = 0;
            //CharacterMove.JumpForce = 0;

        }
    }
    
}
