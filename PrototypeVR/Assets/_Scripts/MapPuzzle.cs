using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPuzzle : MonoBehaviour
{
    public GameObject panel;
    public List<GameObject> Buttons;
    public List<GameObject> Lights;
    public bool[] Solution;
    public bool[] PressCheck;
    public bool[] ButtonLocked;
    private bool[] solved;

    public void Awake()
    {
        panel.SetActive(false);
        PressCheck = new bool[10];
        ButtonLocked  = new bool[10];
        Solution = new bool[10];
        Solution[4] = true;
        Solution[8] = true;

        Solution[0] = true;
        Solution[1] = true;

        Solution[6] = true;
        Solution[7] = true;
        solved = new bool[3];
    }
    public void ButtonPressed(HandButton button)
    {
        GameObject light = Lights[button.id];
        if (!PressCheck[button.id])
        {
            print("Button not yet pressed");
            light = Lights[button.id];
            light.GetComponent<ColorChanger>().SetSelectMaterial();
            PressCheck[button.id] = true;
            CheckSolution();
        }
        else if(!ButtonLocked[button.id])
        {
            print("Button pressed and not locked");
            light.GetComponent<ColorChanger>().SetOriginalMaterial();
            PressCheck[button.id] = false;
        }
    }

    private void CheckSolution()
    {
        int c = 0;
        foreach (bool press in PressCheck)
        {
            if (press)
                c++;
        }

        if (c % 2 == 0 && c > 0)
        {
            for (int i = 0; i < PressCheck.Length; i++)
            {
                if (PressCheck[i] && !Solution[i])
                {
                    ResetLights();
                    break;
                }
            }
            if (PressCheck[4] && PressCheck[8])
            {
                solved[0] = true;
                ButtonLocked[4] = true; ButtonLocked[8] = true;
            }
            if (PressCheck[0] && PressCheck[1])
            {
                solved[1] = true;
                ButtonLocked[0] = true; ButtonLocked[1] = true;
            }
            if (PressCheck[6] && PressCheck[7])
            {
                solved[2] = true;
                ButtonLocked[6] = true; ButtonLocked[7] = true;
            }

            int s = 0;
            for (int i = 0; i < solved.Length; i++)
            {
                if (solved[i])
                    s++;
            }
            if(s > c / 3)
            {
                if (solved[0] && solved[1] && solved[2])
                {
                    MapPuzzleSolved();
                }
            }
            else
            {
                ResetLights();
            }

        }

    }

    private void ResetLights()
    {
        foreach (GameObject light in Lights)
            light.GetComponent<ColorChanger>().SetOriginalMaterial();
        foreach (GameObject button in Buttons)
            button.GetComponentInChildren<HandButton>().isPressed = false;
        for (int i = 0; i < PressCheck.Length; i++)
            PressCheck[i] = false;
        for (int i = 0; i < ButtonLocked.Length; i++)
            ButtonLocked[i] = false;
        for (int i = 0; i < solved.Length; i++)
            solved[i] = false;
    }

    private void MapPuzzleSolved()
    {
        foreach (GameObject light in Lights)
            light.GetComponent<ColorChanger>().SetSelectMaterial();
        for (int i = 0; i < ButtonLocked.Length; i++)
            ButtonLocked[i] = true;
        AudioSource sound = transform.GetComponent<AudioSource>();
        //sound.Play(0);
        panel.SetActive(true);
    }

    public void LeverPuzzleSolved()
    {

    }

}
