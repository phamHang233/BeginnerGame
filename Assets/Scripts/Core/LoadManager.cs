using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
            SceneManager.LoadScene(1);
    }
}
