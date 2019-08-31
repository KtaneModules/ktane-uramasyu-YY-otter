using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using System.Text.RegularExpressions;
using System;

public class MasyuScript : MonoBehaviour {

    public KMAudio audio;
    public KMBombInfo bomb;

    public KMSelectable[] buttons;
    public GameObject[] gridbuttons;

    public GameObject[] whiteCircles;
    public GameObject[] whiteCircleRings;
    public GameObject[] blackCircles;

    public Material[] changeitems;

    private string[] dots = { "200000000010000012102100000100200000000110011200", "202002000000000000010021100202200000010001000000", "020000000020000000120000010010000000110001000202", "200010101000010110000020000000020020200000000102", "000100110100010010001020010100000100000101200000", "000102010000002002000002212001000000110021000000", "010000000101010110001202100100000000002001200002", "010000100101200002010000010020000000010020010010", "000000010100000011011000002110121001110000000210", "010000000000010100021002000110000000120101200010", "000000010001211000021210100000000110010200000010", "000000101010020021000000020200200100000001010200", "010010100210000100210002000001000000120200000012", "021000000010010102000001020010000000110011000000", "000000100001021201210002000000000100120001000000", "000002201000020020010010000101000000101200002100", "001000100101000000020020200002001002000001200010", "210002020000000000100100210001000110000000020002", "201000000001101010202000001002000000001200002100", "212200000000000000001100200100010100101001000010", "200000121101000000000100200201001002110000000000", "000020011000200000001101010010000001000002012000", "000100111000010010001100000001011002002100010010", "000002101100000101000200000010011110011000000200", "000002101100000000000201001002010000000100210002", "010010002100010001001010100100021100010101000010", "200002000000000200001020000000001000100100002002", "010002010200000000110010000000001201101001000002", "000000000020200000002000000010100020201000000002", "000010000101000000020010100210210000000000010002", "002000101001010010100000000000012020000101010000", "000012120001010010001002100000001010012001010000", "021200000010010000002102100010001100100000000020", "000200110000000001010000120210010000001001010012", "000010120100000000000102000202010000001001010002", "201000000001000020012020000000100010000000002012", "010000010011200010000000010110010102000000200010", "000010201000000001010002000000002010001010200010", "010000020000000020000001002200000000001001000100", "000100010101000001020000100010200100011210000100", "200000000111010001001000110010000000010200010002", "000102210000100010000002002101010010000001000200", /**41*/"021000010101010011000100001202010100000000000002", "000000010101101020010010102100000200010000001200", "010010010000000120000000020020000000100100002012", "200000000101002110010002000000100010102000000002", "000000002010000002102000000000001000000010000200", "012010101000002000012020000010100000001100200200", "010020000000200100000001101001011100000000010010", "010000001101010000002000000100000200100101001200", "202200000000001110010000000101010000000100002002", "202000000011102000002010011010000001012100000010", "200012102100001000000110021001000000000200210002", "000000110000010120000200002000000212000001200010", "020012000100001000000000010200010000120010010010", "010010000000000002012101000000011110000001200010", "021000010001001010002000000000200020000002201000", "000200000001020000001201000000001010100110002000", "012000000000012120000100010010020010000100010012", "000010101000001010000002020000200100010100000010" };
    private string[] solutionH = { "1111101011000110011010110110100000011101", "1101100010010000011001011110011101011111", "0111100110101000110000000000100000010011", "1111101111001110011000000011101100000111", "1011100110000000111011110111100011011001", "0011111000110110001111010011000011010111", "1100110110001111001100000000100011011111", "1100100110110111101111110000001111011111", "0111100110000000000110111011000000010011", "1111111110111100111100111001100111011111", "1111111100111010110000000100001110111111", "1000001111011100000001100110001100011101", "1111100011000001101110100000000110011111", "0111100111001111001001100000000000010001", "1001100000011001101110011001100111011111", "0001111100011100010001000010010001110111", "1110101000001000111011011100110100011111", "1111101110001010100111000010000001001111", "1110101100011001101000011000000001100111", "1101100000010100111011110111100110010011", "1111101110000101000011100011110000010000", "1111011100111010111000000010100001111000", "1011100010001000111010100000111011111111", "1101100000010000110110100000000000101011", "1101100000010000110001111000010111011111", "1111110110000101001100111011100011010111", "1101101000011000111001000000100000011011", "1111111100100010000000001011000110010011", "1111100110110001100000000001101110000011", "1111101110000010111100011110011101011111", "1011100010001000100010000001101011011001", "1111101100000110111101010100001100011101", "0110100000000101011100011000010010011110", "1001100000000000000101100111011110011111", "1111101110001100011100011000000110011111", "1110100100101100011010000000000001011011", "1110111000110000101000111001110100011111", "0001111100010000001100011001110111111111", "1110101100001100100011011000010001000111", "1011100110000100110100100110001110011110", "1110101000000100000100100100011110011111", "0011111000010110001100110001000100011101", "0111100110001000100110011001100111011111", "0000111110011100000000110100111100011100", "1111111000101100000001110001000000011011", "1100100110101110001110010000000011011111", "1111111011100110011000110000100100011101", "1101100010101100011010000000100000011011", "1111000100110011010000010000010101111111", "1101110000000101011001110011000000011101", "1101100001100000010100110000101000011011", "1100100000001101011100011000100011001111", "1111100110100010011101100100000110011111", "1000100000001100101111000100110100011111", "0111100110100100100000011000000111111111", "1111111011100110011000100000000101011111", "0111100110100001100000000111100001111100", "1001100000011000110001001000000000011010", "1100110000001100011000100011001111011111", "1001101100011110001101100111101111011111" };
    private string[] solutionV = { "111101101110000110100010001100010111011111", "111110100110001101010100011001100101111011", "001111111011110100000001001101111001111111", "111111001111000010001000000000011001011111", "111101111100001000001000000001101011111111", "010011100000111011001001010000001101101111", "100111101100001011110000110010000101101111", "110100100000001010000001000010001101101111", "000011111110110111000000001101100001110111", "101111100011100000100000000001000101110111", "101110100011000000000010111000111101100001", "111110110110000000010000011100111110111111", "111011100001100001000011011000000001001111", "000111111101110100000000100000011111011111", "111011111001100001100110100000000101110111", "011111100110110001011100111000111001111101", "111101101100100100110110010011100001111011", "111100001100110010100001111001011101101111", "111000001000000001111101011011100001111001", "111101100100011100000110000100101001111111", "111011101100110000000001100001000001111100", "101111100011000000011010001011011000011110", "111100111101101100110010010001100001111101", "111100000101111100111111011100011101110001", "111111100101101100000111000000000101111011", "100111101100110111001001000001000101110111", "111111101010001000111110001100011001111111", "101111100111010000000011110100110001100111", "110111000000000101100000000101111001111111", "111110101100000000010000011001000101101011", "111100111101101101101010000001111011111111", "111110101101000000110010011100001111101111", "000111111100000001110110011011000111110100", "111110111110000000000111101000011001110011", "111111101111100010000000011001000001110111", "110011100110000101111100000111011101111111", "101111100011100101010111000011100001111011", "011111100111100011100100100000000001110101", "111100001100000010111100011011000101111011", "111110111100001000100001011001011111110000", "111110101111000111000110011011011001110011", "011111100111101011010001001100001111101111", "000011111101100101100001100001100101110111", "011110100111000000110000001110110001111100", "101111100110000100011000001100110001111111", "110011100110001011110000100010001101101111", "101111100111100110110010001100010111011111", "110011100110001101111100001101011001111111", "110111100011100101110011011011001000011101", "100111101101001110000110001100101111111111", "110000100111101110111111001101101001001111", "111000000011111101110000010011000101110111", "110001100110100110000000011001000001101111", "111101111100100010110000110011000001110011", "001111111011100110000001100001000001111001", "101111100111100110110010011000011101011111", "001001111000000110000000000101111001111110", "111111111010000000111110111100001111111000", "100000101111001101000000010011011101111111", "111110110110000000000100100000000101101111" };
    private int usedPuzzle = -1;

