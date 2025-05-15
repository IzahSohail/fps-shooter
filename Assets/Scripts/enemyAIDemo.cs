using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class enemyAIDemo : MonoBehaviour
{
    public IEnemyStateDemo currentState;
    public IdleStateDemo idleState;
    public AlertStateDemo alertState;
    public PatrolStateDemo patrolState;
    public AttackStateDemo attackState;

    public NavMeshAgent agent;
    public Transform player;

    public Material greenMaterial;
    public Transform[] waypoints;

    //for shooting 
    public GameObject bulletPrefab;         // Bullet to instantiate
    public Transform firePoint;             // Where bullet spawns
    public float fireRate = 1f;             // Shots per second
    [HideInInspector] public float nextFireTime = 0f;

    void Start()
    {
        idleState = new IdleStateDemo(this);
        alertState = new AlertStateDemo(this);
        patrolState = new PatrolStateDemo(this);
        attackState = new AttackStateDemo(this);

        currentState = patrolState;

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        currentState.UpdateState();
    }

    void OnTriggerEnter(Collider col) => currentState.OnTriggerEnter(col);
    void OnTriggerStay(Collider col) => currentState.OnTriggerStay(col);
    void OnTriggerExit(Collider col) => currentState.OnTriggerExit(col);
}

