using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Player player;
    public Collectible collectible;

    private void Awake() {
        if(instance == null)
            instance = this;
        else
            Destroy(this);

        player = FindObjectOfType<Player>();
    }   
    public static GameManager instance;
    public void OnPlayerDeath(){
        player.enabled = false;
    }

}

public delegate void OnLoose();