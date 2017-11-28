﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GM.instance.TogglePause();
        }
	}

    public void ExitGame()
    {
        Application.Quit();
    }
}
