using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour{
    public void OnCollect(){
        this.gameObject.SetActive(false);
    }
}
