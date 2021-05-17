using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] //allows private var to be editable in Inspector 
    private int _timerSeconds = 20;
    
    void Start()
    {
        StartCoroutine(timer(_timerSeconds));
    }
    
    IEnumerator timer(int timerSeconds)
    {
        while (true)
        {
            while (_gamePaused)
            {
                yield return null;
            }
            //update timer UI
            Debug.Log("timer 0:" + timerSeconds);
            if (timerSeconds == 0)
            {
                EndGame();
                break;
            }
            timerSeconds -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
