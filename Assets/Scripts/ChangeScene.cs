using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    public void MoveToScene(int scneId) {
        SceneManager.LoadScene(scneId);
    
    }
    public void Exit()
    {
        Application.Quit();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
