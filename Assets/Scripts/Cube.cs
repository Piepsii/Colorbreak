using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool canMove = true;
    public bool blockedForward = false;
    public bool blockedBack = false;
    public bool blockedLeft = false;
    public bool blockedRight = false;

    public float moveSpeed = 0.2f;
    private float moveCounter = 0f;
    private float rotatedSpeed;
    private float rotatedCounter;
    private bool isMoving = false, isRotated = false;
    private Vector3 currentPosition, nextPosition, movedPosition;
    private Quaternion currentRotation, nextRotation, rotatedRotation;

    private Vector2Int position;

    KeyCode keyForward = KeyCode.W;
    KeyCode keyLeft = KeyCode.A;
    KeyCode keyBack = KeyCode.S;
    KeyCode keyRight = KeyCode.D;
    KeyCode altKeyForward = KeyCode.UpArrow;
    KeyCode altKeyLeft = KeyCode.LeftArrow;
    KeyCode altKeyBack = KeyCode.DownArrow;
    KeyCode altKeyRight = KeyCode.RightArrow;

    public Vector2Int Position { get => position; }

    public void Rotate(RotationAxis axis, int amount)
    {
        isRotated = true;
        switch (axis)
        {
            case RotationAxis.X:
                rotatedRotation = Quaternion.Euler(new Vector3(amount * 90, 0, 0)) * currentRotation;
                break;
            case RotationAxis.Y:
                rotatedRotation = Quaternion.Euler(new Vector3(0, amount * 90, 0)) * currentRotation;
                break;
            case RotationAxis.Z:
                rotatedRotation = Quaternion.Euler(new Vector3(0, 0, amount * 90)) * currentRotation;
                break;
        }

    }

    private void Awake()
    {
        rotatedSpeed = moveSpeed;
        position = new Vector2Int(Mathf.RoundToInt(transform.parent.position.x), Mathf.RoundToInt(transform.parent.position.z));
    }

    private void Update()
    {
        CheckSurroundings();
        Move();
    }

    private void CheckSurroundings()
    {
        blockedForward = blockedBack = blockedLeft = blockedRight = false;
        Tile north = Grid.instance.GetTile(new Vector2Int(position.x, position.y + 1));
        if (north.isBlocked)
        {
            blockedForward = true;
        }
        Tile south = Grid.instance.GetTile(new Vector2Int(position.x, position.y - 1));
        if (south.isBlocked)
        {
            blockedBack = true;
        }
        Tile west = Grid.instance.GetTile(new Vector2Int(position.x - 1, position.y));
        if (west.isBlocked)
        {
            blockedLeft = true;
        }
        Tile east = Grid.instance.GetTile(new Vector2Int(position.x + 1, position.y));
        if (east.isBlocked)
        {
            blockedRight = true;
        }
    }

    private void Move()
    {
        if (isMoving)
        {
            if(moveCounter < moveSpeed)
            {
                moveCounter += Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }

            transform.parent.position = Vector3.Lerp(currentPosition, nextPosition, moveCounter / moveSpeed);
            transform.rotation = Quaternion.Lerp(currentRotation, nextRotation, moveCounter / moveSpeed);
        }
        else if (isRotated)
        {
            if (rotatedCounter < rotatedSpeed)
            {
                rotatedCounter += Time.deltaTime;
            }
            else
            {
                isRotated = false;
            }
            transform.rotation = Quaternion.Lerp(currentRotation, rotatedRotation, rotatedCounter / rotatedSpeed);
        }
        else
        {
            position = new Vector2Int(Mathf.RoundToInt(transform.parent.position.x), Mathf.RoundToInt(transform.parent.position.z));
            moveCounter = 0f;
            rotatedCounter = 0f;
            currentPosition = transform.parent.position;
            currentRotation = transform.rotation;
            if ((Input.GetKeyDown(keyForward) || Input.GetKeyDown(altKeyForward)) && !blockedForward)
            {
                nextPosition = transform.parent.position + new Vector3(0, 0, 1);
                nextRotation = Quaternion.Euler(new Vector3(90, 0, 0)) * transform.rotation;
                isMoving = true;
            }
            else if ((Input.GetKeyDown(keyLeft) || Input.GetKeyDown(altKeyLeft)) && !blockedLeft)
            {
                nextPosition = transform.parent.position + new Vector3(-1, 0, 0);
                nextRotation = Quaternion.Euler(new Vector3(0, 0, 90)) * transform.rotation;
                isMoving = true;
            }
            else if ((Input.GetKeyDown(keyRight) || Input.GetKeyDown(altKeyRight)) && !blockedRight)
            {
                nextPosition = transform.parent.position + new Vector3(1, 0, 0);
                nextRotation = Quaternion.Euler(new Vector3(0, 0, -90)) * transform.rotation;
                isMoving = true;
            }
            else if ((Input.GetKeyDown(keyBack) || Input.GetKeyDown(altKeyBack)) && !blockedBack)
            {
                nextPosition = transform.parent.position + new Vector3(0, 0, -1);
                nextRotation = Quaternion.Euler(new Vector3(-90, 0, 0)) * transform.rotation;
                isMoving = true;
            }
        }

    }
}