    private string horizSelection = "0000000000000000000000000000000000000000";
    private string vertSelection = "000000000000000000000000000000000000000000";

    private int sol = 0;

    private Coroutine runner;
    private double timeHeld;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake()
    {
        moduleId = moduleIdCounter++;
        moduleSolved = false;
        foreach(KMSelectable obj in buttons){
            KMSelectable pressed = obj;
            pressed.OnInteract += delegate () { PressButton(pressed); return false; };
            pressed.OnInteractEnded += delegate () { ReleaseButton(pressed); };
        }
    }

    void Start () {
        clearPuzzleInit();
        clearPuzzleMain();
        generatePuzzle();
    }

    void PressButton(KMSelectable pressed)
    {
        if(moduleSolved != true)
        {
            audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            if (pressed == buttons[82])
            {
                //Submit button
                pressed.AddInteractionPunch(0.25f);
                if (horizSelection.Equals(solutionH[usedPuzzle]) && vertSelection.Equals(solutionV[usedPuzzle]))
                {
                    moduleSolved = true;
                    success();
                    GetComponent<KMBombModule>().HandlePass();
                }
                else
                {
                    StartCoroutine(wrong());
                    GetComponent<KMBombModule>().HandleStrike();
                }
            }
            else if (pressed == buttons[83])
            {
                //Clear button
                pressed.AddInteractionPunch(0.25f);
                runner = StartCoroutine(timer());
            }
            else
            {
                //If the grid button pressed was a vertical one then toggle it
                if (pressed.name.Contains("v"))
                {
                    int realind = Array.IndexOf(buttons, pressed) - 40;
                    if (vertSelection.ElementAt(realind).Equals('0'))
                    {
                        gridbuttons[Array.IndexOf(buttons, pressed)].GetComponent<Renderer>().enabled = true;
                        vertSelection = vertSelection.Insert(realind, "1");
                        vertSelection = vertSelection.Remove(realind + 1, 1);
                    }
                    else
                    {
                        gridbuttons[Array.IndexOf(buttons, pressed)].GetComponent<Renderer>().enabled = false;
                        vertSelection = vertSelection.Insert(realind, "0");
                        vertSelection = vertSelection.Remove(realind + 1, 1);
                    }
                }
                //If the grid button pressed was a horizontal one then toggle it
                else
                {
                    if (horizSelection.ElementAt(Array.IndexOf(buttons, pressed)).Equals('0'))
                    {
                        gridbuttons[Array.IndexOf(buttons, pressed)].GetComponent<Renderer>().enabled = true;
                        horizSelection = horizSelection.Insert(Array.IndexOf(buttons, pressed), "1");
                        horizSelection = horizSelection.Remove(Array.IndexOf(buttons, pressed) + 1, 1);
                    }
                    else
                    {
                        gridbuttons[Array.IndexOf(buttons, pressed)].GetComponent<Renderer>().enabled = false;
                        horizSelection = horizSelection.Insert(Array.IndexOf(buttons, pressed), "0");
                        horizSelection = horizSelection.Remove(Array.IndexOf(buttons, pressed) + 1, 1);
                    }
                }
            }
        }
    }

