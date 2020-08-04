using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Pause(){
        Time.timeScale = 0;
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().Pause();
    }


    public void UnPause(){
        Time.timeScale = 1;
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().UnPause();
    }
}
