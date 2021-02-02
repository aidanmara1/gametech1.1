using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBPBody : MonoBehaviour
{
    public int bS = 1;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { //head
            player temp = other.GetComponent<player>();
            temp.bodyStage = bS;
            Destroy(gameObject);
        }
    }
}
