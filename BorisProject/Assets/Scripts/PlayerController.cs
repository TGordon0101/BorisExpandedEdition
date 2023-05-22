using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Object itemOne;
    [SerializeField] public Object itemTwo;
    [SerializeField] public Object itemThree;

    public float moveSpeed;
    public bool b_playerDead = false;

    [SerializeField] private float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] public int hp;
    [SerializeField] public float timer = 4;

    private Rigidbody2D body;
    //public GameManager GM_Obj;
    public AudioSource PlayerSound;

    public Animator PlayerAnimation;
    public Animator DeathPlayerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        maxStamina = 5.0f;
        stamina = maxStamina;
        hp = 3;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
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
                if (Sprint() == true)
                {
                    PlayerAnimation.SetFloat("Speed", 2);
                    FindObjectOfType<AudioManager>().Play("Player_Sprint");
                }
                else
                {
                    PlayerAnimation.SetFloat("Speed", 1);
                    FindObjectOfType<AudioManager>().Play("Player_Walk");
                }
            }
            else 
            {
                PlayerAnimation.SetFloat("Speed", 0);
                //PlayerSound.Play();
            }
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
        Stagger();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Monster")
        {
            Vector2 dir = (collision.transform.position - transform.position).normalized;
            Vector2 force = dir * 50;

            if (hp != 0)
            {
                hp -= 1;
                collision.gameObject.GetComponent<AI>().GetComponent<Rigidbody2D>().AddForce(force, (ForceMode2D)ForceMode.Impulse);
            }

            else
            {
                Die();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            // Check invetneory function
            CheckInventory(collision.gameObject.GetComponent<Object>());
        }
    }

    private void CheckInventory(Object _object)
    {
        // Check if item is already in inventory
        if (_object != itemOne && _object != itemTwo && _object != itemThree)
        {
            // if the item in slot one is null, set collided object to first slot
            // Repeat for all three slots
            if (itemOne == null)
            {
                itemOne = _object;
            }

            else if (itemTwo == null)
            {
                itemTwo = _object;
            }

            else if (itemThree == null)
            {
                itemThree = _object;
            }

            else
            {
                Debug.Log("Did not pick up");
            }
        }
    }

    public void Stagger()
    {
        if (stamina < 0.5f )
        {
            moveSpeed = 1.5f;
        }
        else
        {
            moveSpeed = 5;
        }
    }    
}