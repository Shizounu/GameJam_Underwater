using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(BoxCollider2D))]
public class EndZone : MonoBehaviour
{
    public int nextLevel;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(GameManager.instance.player.raisedEndFlag)
            SceneManager.LoadScene(nextLevel);
    }
}
