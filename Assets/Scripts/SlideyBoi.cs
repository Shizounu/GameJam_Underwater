using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class SlideyBoi : MonoBehaviour
{
    [Header("Stats")]
    public float distance = 5f;
    public float speed = 1.2f;
    [Header("refs")]
    public float swamDistance = 0f;
    public bool isGoingLeft = true;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        if(swamDistance < distance){
            if(isGoingLeft)
                this.transform.position += new Vector3(
                    speed * Time.deltaTime,
                    0,
                    0
                );
            else
                this.transform.position += new Vector3(
                    -speed * Time.deltaTime,
                    0,
                    0
                );
            swamDistance += Time.deltaTime * speed;
        } else {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            swamDistance = 0f;
            isGoingLeft = !isGoingLeft;
        }
    } 


    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if(isGoingLeft)
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(transform.position.x + distance,0,0));
        else
           Gizmos.DrawLine(transform.position, transform.position - new Vector3(transform.position.x + distance,0,0)); 
    }
}
