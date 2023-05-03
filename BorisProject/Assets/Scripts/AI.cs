using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Player_Obj;
    public PlayerController PlayerController_Obj;
    public GameManager GameManager_Obj;
    public GameObject AI_Obj;

    public Vector3 Target_Position;
    public Vector3 AI_Origin;
    public NavMeshAgent Monster_AI_Mesh;

    public Animator AI_Animation;

    public bool AI_Chase;
    public float Distance;
    public float SearchTimer;

   // public AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Monster_AI_Mesh = GetComponent<NavMeshAgent>();

        Player_Obj = GameObject.FindGameObjectWithTag("Player");
        PlayerController_Obj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GameManager_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();
        AI_Obj = GameObject.FindGameObjectWithTag("Enemy");

        AI_Chase = true;

        //SoundEffect = GetComponent<AudioSource>();
        AI_Origin = AI_Obj.transform.position;

        SearchTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(AI_Obj.transform.position, Player_Obj.transform.position);

        //AI_Origin = this.transform.position;

        if (Distance > 25.0f)
        {
            Search();
        }
        else if (Distance < 25.0f) {
            SearchTimer = 10;
            ChasePlayer();
        }

        else {
            AI_Animation.SetFloat("Speed", 0.0f);
            PlaySound();
        }

        if (SearchTimer == 0.0f)
        {
            Wander();
        }

        Vector3 diff = Player_Obj.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
    }

    public void SetBoolChase(bool _Chase)
    {
        AI_Chase = _Chase;
    }

    public void PlaySound()
    {
        //SoundEffect.Play();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            PlayerController_Obj.Die();
        }
    }

    private void ChasePlayer()
    {
        Target_Position = Player_Obj.transform.position;
        Monster_AI_Mesh.SetDestination(new Vector3(Target_Position.x, Target_Position.y, 1));
        AI_Animation.SetFloat("Speed", 1.0f);
    }

    private void Search()
    {
        if(SearchTimer > 0.0f)
        {
            SearchTimer -= Time.deltaTime;
            Monster_AI_Mesh.SetDestination(new Vector3(AI_Obj.transform.position.x, AI_Obj.transform.position.y, 1));
            AI_Animation.SetFloat("Speed", 0.0f);
        }
        else
        {
            SearchTimer = 0.0f;
        }
    }

    private void Wander()
    {
        Monster_AI_Mesh.SetDestination(new Vector3(AI_Origin.x, AI_Origin.y, 1));
        AI_Animation.SetFloat("Speed", 1.0f);
    }
}