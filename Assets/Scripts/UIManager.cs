using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public VoidEventChannelSO puzzleSolvedEC;
    public Animator puzzleSolvedAnimator;
    public Image puzzleSolvedBackground;

    public VoidEventChannelSO gameOverEC;
    public GameObject gameOverUI;

    void Start()
    {
        puzzleSolvedEC.OnEventRaised += TriggerPuzzleSolvedUI;
        gameOverEC.OnEventRaised += TriggerGameOverUI;
    }

    void TriggerPuzzleSolvedUI()
    {
        puzzleSolvedAnimator.SetTrigger("in");
        puzzleSolvedBackground.color = LevelManager.Instance.activeLevel.color;
    }

    void TriggerGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
