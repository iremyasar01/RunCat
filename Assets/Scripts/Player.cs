using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsDie, IsFinish;
    public Animator animator;
    public CharacterMove CharacterMove;
    public UIManager uimanager;

    private void Awake()
    {
        CharacterMove = GetComponent<CharacterMove>();
        uimanager = GameObject.Find("GameManager").GetComponent<UIManager>();
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
            Invoke(nameof(WinCondition), 1);
            //CharacterMove.RunSpeed = 0;
        }
        if (other.CompareTag("Collectible"))
        {
            if (other.GetComponent<Collectible>().cType == Collectible.CollectibleType.Bones)
            {
                Debug.Log("coin arttır");
                Debug.Log("destroy et");
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsDie = true;
            CharacterMove.AnimationControl("Die");
            Invoke(nameof(FailCondition),1);//animasyonu bitince acilsin diye

        }
        //CharacterMove.RunSpeed = 0;
        //CharacterMove.JumpForce = 0;

    }
    void FailCondition()
    {
        uimanager.Fail();
    }

    void WinCondition()
    {
        uimanager.Win();
    }

}


