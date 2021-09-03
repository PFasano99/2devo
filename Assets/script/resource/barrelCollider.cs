using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        playerController controller = other.GetComponent<playerController>();

        if (controller != null)
        {
            
                controller.ChangeHealth(-1);
                Debug.Log("Object that entered the trigger : " + controller.currentHealth);

            

        }
    }
}
