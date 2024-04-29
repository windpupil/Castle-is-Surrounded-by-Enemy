using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void Jump()
    {
        SceneController.GoToSceneByName("Main");
    }
}