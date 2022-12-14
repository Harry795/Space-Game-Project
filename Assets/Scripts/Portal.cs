using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int whereToGo;

    // Use this for initialization 
    void Start()
    {
    }

    // Update is called once per frame 
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, 1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gob = collision.gameObject;
        Rigidbody2D colrig;

        if (gob.tag == "Asteroid")
        {
            colrig = gob.GetComponent<Rigidbody2D>();

            colrig.AddForce(this.gameObject.transform.up * 500);
            colrig.AddTorque(Random.Range(-10, 10));
        }

        if (gob.tag == "Player")
        {

            SceneManager.LoadScene(whereToGo);
        }
    }
}