    void ReleaseButton(KMSelectable pressed)
    {
        if (moduleSolved != true)
        {
            if (pressed == buttons[83])
            {
                StopCoroutine(runner);
            }
        }
    }

    private void success()
    {
        for (int i = 0; i < gridbuttons.Length; i++)
        {
            if (gridbuttons[i].GetComponent<Renderer>().enabled)
            {
                gridbuttons[i].GetComponent<Renderer>().material = changeitems[2];
            }
        }
    }

    private IEnumerator wrong()
    {
        for (int i = 0; i < gridbuttons.Length; i++)
        {
            if (gridbuttons[i].GetComponent<Renderer>().enabled)
            {
                gridbuttons[i].GetComponent<Renderer>().material = changeitems[3];
            }
        }
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < gridbuttons.Length; i++)
        {
            if (gridbuttons[i].GetComponent<Renderer>().enabled)
            {
                gridbuttons[i].GetComponent<Renderer>().material = changeitems[1];
            }
        }
        StopCoroutine("wrong");
    }

    //Debug method that fills the grid with the specified solution path (indexed starting from 0)
    private void fillSolution(int target)
    {
        for(int i = 0; i < solutionH[target].Length; i++)
        {
            if (solutionH[target].ElementAt(i).Equals('1'))
            {
                gridbuttons[i].GetComponent<Renderer>().enabled = true;
            }
        }
        for (int i = 0; i < solutionV[target].Length; i++)
        {
            if (solutionV[target].ElementAt(i).Equals('1'))
            {
                gridbuttons[i+40].GetComponent<Renderer>().enabled = true;
            }
        }
        horizSelection = solutionH[usedPuzzle];
        vertSelection = solutionV[usedPuzzle];
    }

    private void clearPuzzleInit()
    {
        //clears the puzzle of all already enabled dots
        for (int i = 0; i < whiteCircles.Length; i++)
        {
            whiteCircles[i].GetComponent<Renderer>().enabled = false;
        }
        for (int i = 0; i < whiteCircleRings.Length; i++)
        {
            whiteCircleRings[i].GetComponent<Renderer>().enabled = false;
        }
        for (int i = 0; i < blackCircles.Length; i++)
        {
            blackCircles[i].GetComponent<Renderer>().enabled = false;
        }
    }

    private IEnumerator timer()
    {
        timeHeld = 2;
        while (timeHeld < 3)
        {
            yield return new WaitForSeconds(0.01f);
            timeHeld += 0.01;
        }
        clearPuzzleMain();
        StopCoroutine(runner);
    }

    private void clearPuzzleMain()
    {
        //clears the puzzle of all already enabled paths
        for (int i = 0; i < gridbuttons.Length; i++)
        {
            gridbuttons[i].GetComponent<Renderer>().enabled = false;
        }
        horizSelection = "0000000000000000000000000000000000000000";
        vertSelection = "000000000000000000000000000000000000000000";
    }

    private void generatePuzzle()
    {
        //pick puzzle to use at random
        usedPuzzle = UnityEngine.Random.Range(0, dots.Length);
        //automatically fill in the dots depending on the picked puzzle
        for (int i = 0; i < dots[usedPuzzle].Length; i++)
        {
            if (dots[usedPuzzle].ElementAt(i).Equals('1'))
            {
                whiteCircles[i].GetComponent<Renderer>().enabled = true;
                whiteCircleRings[i].GetComponent<Renderer>().enabled = true;
            }
            else if (dots[usedPuzzle].ElementAt(i).Equals('2'))
            {
                blackCircles[i].GetComponent<Renderer>().enabled = true;
            }
        }
        Debug.LogFormat("[Masyu #{0}] The dots/circles are in the following pattern, where 0=blank,1=white,2=black...", moduleId);
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(0, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(6, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(12, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(18, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(24, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(30, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(36, 6));
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, dots[usedPuzzle].Substring(42, 6));
        Debug.LogFormat("[Masyu #{0}] The horizontal connections pattern should be in this order, where 0=blank connection and 1=filled connection", moduleId);
        Debug.LogFormat("[Masyu #{0}] (This should be read as the first character being the tl horizontal connector, and the last being the br horizontal connector with all inbetween being read in reading order)", moduleId);
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, solutionH[usedPuzzle]);
        Debug.LogFormat("[Masyu #{0}] The vertical connections pattern should be in this order, where 0=blank connection and 1=filled connection", moduleId);
        Debug.LogFormat("[Masyu #{0}] (This should be read as the first character being the tl vertical connector, and the last being the br vertical connector with all inbetween being read from top to bottom of each column from left to right)", moduleId);
        Debug.LogFormat("[Masyu #{0}] {1}", moduleId, solutionV[usedPuzzle]);
    }

    //twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"!{0} a1 b1;d4 d5 [Toggles the edges between the sets of two specified cells] | !{0} submit [Presses the submit button] | !{0} clear [Clears the board]";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            buttons[82].OnInteract();
            yield break;
        }
        if (Regex.IsMatch(command, @"^\s*clear\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return null;
            buttons[83].OnInteract();
            yield return new WaitForSeconds(1.5f);
            buttons[83].OnInteractEnded();
            yield break;
        }
        command = command.Replace(" ", String.Empty);
        command = command.ToLower();
        string[] parameters = command.Split(',',';');
        string[] valids = { "a1b1", "b1c1", "c1d1", "d1e1", "e1f1", "a2b2", "b2c2", "c2d2", "d2e2", "e2f2", "a3b3", "b3c3", "c3d3", "d3e3", "e3f3", "a4b4", "b4c4", "c4d4", "d4e4", "e4f4", "a5b5", "b5c5", "c5d5", "d5e5", "e5f5", "a6b6", "b6c6", "c6d6", "d6e6", "e6f6", "a7b7", "b7c7", "c7d7", "d7e7", "e7f7", "a8b8", "b8c8", "c8d8", "d8e8", "e8f8", "a1a2", "a2a3", "a3a4", "a4a5", "a5a6", "a6a7", "a7a8", "b1b2", "b2b3", "b3b4", "b4b5", "b5b6", "b6b7", "b7b8", "c1c2", "c2c3", "c3c4", "c4c5", "c5c6", "c6c7", "c7c8", "d1d2", "d2d3", "d3d4", "d4d5", "d5d6", "d6d7", "d7d8", "e1e2", "e2e3", "e3e4", "e4e5", "e5e6", "e6e7", "e7e8", "f1f2", "f2f3", "f3f4", "f4f5", "f5f6", "f6f7", "f7f8",
                            "b1a1", "c1b1", "d1c1", "e1d1", "f1e1", "b2a2", "c2b2", "d2c2", "e2d2", "f2e2", "b3a3", "c3b3", "d3c3", "e3d3", "f3e3", "b4a4", "c4b4", "d4c4", "e4d4", "f4e4", "b5a5", "c5b5", "d5c5", "e5d5", "f5e5", "b6a6", "c6b6", "d6c6", "e6d6", "f6e6", "b7a7", "c7b7", "d7c7", "e7d7", "f7e7", "b8a8", "c8b8", "d8c8", "e8d8", "f8e8", "a2a1", "a3a2", "a4a3", "a5a4", "a6a5", "a7a6", "a8a7", "b2b1", "b3b2", "b4b3", "b5b4", "b6b5", "b7b6", "b8b7", "c2c1", "c3c2", "c4c3", "c5c4", "c6c5", "c7c6", "c8c7", "d2d1", "d3d2", "d4d3", "d5d4", "d6d5", "d7d6", "d8d7", "e2e1", "e3e2", "e4e3", "e5e4", "e6e5", "e7e6", "e8e7", "f2f1", "f3f2", "f4f3", "f5f4", "f6f5", "f7f6", "f8f7"};
        for(int i = 0; i < parameters.Length; i++)
        {
            if (!valids.Contains(parameters[i]))
            {
                yield break;
            }
        }
        yield return null;
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i].Equals("a1b1"))
            {
                buttons[0].OnInteract();
            }
            else if (parameters[i].Equals("b1c1"))
            {
                buttons[1].OnInteract();
            }
            else if (parameters[i].Equals("c1d1"))
            {
                buttons[2].OnInteract();
            }
            else if (parameters[i].Equals("d1e1"))
            {
                buttons[3].OnInteract();
            }
            else if (parameters[i].Equals("e1f1"))
            {
                buttons[4].OnInteract();
            }
            else if (parameters[i].Equals("a2b2"))
            {
                buttons[5].OnInteract();
            }
            else if (parameters[i].Equals("b2c2"))
            {
                buttons[6].OnInteract();
            }
            else if (parameters[i].Equals("c2d2"))
            {
                buttons[7].OnInteract();
            }
            else if (parameters[i].Equals("d2e2"))
            {
                buttons[8].OnInteract();
            }
            else if (parameters[i].Equals("e2f2"))
            {
                buttons[9].OnInteract();
            }
            else if (parameters[i].Equals("a3b3"))
            {
                buttons[10].OnInteract();
            }
            else if (parameters[i].Equals("b3c3"))
            {
                buttons[11].OnInteract();
            }
            else if (parameters[i].Equals("c3d3"))
            {
                buttons[12].OnInteract();
            }
            else if (parameters[i].Equals("d3e3"))
            {
                buttons[13].OnInteract();
            }
            else if (parameters[i].Equals("e3f3"))
            {
                buttons[14].OnInteract();
            }
            else if (parameters[i].Equals("a4b4"))
            {
                buttons[15].OnInteract();
            }
            else if (parameters[i].Equals("b4c4"))
            {
                buttons[16].OnInteract();
            }
            else if (parameters[i].Equals("c4d4"))
            {
                buttons[17].OnInteract();
            }
            else if (parameters[i].Equals("d4e4"))
            {
                buttons[18].OnInteract();
            }
            else if (parameters[i].Equals("e4f4"))
            {
                buttons[19].OnInteract();
            }
            else if (parameters[i].Equals("a5b5"))
            {
                buttons[20].OnInteract();
            }
            else if (parameters[i].Equals("b5c5"))
            {
                buttons[21].OnInteract();
            }
            else if (parameters[i].Equals("c5d5"))
            {
                buttons[22].OnInteract();
            }
            else if (parameters[i].Equals("d5e5"))
            {
                buttons[23].OnInteract();
            }
            else if (parameters[i].Equals("e5f5"))
            {
                buttons[24].OnInteract();
            }
            else if (parameters[i].Equals("a6b6"))
            {
                buttons[25].OnInteract();
            }
            else if (parameters[i].Equals("b6c6"))
            {
                buttons[26].OnInteract();
            }
            else if (parameters[i].Equals("c6d6"))
            {
                buttons[27].OnInteract();
            }
            else if (parameters[i].Equals("d6e6"))
            {
                buttons[28].OnInteract();
            }
            else if (parameters[i].Equals("e6f6"))
            {
                buttons[29].OnInteract();
            }
            else if (parameters[i].Equals("a7b7"))
            {
                buttons[30].OnInteract();
            }
            else if (parameters[i].Equals("b7c7"))
            {
                buttons[31].OnInteract();
            }
            else if (parameters[i].Equals("c7d7"))
            {
                buttons[32].OnInteract();
            }
            else if (parameters[i].Equals("d7e7"))
            {
                buttons[33].OnInteract();
            }
            else if (parameters[i].Equals("e7f7"))
            {
                buttons[34].OnInteract();
            }
            else if (parameters[i].Equals("a8b8"))
            {
                buttons[35].OnInteract();
            }
            else if (parameters[i].Equals("b8c8"))
            {
                buttons[36].OnInteract();
            }
            else if (parameters[i].Equals("c8d8"))
            {
                buttons[37].OnInteract();
            }
            else if (parameters[i].Equals("d8e8"))
            {
                buttons[38].OnInteract();
            }
            else if (parameters[i].Equals("e8f8"))
            {
                buttons[39].OnInteract();
            }
            else if (parameters[i].Equals("a1a2"))
            {
                buttons[40].OnInteract();
            }
            else if (parameters[i].Equals("a2a3"))
            {
                buttons[41].OnInteract();
            }
            else if (parameters[i].Equals("a3a4"))
            {
                buttons[42].OnInteract();
            }
            else if (parameters[i].Equals("a4a5"))
            {
                buttons[43].OnInteract();
            }
            else if (parameters[i].Equals("a5a6"))
            {
                buttons[44].OnInteract();
            }
            else if (parameters[i].Equals("a6a7"))
            {
                buttons[45].OnInteract();
            }
            else if (parameters[i].Equals("a7a8"))
            {
                buttons[46].OnInteract();
            }
            else if (parameters[i].Equals("b1b2"))
            {
                buttons[47].OnInteract();
            }
            else if (parameters[i].Equals("b2b3"))
            {
                buttons[48].OnInteract();
            }
            else if (parameters[i].Equals("b3b4"))
            {
                buttons[49].OnInteract();
            }
            else if (parameters[i].Equals("b4b5"))
            {
                buttons[50].OnInteract();
            }
            else if (parameters[i].Equals("b5b6"))
            {
                buttons[51].OnInteract();
            }
            else if (parameters[i].Equals("b6b7"))
            {
                buttons[52].OnInteract();
            }
            else if (parameters[i].Equals("b7b8"))
            {
                buttons[53].OnInteract();
            }
            else if (parameters[i].Equals("c1c2"))
            {
                buttons[54].OnInteract();
            }
            else if (parameters[i].Equals("c2c3"))
            {
                buttons[55].OnInteract();
            }
            else if (parameters[i].Equals("c3c4"))
            {
                buttons[56].OnInteract();
            }
            else if (parameters[i].Equals("c4c5"))
            {
                buttons[57].OnInteract();
            }
            else if (parameters[i].Equals("c5c6"))
            {
                buttons[58].OnInteract();
            }
            else if (parameters[i].Equals("c6c7"))
            {
                buttons[59].OnInteract();
            }
            else if (parameters[i].Equals("c7c8"))
            {
                buttons[60].OnInteract();
            }
            else if (parameters[i].Equals("d1d2"))
            {
                buttons[61].OnInteract();
            }
            else if (parameters[i].Equals("d2d3"))
            {
                buttons[62].OnInteract();
            }
            else if (parameters[i].Equals("d3d4"))
            {
                buttons[63].OnInteract();
            }
            else if (parameters[i].Equals("d4d5"))
            {
                buttons[64].OnInteract();
            }
            else if (parameters[i].Equals("d5d6"))
            {
                buttons[65].OnInteract();
            }
            else if (parameters[i].Equals("d6d7"))
            {
                buttons[66].OnInteract();
            }
            else if (parameters[i].Equals("d7d8"))
            {
                buttons[67].OnInteract();
            }
            else if (parameters[i].Equals("e1e2"))
            {
                buttons[68].OnInteract();
            }
            else if (parameters[i].Equals("e2e3"))
            {
                buttons[69].OnInteract();
            }
            else if (parameters[i].Equals("e3e4"))
            {
                buttons[70].OnInteract();
            }
            else if (parameters[i].Equals("e4e5"))
            {
                buttons[71].OnInteract();
            }
            else if (parameters[i].Equals("e5e6"))
            {
                buttons[72].OnInteract();
            }
            else if (parameters[i].Equals("e6e7"))
            {
                buttons[73].OnInteract();
            }
            else if (parameters[i].Equals("e7e8"))
            {
                buttons[74].OnInteract();
            }
            else if (parameters[i].Equals("f1f2"))
            {
                buttons[75].OnInteract();
            }
            else if (parameters[i].Equals("f2f3"))
            {
                buttons[76].OnInteract();
            }
            else if (parameters[i].Equals("f3f4"))
            {
                buttons[77].OnInteract();
            }
            else if (parameters[i].Equals("f4f5"))
            {
                buttons[78].OnInteract();
            }
            else if (parameters[i].Equals("f5f6"))
            {
                buttons[79].OnInteract();
            }
            else if (parameters[i].Equals("f6f7"))
            {
                buttons[80].OnInteract();
            }
            else if (parameters[i].Equals("f7f8"))
            {
                buttons[81].OnInteract();
            }
            else if (parameters[i].Equals("b1a1"))
            {
                buttons[0].OnInteract();
            }
            else if (parameters[i].Equals("c1b1"))
            {
                buttons[1].OnInteract();
            }
            else if (parameters[i].Equals("d1c1"))
            {
                buttons[2].OnInteract();
            }
            else if (parameters[i].Equals("e1d1"))
            {
                buttons[3].OnInteract();
            }
            else if (parameters[i].Equals("f1e1"))
            {
                buttons[4].OnInteract();
            }
            else if (parameters[i].Equals("b2a2"))
            {
                buttons[5].OnInteract();
            }
            else if (parameters[i].Equals("c2b2"))
            {
                buttons[6].OnInteract();
            }
            else if (parameters[i].Equals("d2c2"))
            {
                buttons[7].OnInteract();
            }
            else if (parameters[i].Equals("e2d2"))
            {
                buttons[8].OnInteract();
            }
            else if (parameters[i].Equals("f2e2"))
            {
                buttons[9].OnInteract();
            }
            else if (parameters[i].Equals("b3a3"))
            {
                buttons[10].OnInteract();
            }
            else if (parameters[i].Equals("c3b3"))
            {
                buttons[11].OnInteract();
            }
            else if (parameters[i].Equals("d3c3"))
            {
                buttons[12].OnInteract();
            }
            else if (parameters[i].Equals("e3d3"))
            {
                buttons[13].OnInteract();
            }
            else if (parameters[i].Equals("f3e3"))
            {
                buttons[14].OnInteract();
            }
            else if (parameters[i].Equals("b4a4"))
            {
                buttons[15].OnInteract();
            }
            else if (parameters[i].Equals("c4b4"))
            {
                buttons[16].OnInteract();
            }
            else if (parameters[i].Equals("d4c4"))
            {
                buttons[17].OnInteract();
            }
            else if (parameters[i].Equals("e4d4"))
            {
                buttons[18].OnInteract();
            }
            else if (parameters[i].Equals("f4e4"))
            {
                buttons[19].OnInteract();
            }
            else if (parameters[i].Equals("b5a5"))
            {
                buttons[20].OnInteract();
            }
            else if (parameters[i].Equals("c5b5"))
            {
                buttons[21].OnInteract();
            }
            else if (parameters[i].Equals("d5c5"))
            {
                buttons[22].OnInteract();
            }
            else if (parameters[i].Equals("e5d5"))
            {
                buttons[23].OnInteract();
            }
            else if (parameters[i].Equals("f5e5"))
            {
                buttons[24].OnInteract();
            }
            else if (parameters[i].Equals("b6a6"))
            {
                buttons[25].OnInteract();
            }
            else if (parameters[i].Equals("c6b6"))
            {
                buttons[26].OnInteract();
            }
            else if (parameters[i].Equals("d6c6"))
            {
                buttons[27].OnInteract();
            }
            else if (parameters[i].Equals("e6d6"))
            {
                buttons[28].OnInteract();
            }
            else if (parameters[i].Equals("f6e6"))
            {
                buttons[29].OnInteract();
            }
            else if (parameters[i].Equals("b7a7"))
            {
                buttons[30].OnInteract();
            }
            else if (parameters[i].Equals("c7b7"))
            {
                buttons[31].OnInteract();
            }
            else if (parameters[i].Equals("d7c7"))
            {
                buttons[32].OnInteract();
            }
            else if (parameters[i].Equals("e7d7"))
            {
                buttons[33].OnInteract();
            }
            else if (parameters[i].Equals("f7e7"))
            {
                buttons[34].OnInteract();
            }
            else if (parameters[i].Equals("b8a8"))
            {
                buttons[35].OnInteract();
            }
            else if (parameters[i].Equals("c8b8"))
            {
                buttons[36].OnInteract();
            }
            else if (parameters[i].Equals("d8c8"))
            {
                buttons[37].OnInteract();
            }
            else if (parameters[i].Equals("e8d8"))
            {
                buttons[38].OnInteract();
            }
            else if (parameters[i].Equals("f8e8"))
            {
                buttons[39].OnInteract();
            }
            else if (parameters[i].Equals("a2a1"))
            {
                buttons[40].OnInteract();
            }
            else if (parameters[i].Equals("a3a2"))
            {
                buttons[41].OnInteract();
            }
            else if (parameters[i].Equals("a4a3"))
            {
                buttons[42].OnInteract();
            }
            else if (parameters[i].Equals("a5a4"))
            {
                buttons[43].OnInteract();
            }
            else if (parameters[i].Equals("a6a5"))
            {
                buttons[44].OnInteract();
            }
            else if (parameters[i].Equals("a7a6"))
            {
                buttons[45].OnInteract();
            }
            else if (parameters[i].Equals("a8a7"))
            {
                buttons[46].OnInteract();
            }
            else if (parameters[i].Equals("b2b1"))
            {
                buttons[47].OnInteract();
            }
            else if (parameters[i].Equals("b3b2"))
            {
                buttons[48].OnInteract();
            }
            else if (parameters[i].Equals("b4b3"))
            {
                buttons[49].OnInteract();
            }
            else if (parameters[i].Equals("b5b4"))
            {
                buttons[50].OnInteract();
            }
            else if (parameters[i].Equals("b6b5"))
            {
                buttons[51].OnInteract();
            }
            else if (parameters[i].Equals("b7b6"))
            {
                buttons[52].OnInteract();
            }
            else if (parameters[i].Equals("b8b7"))
            {
                buttons[53].OnInteract();
            }
            else if (parameters[i].Equals("c2c1"))
            {
                buttons[54].OnInteract();
            }
            else if (parameters[i].Equals("c3c2"))
            {
                buttons[55].OnInteract();
            }
            else if (parameters[i].Equals("c4c3"))
            {
                buttons[56].OnInteract();
            }
            else if (parameters[i].Equals("c5c4"))
            {
                buttons[57].OnInteract();
            }
            else if (parameters[i].Equals("c6c5"))
            {
                buttons[58].OnInteract();
            }
            else if (parameters[i].Equals("c7c6"))
            {
                buttons[59].OnInteract();
            }
            else if (parameters[i].Equals("c8c7"))
            {
                buttons[60].OnInteract();
            }
            else if (parameters[i].Equals("d2d1"))
            {
                buttons[61].OnInteract();
            }
            else if (parameters[i].Equals("d3d2"))
            {
                buttons[62].OnInteract();
            }
            else if (parameters[i].Equals("d4d3"))
            {
                buttons[63].OnInteract();
            }
            else if (parameters[i].Equals("d5d4"))
            {
                buttons[64].OnInteract();
            }
            else if (parameters[i].Equals("d6d5"))
            {
                buttons[65].OnInteract();
            }
            else if (parameters[i].Equals("d7d6"))
            {
                buttons[66].OnInteract();
            }
            else if (parameters[i].Equals("d8d7"))
            {
                buttons[67].OnInteract();
            }
            else if (parameters[i].Equals("e2e1"))
            {
                buttons[68].OnInteract();
            }
            else if (parameters[i].Equals("e3e2"))
            {
                buttons[69].OnInteract();
            }
            else if (parameters[i].Equals("e4e3"))
            {
                buttons[70].OnInteract();
            }
            else if (parameters[i].Equals("e5e4"))
            {
                buttons[71].OnInteract();
            }
            else if (parameters[i].Equals("e6e5"))
            {
                buttons[72].OnInteract();
            }
            else if (parameters[i].Equals("e7e6"))
            {
                buttons[73].OnInteract();
            }
            else if (parameters[i].Equals("e8e7"))
            {
                buttons[74].OnInteract();
            }
            else if (parameters[i].Equals("f2f1"))
            {
                buttons[75].OnInteract();
            }
            else if (parameters[i].Equals("f3f2"))
            {
                buttons[76].OnInteract();
            }
            else if (parameters[i].Equals("f4f3"))
            {
                buttons[77].OnInteract();
            }
            else if (parameters[i].Equals("f5f4"))
            {
                buttons[78].OnInteract();
            }
            else if (parameters[i].Equals("f6f5"))
            {
                buttons[79].OnInteract();
            }
            else if (parameters[i].Equals("f7f6"))
            {
                buttons[80].OnInteract();
            }
            else if (parameters[i].Equals("f8f7"))
            {
                buttons[81].OnInteract();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
