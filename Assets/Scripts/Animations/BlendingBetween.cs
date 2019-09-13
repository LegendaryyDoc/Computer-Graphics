using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendingBetween : MonoBehaviour
{
    public Dropdown movement;

    private Animator anim;
    private int movementValBefore;

    private void Start()
    {
        anim = GetComponent<Animator>();
        movementValBefore = movement.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementValBefore != movement.value)
        {
            movementValBefore = movement.value;
            anim.SetInteger("Change", movement.value);
        }
    }
}
