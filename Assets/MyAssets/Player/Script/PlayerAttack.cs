using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //AttackManager AttackManager;
    [SerializeField]Transform SpawnPlace;
    [SerializeField]GameObject Effect; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Attack");
        }
    }

    private IEnumerator Attack()
    {
        this.GetComponent<Animator>().SetBool("Attack", true);
        GameObject effect = Instantiate(Effect) as GameObject;
        effect.transform.parent = this.transform;
        effect.transform.position = SpawnPlace.position;
        yield return new WaitForSeconds(0.2f);
        effect.GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        Destroy(effect);
        this.GetComponent<Animator>().SetBool("Attack", false);
    }
}
