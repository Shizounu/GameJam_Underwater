using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class upyboi : MonoBehaviour
{
    [Header("Stats")]
    public float distance = 5f;
    public float speed = 1.2f;
    [Header("refs")]
    public float swamDistance = 0f;
    public bool isGoingUp = true;
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate() {
        if(swamDistance < distance){
            if(isGoingUp)
                this.transform.position += new Vector3(
                    0,
                    speed * Time.deltaTime,
                    0
                );
            else
                this.transform.position += new Vector3(
                    0,
                    -speed * Time.deltaTime,
                    0
                );
            swamDistance += Time.deltaTime * speed;
        } else {
            spriteRenderer.flipY = !spriteRenderer.flipY;
            swamDistance = 0f;
            isGoingUp = !isGoingUp;
        }
    } 
}
