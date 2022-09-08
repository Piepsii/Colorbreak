using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RotationAxis
{
    X, Y, Z
};

public class Tile : MonoBehaviour
{

    public bool isBlocked;

    public bool isRotating;
    public RotationAxis rotationAxis;
    public int rotationAmount;
    
    public Vector2Int position;
    private Vector2Int previousCubePosition;

    private void Start()
    {
        if (isBlocked)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        Grid.instance.tiles.Add(this);
        position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
    }

    private void Update()
    {
        Cube cube = FindObjectOfType<Cube>();
        if (cube.Position == position && previousCubePosition != cube.Position)
        {
            if (isRotating)
            {
                cube.Rotate(rotationAxis, rotationAmount);
            }
        }
        previousCubePosition = cube.Position;
    }
}
