using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingMenager : MonoBehaviour
{
    public int healt;
    public int capability = 50;

    public bool isPlaced = false;
    public bool isPanelShowing = false;

    public Image panelRetrive;

    public string resourceType;

    public Button closeB, pickupB, moveB;

    // Start is called before the first frame update
    void Start()
    {

        panelRetrive.gameObject.SetActive(false);

        closeB.GetComponent<Button>();
        closeB.onClick.AddListener(delegate { close(); });

        pickupB.GetComponent<Button>();
        pickupB.onClick.AddListener(delegate { pickup(); });

        moveB.GetComponent<Button>();
        moveB.onClick.AddListener(delegate { 
            isPlaced = false;

            FindObjectOfType<builderMenager>().setResourceType(resourceType);
            FindObjectOfType<builderMenager>().move(gameObject, panelRetrive);
            isPanelShowing = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setZ()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.1f);
        transform.position = position;
    }

    public void rotateBuilding()
    {        
        gameObject.transform.Rotate(0, 180, 0, Space.Self);        
    }

    public void close()
    {
        panelRetrive.gameObject.SetActive(false);
        isPanelShowing = false;
    }

    public void pickup()
    {        
        Destroy(gameObject);
    }

}
