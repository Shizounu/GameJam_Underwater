using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] [RequireComponent(typeof(CircleCollider2D))]
public class Expandyboi : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite bigBoi;
    public Sprite smolBoi;
    public float swapTime = 3.5f;
    [Header("References")]
    public SpriteRenderer renderBoi;
    public CircleCollider2D hitBoi;
    public float passedTime;
    public bool isBig;

    void Awake()
    {
        renderBoi = GetComponent<SpriteRenderer>();
        hitBoi = GetComponent<CircleCollider2D>();
    }

    public void makeSmol(){
        renderBoi.sprite = smolBoi;
        hitBoi.radius = 1;
        isBig = false;
    }
    public void makeBig(){
        renderBoi.sprite = bigBoi;
        hitBoi.radius = 2;
        isBig = true;
    }

    void Update(){
        if(passedTime < swapTime){
            passedTime += Time.deltaTime;
        } else {
            if(isBig)
                makeSmol();
            else 
                makeBig();
            passedTime = 0;
        }
    }
}
