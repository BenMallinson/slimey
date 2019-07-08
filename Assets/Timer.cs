 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 using TMPro;
 
 public class LevelTimer : MonoBehaviour {
     public TextMeshProUGUI timerLabel;
     private float time;
 
     void Update() {
         time += Time.deltaTime;
 
         var seconds = time % 60;//Use the euclidean division for the seconds.
         var fraction = (time * 100) % 100;
 
        timerLabel = GetComponent<TextMeshProUGUI>();
        timerLabel.SetText(string.Format ("{0:00}:{1:00}", seconds, fraction));
     }
 }
