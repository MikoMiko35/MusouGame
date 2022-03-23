using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExplode : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") {
            StartCoroutine(Explodion(other));
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
