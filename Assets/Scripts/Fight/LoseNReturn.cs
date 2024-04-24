using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseNReturn : MonoBehaviour
{
    // Start is called before the first frame update
    public void Jump()
    {
        Time.timeScale = 1;
        SceneController.GoToSceneByName("Main");
    }
}
