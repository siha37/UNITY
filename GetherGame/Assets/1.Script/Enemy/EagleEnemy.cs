using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : MonoBehaviour
{
    public GameObject Exprotion;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "FLOOT")
        {
            DieEnemy();
        }
    }
    public void DieEnemy()
    {
        Instantiate(Exprotion, this.transform.position, Quaternion.identity, null);
        Destroy(this.gameObject);
    }
}
