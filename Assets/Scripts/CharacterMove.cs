using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Animator animator;
    public int RunSpeed =10;

    // Start is called before the first frame update
    void Start()
    {

        
    }
    void AnimationControl(string animationName)
    {
        animator.SetBool("Run", false);
        //animator.SetBool("RightRun", false);
        //animator.SetBool("LeftRun", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Die", false);
        animator.SetBool(animationName, true);
    }

    // Update is called once per frame
    void  Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * RunSpeed);
        //bastığım sürece çalışsın basılı kaldığımda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AnimationControl("Run");
            
            transform.Translate(Vector3.left * Time.deltaTime * RunSpeed);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AnimationControl("Run");
            transform.Translate(Vector3.right * Time.deltaTime * RunSpeed);

        }
        //bi kere çalışsın diye.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Jump");
           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("Slide");
        }
        
        else if (Input.anyKey == false)
        {
            AnimationControl("Idle");
       
        }
    }
}
