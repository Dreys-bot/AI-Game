using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBar : MonoBehaviour
{
    
    public bool isHumanPlayer = false; //IA ou human?

    //speed of the bar;
    public float speed;

    // Update is called once per frame
    void Update()
    {
       float move; //movement which we want to apply to the ball

        //calcul the movement
       if(isHumanPlayer){
        move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
       }else{
        move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       } 

       //Apply the movement
       transform.Translate(move * Vector2.up);

       //block the ball from the screen
       if (transform.position.y > 4.7){
        transform.position = new Vector3(transform.position.x , 4.7f, 0);
       }
       if(transform.position.y < -2.9){
        transform.position = new Vector3(transform.position.x, -2.9f, 0);
       }
    }
}
