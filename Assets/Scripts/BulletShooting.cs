using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour{

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    
    

    // Update is called once per frame
    void Update(){
      
        this.transform.localScale -= (new Vector3(0.1f, 0.1f, 0.1f));
    }
}
