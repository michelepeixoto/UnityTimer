using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] //allows private var to be editable in Inspector 
    private int _timerSeconds = 20;
    private bool _timerPaused;
    private bool _timerGoing;
    private bool _timerCanGo;
    
    void Start()
    {
        StartTimer();
    }
    
    void Update()
    {
        if (_timerGoing)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseTimer();
            }
        }
    }
    
    IEnumerator timer(int timerSeconds)
    {
        while (_timerGoing)
        {
            while (_timerPaused)
            {
                yield return null;
            }
            //implement code to update timer UI here
            Debug.Log("timer 0:" + timerSeconds);
            if (timerSeconds == 0)
            {
                break;
            }
            timerSeconds -= 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void StartTimer()
    {
        _timerGoing = true;
        _timerPaused = false;
        StartCoroutine(timer(_timerSeconds));
    }

    private void PauseTimer()
    {
        if (_timerPaused == false)
        {
            Debug.Log("timer paused");
            _timerPaused = true;
            //implement code to show pause screen here
        }
        else
        {
            Debug.Log("timer unpaused");
            _timerPaused = false;
            //implement code to hide pause screen here
        }
    }

    private void StopTimer()
    {
        _timerGoing = false;
    }
}
