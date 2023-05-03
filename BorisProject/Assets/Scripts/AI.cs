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

   // public AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Monster_AI_Mesh = GetComponent<NavMeshAgent>();

        Player_Obj = GameObject.FindGameObjectWithTag("Player");
        PlayerController_Obj = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        GameManager_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();
        AI_Obj = GameObject.FindGameObjectWithTag("Enemy");

        AI_Chase = false;

        //SoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AI_Origin = this.transform.position;

        if (AI_Chase == true && GameManager_Obj.b_GameEnd == false && PlayerController_Obj.b_playerDead == false) {
            Target_Position = Player_Obj.transform.position;

            Monster_AI_Mesh.SetDestination(new Vector3(Target_Position.x, Target_Position.y, 1));
            AI_Animation.SetFloat("Speed", 1.0f);
        }
        else {
            AI_Animation.SetFloat("Speed", 0.0f);
            PlaySound();
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
}