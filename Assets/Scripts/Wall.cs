using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Colorbreak.Color color;
    public MaterialDatabase database;

    private Vector2Int position;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        SetMaterial();
    }

    private void OnValidate()
    {
        SetMaterial();
    }

    private void Start()
    {
        position = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
    }

    private void SetMaterial()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        switch (color)
        {
            case Colorbreak.Color.YELLOW:
                meshRenderer.material = database.yellow;

                break;
            case Colorbreak.Color.BLUE:
                meshRenderer.material = database.blue;

                break;
            case Colorbreak.Color.RED:
                meshRenderer.material = database.red;

                break;
            case Colorbreak.Color.PURPLE:
                meshRenderer.material = database.purple;

                break;
            case Colorbreak.Color.PINK:
                meshRenderer.material = database.pink;

                break;
            case Colorbreak.Color.GREEN:
                meshRenderer.material = database.green;

                break;
        }
    }
}
