using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float speed = 12.0f;
    Rigidbody2D rigidbody2d;

    public int maxHealth = 5;
    public int currentHealth;

    public float timeInvincible = 2.0f;
    public bool isInvincible;
    float invincibleTimer;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    private NodeMenager nodeMenager;
    private resourceMenager resourceMenager;
    private storageMenager storageMenager;
    private sawmillMenager sawmillMenager;
    private blacksmithMenager blacksmithMenager;
    private conveyorBeltManager conveyorBeltManager;
    private mechanicMenager mechanicMenager;
    private architectMenager architectMenager;

    private buildingMenager buildingMenager;

    public Transform holdPoint;

    private bool fullHand = false;
    private bool isEPressed = false;
    
    public int health { get { return currentHealth; } }

    public bool FullHand { get => fullHand; set => fullHand = value; }

    public Image ePanel, escPanel, mainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        ePanel.GetComponent<Image>();
        ePanel.gameObject.SetActive(false);
        escPanel.GetComponent<Image>();
        escPanel.gameObject.SetActive(false);
        mainCanvas.GetComponent<Image>();
        mainCanvas.gameObject.SetActive(true);


        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        FindObjectOfType<resourceQuantity>().setArchitect(FindObjectOfType<resourceQuantity>().getArchitect() + 1);
        FindObjectOfType<resourceQuantity>().setMaxSpace(FindObjectOfType<resourceQuantity>().getMaxSpace() + 1);
        FindObjectOfType<resourceQuantity>().setCurrentQuantity(FindObjectOfType<resourceQuantity>().getCurrentQuantity() + 1);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;
        position = position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
        Vector3 zposition = new Vector3(position.x, position.y, transform.position.y * 0.1f);
        transform.position = zposition;


        if (Input.GetKeyDown(KeyCode.X))
        {
            //animator.Play("Hit");
            Harvest();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            //animator.Play("Hit");
            pickUp();
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            useBuilding();
        }

        else if(Input.GetKeyDown(KeyCode.R))
        {
            buildingRotation();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && !isEPressed)
        {
            FindObjectOfType<UIMenager>().setPanelVisibility(escPanel);
            FindObjectOfType<UIMenager>().setPanelVisibility(mainCanvas);
        }

        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape) && isEPressed)
        {
            isEPressed = !isEPressed;
            FindObjectOfType<UIMenager>().setPanelVisibility(ePanel);
            FindObjectOfType<UIMenager>().setPanelVisibility(mainCanvas);
        }

        

        if (fullHand)
        {
            resourceMenager.transform.position = new Vector3( holdPoint.position.x, holdPoint.position.y, transform.position.y*0.1f);
            resourceMenager.GetComponent<Collider2D>().enabled = false;
        }
            
    }

    public void useBuilding()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Building"));
        if (hit.collider != null)
        {
            GameObject beenHit = hit.collider.gameObject;

            buildingMenager = beenHit.GetComponent<buildingMenager>();
            if(!buildingMenager.isPanelShowing && buildingMenager.isPlaced)
            {
                buildingMenager.isPanelShowing = true;
                if (hit.collider.tag == "Architect" || hit.collider.tag == "Deposit" || hit.collider.tag == "Sawmill" || hit.collider.tag == "blacksmith" || hit.collider.tag == "Mechanic" || hit.collider.CompareTag("Shop"))
                {
                    FindObjectOfType<UIMenager>().setPanelVisibility(buildingMenager.panelRetrive);
                }
            }         
        }
    }
    public void Harvest()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Resources"));
        if (hit.collider != null)
        {

            GameObject resorce = hit.collider.gameObject;
            nodeMenager = resorce.GetComponent<NodeMenager>();
            nodeMenager.ResourceHealt--;

            Debug.Log("resource healt " + nodeMenager.ResourceHealt);
        }
    }

    public void pickUp()
    {
        if(!fullHand)
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Ores"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                GameObject resorce = hit.collider.gameObject;
                resourceMenager = resorce.GetComponent<resourceMenager>();
                fullHand = true;
                              
            }
        }
        else
        {
            fullHand = false;
            resourceMenager.GetComponent<Collider2D>().enabled = true;
        }
        
    }

    public void buildingRotation()
    {      
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Building"));
        if (hit.collider != null)
        {           
            GameObject beenHit = hit.collider.gameObject;

            if (hit.collider.tag == "Belt")
            {
                conveyorBeltManager = beenHit.GetComponent<conveyorBeltManager>();
                conveyorBeltManager.rotateBelt();
            }
            else if (hit.collider.tag == "Architect" || hit.collider.tag == "Shop" || hit.collider.tag == "Sawmill" || hit.collider.tag == "blacksmith" || hit.collider.tag == "Deposit" || hit.collider.tag == "Mechanic" || hit.collider.tag == "Power")
                FindObjectOfType<buildingMenager>().rotateBuilding();
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
