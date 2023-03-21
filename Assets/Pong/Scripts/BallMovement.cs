using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed = 5;
    public float extraSpeed  = 1; //how much the speed of the ball is going to increase
    public float maxExtraSpeed = 5; //maximum speed

    private int hitCounter = 0; //how many the ball has been hit

    private Rigidbody2D rb; //we will use simple physics to start our ball

    public bool playerStart  = true;

   
    void Start(){
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }   

    private void RestartBall(){
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 1);
    }

    public IEnumerator Launch(){
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1); //to give the possibility to the player to be ready
        
        if(playerStart == true){
            MoveBall(new Vector2(-1, 0));
        }else{
            MoveBall(new Vector2(1, 0));
        }
        
    }

    public void MoveBall(Vector2 direction){
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed; //we will increase the speed of the ball gradually in function of the hitCounter

        rb.velocity = direction * ballSpeed;
    }
    
    //increase the speed of the ball
    public void IncreaseHitCounter(){
        if(hitCounter * extraSpeed < maxExtraSpeed){
            hitCounter++;
        }
    }
}   



