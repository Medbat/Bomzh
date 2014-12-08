using UnityEngine;
using System.Collections;

public class PostHardcoreHeroScript : MonoBehaviour
{
    public MamkaScript Mom;
    public ChildScript child;
    public Inventory inventory;

    // движение
	public float Speed = 10f;
    public float SprintSpeed = 20f;
    private float CurrentSpeed = 10f;
	public Vector2 move;
	bool facingRight = true;

    // счет
    private int foodCount = 0;

    // спринт
    private float SprintTime = 1f;
    private float CurrentSprintTime = 0f;
    private float SprintCooldown = 5f;
    private float CurrentSprintCooldown = 0;

    // таймеры
    public float globalTimer = 60f;
    private float maxFoodTimer = 0.3f;
    private float currentFoodTimer;

    private bool momSpawned = false;

	// Use this for initialization
	void Start ()
	{
        globalTimer = 30f;
	}

	void FixedUpdate()
	{
	    move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	    float f = Input.GetAxis("4-axis");
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = new Vector2 (move.x * CurrentSpeed, move.y * CurrentSpeed);
		if (facingRight && move.x < 0 || !facingRight && move.x > 0)
						Flip ();

	    if (CurrentSprintCooldown <= 0 && Input.GetKeyDown(KeyCode.Joystick1Button5))
	    {
            Debug.Log("11");
            CurrentSprintTime = SprintTime;
	        CurrentSpeed = SprintSpeed;
	        CurrentSprintCooldown = SprintCooldown;
	    }
	    if (CurrentSprintTime > 0)
	    {
	        CurrentSprintTime -= Time.deltaTime;
            if (CurrentSprintTime <= 0)
    	        CurrentSpeed = Speed;
	    }
	    if (CurrentSprintCooldown > 0)
        {
            CurrentSprintCooldown -= Time.deltaTime;
	    }

	    if (globalTimer > 0)
	        globalTimer -= Time.deltaTime;

	    if (currentFoodTimer > 0)
	        currentFoodTimer -= Time.deltaTime;

	    if (globalTimer < 20 && !momSpawned)
	    {
            MamkaScript someObj = Instantiate(Mom) as MamkaScript;
	        someObj.bomzh = transform;
	        someObj.child = child;
	        momSpawned = true;
	    }
	        
            
		if (Input.GetKeyDown (KeyCode.R))
						Application.LoadLevel (Application.loadedLevel);
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale; 
	}

	void OnCollisionEnter2D(Collision2D col)
	{
	    if (col.gameObject.tag == "Killer")
        {
            inventory.Save(new Vector3(0, foodCount, 0));
	        Application.LoadLevel("MainScene");
	    }
	    if (col.gameObject.tag == "food" && currentFoodTimer <= 0)
	    {
	        foodCount++;
	        currentFoodTimer = maxFoodTimer;
	    }
	}

    void OnGUI()
    {
        GUI.Box(new Rect(5, 5, 200, 50), "Еды награблено: " + foodCount + "\nВремени осталось: " + (int)globalTimer);
    }
}
