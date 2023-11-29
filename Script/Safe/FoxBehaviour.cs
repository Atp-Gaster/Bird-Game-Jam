using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoxBehaviour : MonoBehaviour
{
    public Animator Anim;
    SpriteRenderer Render;
    Rigidbody2D body;

    private bool isHole = false;


    [Header("Player Setting")]
    public int PlayerType = 0; //0 Carrots, 1 Bunny
    public bool Iskilling = false;
    public int EffectStatus = 0;
    public LunchingSpear lunchingSpear;

    [Header("Setting")]
    public GameManagerScript flie;
    public Vector2 v;

    public AudioClip JumpSound;
    public AudioClip LandingSound;

    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool IsDead;
    [HideInInspector] public bool IsGilde;
    [HideInInspector] public bool EnableGilde;

    public int HP = 0;
    //set this as public
    [HideInInspector] public float Glide;
    public float maxGilde = 3f;
    [SerializeField] Vector2 KnockbackRange = new Vector2(0, 0);
    [SerializeField] Vector2 JumpForce = new Vector2(0, 0);
    [SerializeField] Vector2 Speed = new Vector2(0, 0);
    [SerializeField] float MoveSpeed = 0;
    [SerializeField] GameObject glideGauge;
    private IEnumerator coroutine;

    private bool isLanding = false;
    private bool isRunning = false;
    [SerializeField] GameObject gameManager;



    #region Walking_System
    void Walking_System(int PlayerType)
    {
        if (!IsGrounded)
        {
            StopWalkSoundFx();
        }
        if (PlayerType == 0)
        {
            //Animation Controll
            //Forward
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Animator>().SetBool("IsRun?", true);
                //Anim.SetBool("IsRun?" , true);
                Render.flipX = true;
                isRunning = true;

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                this.GetComponent<Animator>().SetBool("IsRun?", false);
                //Anim.SetBool("IsRun?" , false);
                isRunning = false;
            }
            //Backward
            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<Animator>().SetBool("IsRun?", true);
                Render.flipX = false;
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                this.GetComponent<Animator>().SetBool("IsRun?", false);
                isRunning = false;
            }

            //Lunching Spear Animation
            if (EffectStatus == 1)
            {
                if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q))
                {
                    this.GetComponent<Animator>().SetTrigger("UseSpear");
                    lunchingSpear.LunchSpaer();
                    EffectStatus = 0;
                    killCarrot();

                }
                if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q)) && Input.GetKey(KeyCode.D))
                {
                    this.GetComponent<Animator>().SetTrigger("UseSpear");
                    Render.flipX = true;
                    lunchingSpear.LunchSpaer();
                    EffectStatus = 0;
                    killCarrot();
                }

                if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q)) && Input.GetKey(KeyCode.A))
                {
                    this.GetComponent<Animator>().SetTrigger("UseSpear");
                    Render.flipX = false;
                    lunchingSpear.LunchSpaer();
                    EffectStatus = 0;
                    killCarrot();
                }
            }


            //jump 
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded)
            {
                //fell down system

                Vector2 g = body.velocity;
                g.y = 0;
                body.velocity = g;

                body.AddForce(JumpForce);
                JumpSoundFx();
                isLanding = true;
            }
            if (EnableGilde)
            {
                if (Input.GetKeyDown(KeyCode.S) && (!IsGrounded) && !(IsGilde))
                {
                    GlidingSystem();
                    //StartCoroutine(coroutine);
                    IsGilde = true;

                    body.gravityScale = 0.1f;

                    if (IsGrounded) IsGilde = false;
                }
            }

            if (isLanding && IsGrounded)
            {
                isLanding = false;
                LandingSoundFx();
            }

            //กดค้างยิ่งกระโดสูง
            if (Input.GetKeyUp(KeyCode.W) && body.velocity.y > 0)
            {
                Vector2 v = body.velocity;
                v.y = 0;
                body.velocity = v;
                isLanding = true;
            }

            Anim.SetFloat("Speed.Y", body.velocity.y);//เอาแกน Y ยัดparamiter       

            //Run
            AnimatorStateInfo info = Anim.GetCurrentAnimatorStateInfo(0);
            bool isInRunState = info.IsName("Run");
            if (isRunning)
            {
                WalkSoundFx();
                Vector2 v = body.velocity;

                //Check Direction
                if (Render.flipX)
                {
                    v.x = MoveSpeed * 1;
                }
                else
                {
                    v.x = MoveSpeed * -1;
                }

                body.velocity = v;

            }
            else
            {
                StopWalkSoundFx();
            }
        }
        else if (PlayerType == 1)
        {
            //Animation Controll
            //Forward
            if (Input.GetKey(KeyCode.L))
            {
                //this.GetComponent<Animator>().SetBool("Running", true);
                Anim.SetBool("Running", true);
                Render.flipX = true;
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                //this.GetComponent<Animator>().SetBool("Running", false);
                Anim.SetBool("Running", false);
                isRunning = false;
            }
            //Backward
            if (Input.GetKey(KeyCode.J))
            {
                this.GetComponent<Animator>().SetBool("Running", true);
                Render.flipX = false;
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                this.GetComponent<Animator>().SetBool("Running", false);
                isRunning = false;
            }

            //jump 
            if (Input.GetKeyDown(KeyCode.I) && IsGrounded)
            {
                //fell down system

                Vector2 g = body.velocity;
                g.y = 0;
                body.velocity = g;

                body.AddForce(JumpForce);
                JumpSoundFx();

            }

            if (isLanding && IsGrounded)
            {
                isLanding = false;
                LandingSoundFx();
            }


            //กดค้างยิ่งกระโดสูง
            if (Input.GetKeyUp(KeyCode.I) && body.velocity.y > 0)
            {
                Vector2 v = body.velocity;
                v.y = 0;
                body.velocity = v;
                isLanding = true;
            }

            Anim.SetFloat("Speed.Y", body.velocity.y);//เอาแกน Y ยัดparamiter       

            //Run
            AnimatorStateInfo info = Anim.GetCurrentAnimatorStateInfo(0);
            bool isInRunState = info.IsName("Bunny Run");
            if (isRunning)
            {
                WalkSoundFx();

                Vector2 v = body.velocity;

                //Check Direction
                if (Render.flipX)
                {
                    v.x = MoveSpeed * 1;
                }
                else
                {
                    v.x = MoveSpeed * -1;
                }

                body.velocity = v;

            }
            else
            {
                StopWalkSoundFx();
            }

            if (Input.GetKeyUp(KeyCode.U) || Input.GetKeyUp(KeyCode.O))
            {
                Anim.SetTrigger("IsKill?");
                Iskilling = true;
                killCarrot();

            }
            else
            {
                Iskilling = false;
            }
        }

    }
    //private IEnumerator BunnyKillingSystem()
    //{
    //    yield return new WaitForSeconds(2);
    //    Iskillable = false;
    //}    
    #endregion

    #region ETC
    //Dead system
    public void Death()
    {
        body.simulated = false;
        Anim.SetBool("IsDead?", true);
        IsDead = true; //FoxBehavious               
        if (PlayerType == 0) 
        {
            Invoke("ReloadGame", 3);
        }//Reload Game    
    }

    //Reload Game Call by game Controller
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }

    private void killCarrot()
    {
        
        Collider2D[] colli = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach (Collider2D col in colli)
        {
            
            if (PlayerType == 1 && Iskilling)
            {
                if (col.transform.CompareTag("PlayerCatch"))
                {
                    col.gameObject.GetComponentInParent<FoxBehaviour>().Death();
                }

            }

            Debug.Log(col.transform.tag + " FROM PLAYER TYPE " + PlayerType);
            if (PlayerType == 1 && col.transform.CompareTag("Spear"))
            {
                Debug.Log("Here");
                if (this.GetComponentInChildren<SpriteRenderer>().flipX)
                {
                    KnockbackRange.x = KnockbackRange.x * -999999999;
                    KnockbackRange.y = KnockbackRange.y * 1;
                    body.AddForce(KnockbackRange);
                    Debug.LogWarning(KnockbackRange);
                }
                else
                {
                    KnockbackRange.x = KnockbackRange.x * 9999999999999999999;
                    body.AddForce(KnockbackRange);
                    Debug.LogWarning(KnockbackRange);
                }
                    
            }
        }

    }

    private void rabbitKnockbackChecker()
    {
        Collider2D[] colli = Physics2D.OverlapCircleAll(transform.position, 1);

        foreach (Collider2D col in colli)
        {
            if(col.tag == "Spear")
            {
                if (this.GetComponentInChildren<SpriteRenderer>().flipX)
                {
                    KnockbackRange.x = KnockbackRange.x * -1;
                    KnockbackRange.y = KnockbackRange.y * 1;
                    body.AddForce(KnockbackRange);
                    Debug.LogWarning(KnockbackRange);
                }
                else
                {
                    body.AddForce(KnockbackRange);
                    Debug.LogWarning(KnockbackRange);
                }
            }
        }
    }

    private IEnumerator GlidingSystem()
    {
        Debug.LogWarning("Gliding!");
        body.gravityScale = 0.1f;
        yield return new WaitForSeconds(3);
        body.gravityScale = 1;
        EnableGilde = false;

    }

    //public bool getkillable()
    ///
    ///    return Iskillable;
    //}
    #endregion    

    [SerializeField] GameObject Bunny;
    [SerializeField] GameObject BunnyPanel;
    [SerializeField] Transform [] respawnBunny;

    public void Respawn(int RespawnId)
    {
        if (PlayerType == 1)
        {
            
            GameObject newBunny = Instantiate(Bunny) as GameObject;
            newBunny.GetComponent<FoxBehaviour>().Anim.SetBool("IsDead?", false);
            newBunny.GetComponent<FoxBehaviour>().Anim.SetBool("Respawn", true);
            BunnyPanel.SetActive(false);
            newBunny.transform.position = new Vector3(respawnBunny[RespawnId].position.x, respawnBunny[RespawnId].position.y, -16);
            GameObject.Find("Bunny Camera").GetComponent<CameraFollow>().player = newBunny;
            Destroy(gameObject);//Reload Game  
        }
          
    }

    #region SFX
    //Extend V. - SFX jump
    void JumpSoundFx()
    {
        this.GetComponent<AudioSource>().PlayOneShot(JumpSound);
    }

    void WalkSoundFx()
    {
        if (!this.GetComponent<AudioSource>().isPlaying && IsGrounded)
        {
            this.GetComponent<AudioSource>().Play(0);
        }
    }

    void StopWalkSoundFx()
    {
        if (this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }

    void LandingSoundFx()
    {
        this.GetComponent<AudioSource>().PlayOneShot(LandingSound);
        Debug.Log("Played");
    }
    #endregion





    void Start()
    {
        IsDead = false;
       if (BunnyPanel)
       {
            BunnyPanel = GameObject.Find("DeadPanel");
        }
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        Anim = this.GetComponent<Animator>();
        Render = this.transform.Find("Render").GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();

        Glide = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)//ตัวตัดจบชุดคำสั่ง
        {

            if (PlayerType == 1) 
            {
                Anim.SetBool("IsDead?", true);
                BunnyPanel.SetActive(true);
            }
           // return;
        }

        if (PlayerType == 1)
        {
            rabbitKnockbackChecker();
        }

        if (IsGilde)
        {
            glideGauge.SetActive(true);
            Glide -= 1 * Time.deltaTime;
            if (Glide <= 0 || !IsGilde)
            {
                glideGauge.SetActive(false);
                body.gravityScale = 1;
                IsGilde = false;
                Glide = maxGilde;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && IsGilde)
        {
            glideGauge.SetActive(false);
            IsGilde = false;
            Glide = 3;
            body.gravityScale = 1;
        }

        checkCarrotGoal();

        Walking_System(PlayerType);

        if (isHole)
        {
            if (Input.GetKeyDown(KeyCode.S)){
                gameManager.GetComponent<EndGame>().CarrotWinEnd();
                Debug.Log("this is carrot end");
            }
        }
    }

    public void SetMoveSpeed(float newSpeed)
    {
        MoveSpeed = newSpeed;
    }

    [Header("Carrot's Goal Height")]
    [SerializeField] private float carrotGoal = 130;


    public void checkCarrotGoal()
    {
        if (PlayerType == 0)
        {
            if (gameObject.transform.position.y >= carrotGoal){
                gameManager.GetComponent<EndGame>().BirdWinEnd();
                Debug.Log("this is  bird end");
            }


            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("excalipon")){
            Debug.Log("PON");
             isHole = true;
        }
        if (col.gameObject.CompareTag("Ground")){
            Debug.Log("No PON");
             isHole = false;
        }
    }
}