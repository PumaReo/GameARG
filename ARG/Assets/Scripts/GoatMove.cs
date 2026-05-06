using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatMove : MonoBehaviour
{
    public Animator _animator;
    public ThirdPersonController thirdPersonController;

    private void Update()
    {
        Debug.Log(thirdPersonController.currentSpeed);
        _animator.SetFloat("Speed", thirdPersonController.currentSpeed);
    }
}
