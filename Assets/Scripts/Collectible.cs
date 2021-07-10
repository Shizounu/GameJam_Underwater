using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{

    void OnCollisionEnter2D(Collision2D other)
    {
        this.gameObject.SetActive(false);
        GameManager.instance.player.raisedEndFlag = true;
    }
}
