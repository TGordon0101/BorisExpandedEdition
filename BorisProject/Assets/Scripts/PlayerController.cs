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

    [SerializeField] public float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] public float Exhaust;
    [SerializeField] public int hp;
    [SerializeField] public float timer = 4;

    private Rigidbody2D body;
    public AudioSource PlayerWalking;

    public Animator PlayerAnimation;
    public Animator DeathPlayerAnimation;

    [SerializeField] AudioSource PickUpSound;
    [SerializeField] AudioSource GruntSound;
    [SerializeField] AudioSource Breathing;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        maxStamina = 5.0f;
        stamina = maxStamina;
        hp = 3;

        PlayerWalking.Play();
        Breathing.Play();
        Breathing.Pause();

        PlayerWalking.pitch = 1.2f;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            //Player Movement
            if (b_playerDead == false)
            {
                //Move Camera
                MoveCamera();

                //Move Player
                Move();
            }

            //Player Animations
            if (body.velocity.x != 0.0f || body.velocity.y != 0.0f)
            {
                if (Sprint() == true && stamina > 0.5f)
                {
                    PlayerAnimation.SetFloat("Speed", 3);

                    PlayerWalking.pitch = 2.25f;
                }
                else
                {
                    PlayerAnimation.SetFloat("Speed", 1);
                    PlayerWalking.pitch = 1.2f;
                }

                PlayerWalking.UnPause();
            }

            else 
            {
                PlayerAnimation.SetFloat("Speed", 0);
                PlayerWalking.Pause();
            }

            if(PlayerAnimation.GetBool("Exhausted") == true && stamina > 0.5f)
            {
                PlayerAnimation.SetBool("Exhausted", false);
            }
        }
    }

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
            Exhaust += 3.0f / 60.0f;
        }

        //Walk and Increase Stamina
        else
        {
            body.velocity = input.normalized * moveSpeed;
            if (!Sprint())
            {
                stamina += 2.0f / 60.0f;
                Exhaust -= 4.0f / 60.0f;
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

        if (Exhaust < 0f)
        {
            Exhaust = 0f;
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

                GruntSound.Play();
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

        if (collision.gameObject.name == "Summon Trap")
        {
            collision.gameObject.GetComponent<Trap>().ShowHint();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Summon Trap")
        {
            collision.gameObject.GetComponent<Trap>().DisableHint();
        }
    }

    private void CheckInventory(Object _object)
    {
        // Check if item is already in inventory
        if (_object != itemOne && _object != itemTwo && _object != itemThree)
        {
            PickUpSound.Play();

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
        if (stamina < 0.5f)
        {
            PlayerAnimation.SetBool("Exhausted", true);
            PlayerAnimation.SetFloat("Speed", 1.0f);
            moveSpeed = 1.5f;
            Breathing.UnPause();
        }

        if (stamina > 3.5f)
        {
            Breathing.Pause();
        }

        else
        {
            moveSpeed = 5;
        }
    }    
}