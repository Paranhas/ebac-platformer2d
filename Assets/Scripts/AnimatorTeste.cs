using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTeste : MonoBehaviour
{
    public Animator animator;
    public KeyCode keyToTrigger = KeyCode.A;
    public string triggerToPlay = "Fly";

    public void OnValidate()
    {
        if(animator == null) animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(keyToTrigger))
        {
            animator.SetTrigger(triggerToPlay);
        }
        
    }
}
