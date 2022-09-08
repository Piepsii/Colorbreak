using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get { return instance; } }
    public List<GameObject> levels;
    public GameObject activeLevelGO;
    public Level activeLevel;
    public int levelIndex = 0;
    public VoidEventChannelSO gameOverEC;

    private static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        activeLevelGO = Instantiate(levels[levelIndex]);
        activeLevel = activeLevelGO.GetComponent<Level>();
    }

    public void NextLevel()
    {
        levelIndex++;
        if(levelIndex < levels.Count)
        {
            Destroy(activeLevelGO);
            activeLevelGO = Instantiate(levels[levelIndex]);
            activeLevel = activeLevelGO.GetComponent<Level>();
        }
        else
        {
            gameOverEC.RaiseEvent();
        }
    }
}
