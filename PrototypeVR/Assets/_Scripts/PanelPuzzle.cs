using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPuzzle : MonoBehaviour
{
    public Progressbar progressbar;
    public MapPuzzle manager;

    public void CheckSolution()
    {
        if (progressbar.current >= 0.98f)
            manager.LeverPuzzleSolved();
    }

}
