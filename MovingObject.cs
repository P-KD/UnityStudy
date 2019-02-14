using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public string characterName;

    public BoxCollider2D boxColider;

    public LayerMask layerMask;

    public float speed;

    public int walkCount;

    protected int currentWalkCount;

    protected Vector3 vector;

    public Animator animator;

    protected bool CheckCollsion()
    {
        RaycastHit2D hit;


        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);


        boxColider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxColider.enabled = true;


        if (hit.transform != null)
            return true;
        return false;
    }
}

