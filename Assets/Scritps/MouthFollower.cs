using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouthFollower : MonoBehaviour
{
    public GameObject player;
    public Animator pAnimator;
    public List<string> animationStates;
    public float holdTime = 0;
    public float minHoldTime = 0.1f;    

    // Start is called before the first frame update
    public void Start()
    {
        animationStates.Add("OpenMouth" ); 
        animationStates.Add("OpenedMouth");
        animationStates.Add("CloseMouth");
        animationStates.Add("Breathing");
        animationStates.Add("Empty");
        animationStates.Add("HoldBreath");
    }

    

    // Update is called once per frame
    public void Update()
    {
        this.transform.position = player.transform.position;

        if (player.GetComponent<PlayerController>().deepBreathe)
        {
            SetAnimation("OpenMouth");
        }
        if (!player.GetComponent<PlayerController>().deepBreathe)
        {
            SetAnimation("CloseMouth");
        }
        if (player.GetComponent<PlayerController>().holdBreathe)
        {
            SetAnimation("HoldBreath");
        }
        
    }

    


    public void SetAnimation(string anim)
    {
        foreach (string option in animationStates)
        {
            if (option.ToString() != anim)
            {
                pAnimator.SetBool(option.ToString(), false);
            }
        }
        pAnimator.SetBool(anim, true);
    }
}
