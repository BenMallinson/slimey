using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
   public void QuitGame() {
       Debug.Log("hello?");
       SceneManager.LoadScene(0);
   }
}
