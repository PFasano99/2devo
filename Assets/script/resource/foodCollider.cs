using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        playerController controller = other.GetComponent<playerController>();

        if (controller != null)
        {
            Debug.Log("Object that entered the trigger : " + other);
            if (controller.maxHealth > controller.currentHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
            
        }
    }
}
