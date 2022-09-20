using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManag : MonoBehaviour
{
   
    void Start()
    {
        
    }

    public void StartGame(){

        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu(){

        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame(){
        
        Application.Quit();
    }

    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
