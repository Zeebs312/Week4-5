using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "EndGoal")
        {
            Debug.Log("Game over, you win!");
        }
    }
}
