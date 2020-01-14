using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Res : MonoBehaviour {

    private int resolution;

    private GameObject riemann;
    private GameObject volText;
    private GameObject display;

    void Start()
    {
        riemann = GameObject.Find("Riemann");
        volText = GameObject.Find("VolText");
        display = GameObject.Find("Display");
    }

    void Awake()
    {
        resolution = 1;
    }

    public int GetRes()
    {
        return resolution;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Restart(0);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Restart(1);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Restart(2);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Restart(3);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Restart(4);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Restart(5);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            Restart(6);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            Restart(7);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            Restart(8);
        }

        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            Restart(9);
        }
    }

    void Restart(int newRes)
    {
        foreach (Transform child in riemann.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in volText.transform)
        {
            Destroy(child.gameObject);
        }

        resolution = newRes;
        riemann.GetComponent<Riemann>().enabled = true;
        volText.GetComponent<VolText>().enabled = true;

        display.GetComponent<Display>().enabled = false;
        display.GetComponent<Display>().enabled = true;
    }
}