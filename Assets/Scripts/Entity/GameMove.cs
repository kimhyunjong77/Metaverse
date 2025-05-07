using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMove : MonoBehaviour
{
    public void Change()
    {
        SceneManager.LoadScene("GameScene");
    }
}
