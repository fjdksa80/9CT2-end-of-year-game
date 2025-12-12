using UnityEngine;

public class bounce : MonoBehaviour

{
    public Movement player; // Creates a slot in the Inspector
    void OnTriggerEnter2D(Collider2D target){
        if(target.gameObject.tag == "Player"){ //If the end of level collectible collides with the player
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y+0.01f);
            player.velocityY = 67;
        }
    }
}
