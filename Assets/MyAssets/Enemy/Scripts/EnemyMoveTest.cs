using KanKikuchi.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveTest : MonoBehaviour
{
    //https://unity-guide.moon-bear.com/navmeshagent/
    [SerializeField]
    public Transform target;
    NavMeshAgent agent;
    bool damaged = false;
    float hp = 10;
    float maxhp = 10;
    [SerializeField] GameObject Effect;
    private const float attackRange = 2.0f;
    bool attacking = false;
    [SerializeField] RectTransform hpgauge;
    [SerializeField] Canvas canvas;
    [SerializeField] public Renderer targetRenderer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged || attacking) return;
        if (target == null) return;

        agent.SetDestination(target.position);
        if (agent.remainingDistance < attackRange)
        {
            Attacking();
        }
        else
        {
            
        }
        canvas.transform.rotation =
            Camera.main.transform.rotation;
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
        hpgauge.localScale = new Vector3(hp/maxhp, 1, 1);
        if (hp < 0)
        {
            EnemySponer.Instance.EnemyDead(this);
            SEManager.Instance.Play(SEPath.SYSTEM24);
            Destroy(this.gameObject);
        }
        else
        {
            SEManager.Instance.Play(SEPath.SYSTEM25);
        }
    }
    private void Attacking()
    {
        attacking = true;
        StartCoroutine("AttackPhase");
    }

    private IEnumerator ReturnNav()
    {
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<CapsuleCollider>().isTrigger = false;
    }

    private IEnumerator AttackPhase()
    {
        yield return new WaitForSeconds(0.8f);
        SEManager.Instance.Play(SEPath.SYSTEM26);
        this.GetComponent<Animator>().SetBool("Attack", true);
        GameObject effect = Instantiate(Effect) as GameObject;
        effect.transform.parent = this.transform;
        effect.transform.position = this.transform.position + new Vector3(0,0.5f,0);
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<Animator>().SetBool("Attack", false);
        attacking = false;
        effect.GetComponent<SphereCollider>().enabled = false;
        //yield return new WaitForSeconds(0.8f);
        Destroy(effect);
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