using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class EnemyNav : MonoBehaviour
{
    public Transform[] points;
    private Transform player;
    int destPoint = 0;
    NavMeshAgent agent;

    private EnemyState _currentState;

    public bool visible = false;
    [SerializeField]
    float puzzledDuration = 1.5f;
    float puzzledEndTime = 0;

    public AudioSource walkingAudio;
    public AudioSource alarmedAudio;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;

        agent.autoBraking = false;
        /*GotoNextPoint();*/
    }

    void GotoNextPoint()
    {
        walkingAudio.volume = 0.8f;
        alarmedAudio.volume = 0;
        agent.speed =12;
        if (points.Length == 0)
            return;
        
            agent.destination = points[destPoint].position;
            destPoint = (destPoint + 1) % points.Length;

    }

    public void ChasePlayer()
    {
        walkingAudio.volume = 0;
        alarmedAudio.volume = 1;
        agent.speed = 38;
        agent.angularSpeed = 900;
        agent.acceleration = 20;
        agent.destination = player.position;
    }

    private void Update()
    {   switch (_currentState)
        {
            case EnemyState.Patrol:
                {
                    alarmedAudio.volume = 0;
                    puzzledEndTime = 0;
                    if (!agent.pathPending && agent.remainingDistance < 1f)
                        GotoNextPoint();
                    if (visible == true)
                    {
                        _currentState = EnemyState.Chase;
                    }
                    break;
                }
            case EnemyState.Chase:
                {
                    puzzledEndTime = 0;
                    ChasePlayer();
                    if (visible == false)
                    {
                        _currentState = EnemyState.Puzzled;
                    }
                    break;
                }
            case EnemyState.Puzzled:
                {
                    walkingAudio.volume = 0;
                    alarmedAudio.volume = 0;
                    if(puzzledEndTime == 0)
                    puzzledEndTime = Time.time + puzzledDuration;
                    agent.isStopped = true;
                        if (visible == true)
                    {
                        agent.isStopped = false;
                        _currentState = EnemyState.Chase;
                    } else if (visible == false && Time.time>=puzzledEndTime)
                    {
                        agent.isStopped = false;
                        GotoNextPoint();
                        _currentState = EnemyState.Patrol;
                    }
                    break;
                }
        }   

        /*if (!agent.pathPending && agent.remainingDistance < 1f && visible ==false)
            GotoNextPoint();*/
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if(other.gameObject.tag == "Player")
        {
            AnalyticsResult analyticsResult= Analytics.CustomEvent("GameOver" + gameObject.name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public enum EnemyState
    {
        Patrol,
        Chase,
        Puzzled
    }
}
