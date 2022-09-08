using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public VoidEventChannelSO puzzleSolvedEC;
    public Animator puzzleSolvedAnimator;

    void Start()
    {
        puzzleSolvedEC.OnEventRaised += TriggerPuzzleSolvedUI;
    }

    void TriggerPuzzleSolvedUI()
    {
        puzzleSolvedAnimator.SetTrigger("in");
    }
}
