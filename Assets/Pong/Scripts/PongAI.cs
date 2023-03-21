using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    
    public Transform pongBall;
    [Range(1, 8)]
    public float latence = 4.25f;
    public float latenceDepart;
    //allows the AI to move only when it see the ball
    public float distanceDeReaction = 7;
    public float retourCentre;

    //we use it to simulate different behaviour of the AI like a human (better or not)
    private void Start(){
        latenceDepart = latence;
        InvokeRepeating("Changeval", 10, 10);
    }

    // FixedUpdate is called once per frame and it is an infinite boucle
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, pongBall.position) < distanceDeReaction){
            //Position of the Bar
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, pongBall.position.y), latence*Time.deltaTime);
            //INVINCIBLE: transform.position = new Vector2(transform.position.x, pongBall.position.y);
        
        }else{ //if the ball is not close to the bar, the AI go back to the center of the screen
            if(Random.Range(1, 100) < retourCentre){
                //They put the AI bar to the position 1 which is the center of the stage in the Y axe
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 1), latence*Time.deltaTime);
           
            }
        }
        
    }

    void ChangeVal(){
        if (Random.Range(0,100) > 50) //50% de chance que
        {
            latence = (Random.Range(1, 10) > 5) ? (latenceDepart + 0.5f) : (latenceDepart - 0.5f);
        }
    }
}
