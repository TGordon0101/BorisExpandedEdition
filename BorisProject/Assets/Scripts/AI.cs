using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public GameObject Player_Obj;
    public GameObject TrapObj;
    public Rigidbody2D AIrb;

    public Vector3 Target_Position;
    public Transform Location_Position;

    public NavMeshAgent Monster_AI_Mesh;
    public Animator AI_Animation;
    public AILocation Locations_List;
    public AudioSource Sneer;
    public AudioSource Walking;

    public bool AI_Chase;
    public float Distance;
    public float SearchTimer;
    public bool SneerTime = false;

    void Start()
    {
        Monster_AI_Mesh = GetComponent<NavMeshAgent>();
        Player_Obj = GameObject.FindGameObjectWithTag("Player");
        Location_Position = GameObject.Find("Location 3").GetComponent<Transform>();
        Locations_List = GameObject.Find("Travel Locations").GetComponent<AILocation>();
        AIrb = GameObject.Find("Monster").GetComponent<Rigidbody2D>();

        AI_Chase = true;

        //transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        SearchTimer = 10;

        Walking.Play();
    }

    void Update()
    {
        if (AI_Animation.GetBool("Dead") == false)
        {
            Distance = Vector3.Distance(this.transform.position, Player_Obj.transform.position);

            if (Distance > 25.0f)
            {
                if(SneerTime == false)
                {
                    Sneer.Play();
                    SneerTime = true;
                }
               
                Search();
            }

            else if (Distance < 25.0f)
            {
                SearchTimer = 10;
                ChasePlayer();
                SneerTime = false;
            }

            else
            {
                Walking.Pause();
                AI_Animation.SetFloat("Speed", 0.0f);
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

        else
        {
            Monster_AI_Mesh.transform.rotation = Quaternion.Euler(0, 0, 0);
            Monster_AI_Mesh.transform.position = new Vector3(13.58806f, 58.79728f, -0.3066633f);
        }
    }

    public void SetBoolChase(bool _Chase)
    {
        AI_Chase = _Chase;
    }

    public void PlaySound()
    {
    }

    private void ChasePlayer()
    {
        Target_Position = Player_Obj.transform.position;
        Monster_AI_Mesh.SetDestination(new Vector3(Target_Position.x, Target_Position.y, 1));
        AI_Animation.SetFloat("Speed", 1.0f);
        Walking.UnPause();
    }

    private void Search()
    {
        if (SearchTimer > 0.0f)
        {
            SearchTimer -= Time.deltaTime;
            Monster_AI_Mesh.SetDestination(new Vector3(this.transform.position.x, this.transform.position.y, 1));
            AI_Animation.SetFloat("Speed", 0.0f);
            Walking.Pause();
        }

        else
        {
            SearchTimer = 0.0f;
        }
    }

    private void Wander()
    {
        Monster_AI_Mesh.SetDestination(Location_Position.position);
        float Dis = Vector3.Distance(Location_Position.position, this.transform.position);

        if (Dis < 7.0f)
        {
            Location_Position = Locations_List.GetLocation();
        }

        AI_Animation.SetFloat("Speed", 1.0f);
        Walking.UnPause();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Summon Trap")
        {
            if (collision.gameObject.GetComponent<Trap>().primed == true)
            {
                AI_Chase = false;

                AI_Animation.SetBool("Dead", true);
                TrapObj = collision.gameObject;
            }
        }
    }

    public void EndGame()
    {
        TrapObj.GetComponent<Trap>().endGame = true;
    }

    public void ChangeLocation()
    {
        Vector3 NewLoc = Locations_List.GetLocation().position;
        float dis = Vector3.Distance(NewLoc, Player_Obj.transform.position);

        while (dis <= 40f)
        {
            NewLoc = Locations_List.GetLocation().position;
            dis = Vector3.Distance(NewLoc, Player_Obj.transform.position);
        }

        transform.position = NewLoc;
    }
}