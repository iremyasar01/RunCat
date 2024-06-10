using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public Animator animator;
    public int RunSpeed =10;
    public float maxPosition = 3.43f; // Maksimum konum
    public float minPosition = -3.43f; // Min konum
    //public int JumpForce = 2;
    public float JumpHeight = 1;
    private Rigidbody rb;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
       
        player = GetComponent<Player>();
        // Rigidbody bileşenini al
        rb = GetComponent<Rigidbody>();

    }
    public void AnimationControl(string animationName)
    {
        animator.SetBool("Run", false);
        //animator.SetBool("RightRun", false);
        //animator.SetBool("LeftRun", false);
       // animator.SetBool("Idle", false);
        animator.SetBool("Slide", false);
        animator.SetBool("Die", false);
        animator.SetBool(animationName, true);
   
    }

    // Update is called once per frame
    void  Update()
    {
        if (player.IsDie || player.IsFinish)
        {
            return;
        }
        
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * RunSpeed);
        //bastığım sürece çalışsın basılı kaldığımda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AnimationControl("Run");
            //transform.position = new Vector3(-3.43f, transform.position.y, transform.position.z);

            transform.Translate(Vector3.left * Time.deltaTime * RunSpeed);
            // Karakterin mevcut konumunu kontrol edelim
            if (transform.position.x < minPosition)
            {
                // Eğer karakterin konumu maksimum konumdan büyükse, karakteri maksimum konumda tutalım
                Vector3 newPosition = transform.position;
                newPosition.x = minPosition;
                transform.position = newPosition;
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AnimationControl("Run");
            //aşağıdaki gibi olunca direkt 3.43 x konumuna gidiyor.
            //transform.position = new Vector3(3.43f, transform.position.y, transform.position.z);
            transform.Translate(Vector3.right * Time.deltaTime * RunSpeed);
            // Karakterin mevcut konumunu kontrol edelim
            if (transform.position.x > maxPosition)
            {
                // Eğer karakterin konumu maksimum konumdan büyükse, karakteri maksimum konumda tutalım
                Vector3 newPosition = transform.position;
                newPosition.x = maxPosition;
                transform.position = newPosition;
            }

        }
        //bi kere çalışsın diye.
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("Jump");
            // Rigidbody'ye yukarı doğru bir kuvvet uygula
            //rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            player.transform.DOMoveY(JumpHeight, 0.5f).SetEase(Ease.OutFlash);
            player.transform.DOMoveY(0.5f, 0.75f).SetDelay(0.5f).SetEase(Ease.InFlash);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("Slide");
        }
        
        else if (Input.anyKey == false)
        {
             //AnimationControl("Idle");
            
           AnimationControl("Run");

        }
        
    }
   
    
}
