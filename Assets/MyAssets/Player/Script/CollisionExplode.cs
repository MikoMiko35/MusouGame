using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExplode : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    [SerializeField] String tagName = "Enemy";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagName) {
            StartCoroutine(Explodion(other));
            if (tagName == "Enemy") other.GetComponent<EnemyMoveTest>().Damaged(this.transform.position);
            if (tagName == "Player") other.GetComponent<PlayerMove>().Damaged(this.transform.position);
        }
    }

    private IEnumerator Explodion(Collider other)
    {
        GameObject explode = Instantiate(Explode) as GameObject;
        explode.transform.position = other.transform.position;
        yield return new WaitForSeconds(1);
        Destroy(explode);
    }
}
