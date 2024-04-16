using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conflict : MonoBehaviour
{
    public void Jump()
    {
        SceneController.GoToSceneByName("Fight");
    }

}