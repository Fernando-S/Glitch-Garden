using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Description for leveltime")]
    [SerializeField] float levelTime = 10;

    private bool _timerFinished = false;
    private bool _triggeredTimerFinished = false;


    // Update is called once per frame
    void Update()
    {
        if(!_triggeredTimerFinished){
            // Updates slider position
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

            // Checks if it's already time's up
            _timerFinished = Time.timeSinceLevelLoad >= levelTime;
            if(_timerFinished){
                FindObjectOfType<LevelController>().SetLevelTimerFinished();
                _triggeredTimerFinished = true;
            } 
        }
            

    }
}
