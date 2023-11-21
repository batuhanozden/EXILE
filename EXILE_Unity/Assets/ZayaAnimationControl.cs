using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ZayaAnimationControl : MonoBehaviour
{
    public AudioSource SwordAttack;

    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    //int gatheringHash;
    int hittingHash;

    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //increases performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        //gatheringHash = Animator.StringToHash("gathering");
        hittingHash = Animator.StringToHash("hitting");
        


    }

    // Update is called once per frame
    void Update()
    {

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        //bool gathering = animator.GetBool(gatheringHash);
        bool hasMoveInput = (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"));
        //bool forwardPressed = Input.GetKey("w");
        //bool forwardPressed2 = Input.GetKey("a");
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");
        //bool gatherPressed = Input.GetKey("e");

        //if player presses w key
        if (!isWalking && hasMoveInput)
        {
            // then set the isWalking boolean to be true
            animator.SetBool(isWalkingHash, true);


        }
        //if player is not pressing w
        if (isWalking && !hasMoveInput)
        {
            //then set the isWalking boolean to be false 
            animator.SetBool(isWalkingHash, false);
        }
       


        //if player isWalking and not running and presses left shift
        if (!isRunning && (hasMoveInput && runPressed))
        {
            //then set the isRunning boolean to be true
            animator.SetBool(isRunningHash, true);
        }

        //if player is running and stops running or stops walking
        if(isRunning && (!hasMoveInput || !runPressed))
        {
            //then set the isRunning boolean to be false 
            animator.SetBool(isRunningHash, false);
        }

        // if(gatherPressed)
        // {
        //     animator.SetBool(gatheringHash, true);
        // }
        //
        // if (!gatherPressed)
        // {
        //     animator.SetBool(gatheringHash, false);
        // }
        timer += Time.deltaTime;

        if (timer > 0.5)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger(hittingHash);
            
                if (ItemSlot.currentUsedItem == "IronSwordSprite" || 
                    ItemSlot.currentUsedItem == "GoldSwordSprite")
                {
                    SwordAttack.Play();
                }

                timer = 0;
            }
        }
    }
}
