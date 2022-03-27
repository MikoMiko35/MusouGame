using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponer : MonoBehaviour
{
    [SerializeField]private GameObject enemy;
    [SerializeField] private GameObject sponer;
    [SerializeField] private Transform player;
    [SerializeField] private float time = 1.0f;
    [SerializeField] private int enemyRemain = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            enemySpon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            enemyRemain--;
            time = 0.5f + time;
            enemySpon();
            if (enemyRemain < 0) {
                Destroy(sponer);
                this.enabled = false;
            }
        }
    }

    private void enemySpon()
    {
        GameObject go = Instantiate(enemy) as GameObject;
        go.transform.parent = this.transform;
        go.transform.position = sponer.transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
        go.GetComponent<EnemyMoveTest>().target = player;
        float scale = Random.Range(0.7f, 1.3f);
        go.transform.localScale = new Vector3(scale, scale, scale);
    }
}
