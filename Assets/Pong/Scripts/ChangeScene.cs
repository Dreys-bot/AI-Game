using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void MovieToScene(int sceneID){
        //every scene that we create will have a unique ID assigned to them.
        SceneManager.LoadScene(sceneID);
    }

    public void Quit(){
        Application.Quit();
    }
}
