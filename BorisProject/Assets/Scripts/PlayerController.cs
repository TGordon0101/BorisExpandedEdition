using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public bool b_playerDead = false;

    [SerializeField] private float stamina;
    [SerializeField] private float maxStamina;


    private Rigidbody2D body;
    //public UIScript UI_Obj;
    //public GameObject Pause_Obj;
    //public PauseScript Pause_Script;
    //public GameManager GM_Obj;
    public AudioSource PlayerSound;

    public Animator PlayerAnimation;
    public Animator DeathPlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        maxStamina = 50.0f;
        stamina = maxStamina;
        //UI_Obj = GameObject.Find("EndGameCanvas").GetComponent<UIScript>();
        //GM_Obj = GameObject.Find("GameTrigger").GetComponent<GameManager>();
        //Pause_Obj = GameObject.Find("Pause Canvas");
        //Pause_Script = GameObject.Find("Pause Canvas").GetComponent<PauseScript>();

        //Pause_Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (b_playerDead == true)
            {
                //UI_Obj.YouLose();
            }

            //Player Movement
            if (b_playerDead == false /*&& GM_Obj.b_GameEnd == false*/)
            {
                //Move Camera
                MoveCamera();

                //Look At Mouse
                //LookAtMouse();

                //Move Player
                Move();
            }

            //Player Animations
            if (body.velocity.x != 0 || body.velocity.y != 0) 
            {
                if (Sprint())
                {
                    PlayerAnimation.SetFloat("Speed", 2);
                }
                else
                {
                    PlayerAnimation.SetFloat("Speed", 1);
                }
            }
            else 
            {
                PlayerAnimation.SetFloat("Speed", 0);
                PlayerSound.Play();
            }

            //if (Input.GetKeyDown(KeyCode.Escape)) {
            //    Pause_Script.PauseGame();
            //    Pause_Obj.SetActive(true);

            //    PlayerSound.Pause();
            //}
        }
    }

    //private void LookAtMouse()
    //{
    //    Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.up = (Vector3)(mousePos - new Vector2(transform.position.x, transform.position.y));
    //}

    private void RotatePlayer(Vector2 _wasdInput)
    {
        float x = _wasdInput.x;
        float y = _wasdInput.y;

        if (x == 0 && y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0.0f);
        }
        else if (x == 1 && y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45.0f);
        }
        else if (x == 1 && y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90.0f);
        }
        else if (x == 1 && y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -135.0f);
        }
        else if (x == 0 && y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180.0f);
        }
        else if (x == -1 && y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -225.0f);
        }
        else if (x == -1 && y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -270.0f);
        }
        else if (x == -1 && y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -315.0f);
        }

    }

    private void Move()
    {
        //Get WASD Input
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Rotate Plater
        RotatePlayer(input);

        //Sprint and Decrease Stamina
        if (Sprint() && stamina > 0)
        {
            body.velocity = input.normalized * moveSpeed * 2;
            stamina -= 1.0f / 60.0f;
        }

        //Walk and Increase Stamina
        else
        {
            body.velocity = input.normalized * moveSpeed;
            if (!Sprint())
            {
                stamina += 2.0f / 60.0f;
            }
        }

        //Correct Stamina Values
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if (stamina < 0.0f)
        {
            stamina = 0.0f;
        }
    }

    private bool Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void MoveCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -1.0f);
    }

    public void Die()
    {
        PlayerAnimation.SetBool("Death", true);
        b_playerDead = true;
    }
}
