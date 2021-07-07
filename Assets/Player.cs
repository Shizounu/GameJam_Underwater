using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shizounu.Library;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    public bool isMoving = false;
    public Vector2 moveDir = Vector2.zero;
    public float speed = 2;

    [Header("references")]
    public Rigidbody2D rb;
    public Controls playerControls;
    public bool isVisible = true;

    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new Controls();
        playerControls.Player.Movement.performed += ctx => {
            isMoving = true;
            moveDir = ctx.ReadValue<Vector2>(); 
        };
        playerControls.Player.Movement.canceled += _ =>{
            isMoving = false;
        };
        playerControls.Player.Grab.performed += _ => {
            Collect();
        };
    }

    void Update()
    {
        if(isMoving)
            Move(moveDir);
        if(!isVisible)
            health--;
    }
    

    
    #region functions
    public void Move(Vector2 dir){
        rb.AddForce(dir * speed);
    }

    public void Collect(){
        Collectible collectible = GameManager.instance.collectible;
        if(this.CanSee(collectible,1.5f)){
            collectible.gameObject.SetActive(false);
        }
    }
    
    
    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        health--;
        Debug.Log("I hit something!");
    }
    void OnBecameInvisible(){
        isVisible = false;
    }
    void OnBecameVisible()
    {
        isVisible = true;
    }
    #endregion

    #region health and damage code
    [Header("Health")]
    public int _health = 3;
    public float immunityTime = 0.5f;
    public bool canTakeDamage = true;


    int health {
        get{return _health;}
        set{
            if(canTakeDamage)
                {
                    _health = value;
                    StartCoroutine(immunity(immunityTime));
                }
            if(health <= 0)
            {
                this.gameObject.SetActive(false);
            }

        }
    }
    IEnumerator immunity(float time){
        canTakeDamage = false;
        yield return new WaitForSeconds(time);
        canTakeDamage = true;
    }
    #endregion

    #region Dont look
    void OnEnable() => playerControls.Enable();
    void OnDisable() => playerControls.Disable();

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Shizounu.Library.Editor.CustomGizmos.DrawClosedArc(transform.position,transform.forward,
            transform.up * -1, 3, 90f);
    }    
    #endregion
}

public delegate void OnDeath();