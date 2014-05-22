using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour
{

    // Use this for initialization
    void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag ("Enemy")) {
            Player player = this.gameObject.GetComponent<Player> ();
            Enemy enemy = hit.gameObject.GetComponent<Enemy> ();

            // example usage
            // if(player.controller.defending) take less damage
            // if (player.controller.jumping) take more damage

            player.stats.currentHP -= enemy.stats.damage;

            if (player.stats.currentHP <= 0) { /*run GameOver logic*/
            }
        }
    }
}