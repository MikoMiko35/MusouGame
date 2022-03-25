using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTest : MonoBehaviour
{
    //https://unity-guide.moon-bear.com/navmeshagent/
    [SerializeField]
    Transform target;
    NavMeshAgent agent;
    bool damaged = false;
    float hp = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!damaged)agent.SetDestination(target.position);
    }

    public void Damaged(Vector3 playerPos)
    {
        damaged = true;
        this.GetComponent<NavMeshAgent>().enabled = false;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Vector3 forceDir =  this.transform.position - playerPos;
        //forceDir = new Vector3(0,1,0);
        rb.AddExplosionForce(200, playerPos + new Vector3(0,-3,0), 20);
        StartCoroutine("ReturnNav");
        hp--;
        if (hp < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ReturnNav()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<CapsuleCollider>().isTrigger = false;
    }
        
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            damaged = false;
            this.GetComponent<NavMeshAgent>().enabled = true;
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            this.GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }
}