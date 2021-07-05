using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    #region Variables
    public static UIManagement instance;

    #region Key tracking
    [Header("Keys")]
    public KeyCode[] trackedKeys;
    private Keypress[] trackers;
    #endregion

    #region OnGUI
    private GUIStyle textStyle = new GUIStyle();
    private GUIStyle headerStyle;

    [Header("OnGUI")]
    #region Fonts
    public int headerFontSize = 20;
    public int textFontSize = 13;
    #endregion
    #region Table
    public int tableSize = 300;
    public int rowSize = 100;
    #endregion
    #endregion

    #region Utilities
    [Header("Utilities")]
    public bool visible = true;
    public float time = 60.0f;
    private string text = "";
    #endregion
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        initTable();
        initGUI();
    }

    // Update is called once per frame
    void Update()
    {
        setVisible();

        //if (!UIBallManagement.instance.hasWon)
        //{
            updateTable();
        //}
    }

    #region GUI
    #region Keys
    private void initTable()
    {
        trackers = new Keypress[trackedKeys.Length];

        for (int i = 0; i < trackedKeys.Length; i++)
        {
            trackers[i] = new Keypress(trackedKeys[i]);
        }
    }

    private void updateTable()
    {
        foreach (Keypress t in trackers)
        {
            t.checkIfTimePassed(time);

            if (Input.GetKeyDown(t.trackedKey))
            {
                t.pressCount++;

                if (t.hasTimePassed)
                {
                    // Calculates average
                    t.pressAvg = t.pressCount / (int)time;
                    // Resets values
                    t.pressCount = 0;
                    t.hasTimePassed = false;
                }
            }
        }
    }
    #endregion

    #region OnGUI
    void OnGUI()
    {
        // TEST
        // Nice to have, isn't necessary
        //// FPS
        //GUILayout.Label((1f / Time.deltaTime).ToString());
        //GUILayout.Space(10);

        if (!visible)
        {
            return;
        }

        /** if not in Debug Mode or Game Mode,
         * then offer on-screen key selection
         * else, just show keys selected in-editor
        **/
        if (!GameManagement.instance.isDebugMode && !GameManagement.instance.isGameMode)
        {
            onScreenSelectKeypress();
        }
        else
        {
            keypressTable();
        }
    }

    private void initGUI()
    {
        textStyle.fontSize = textFontSize;
        headerStyle = new GUIStyle(textStyle);
        headerStyle.fontSize = headerFontSize;
    }

    #region Key Tables
    private void onScreenSelectKeypress()
    {
        GUILayout.BeginVertical(GUILayout.Width(tableSize));
        {
            // Button
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("Create table"))
                {
                    Debug.Log("No implementation because i dum");
                }
            }
            GUILayout.EndHorizontal();

            // Textfield
            GUILayout.BeginHorizontal();
            {
                OutlinedLabel("Track", textStyle, Color.white, Color.black, GUILayout.Width(rowSize));
                text = GUILayout.TextField(text, 3);

                char ch = Event.current.character;

                /** if the current character isn't a number,
                 * replace with a null char
                **/
                if ((ch < '0') || (ch > '9'))
                {
                    Event.current.character = '\0';
                }
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
    }

    private void keypressTable()
    {
        GUILayout.BeginVertical(GUILayout.Width(tableSize));
        {
            GUILayout.Space(50);

            // Header
            GUILayout.BeginHorizontal();
            {
                OutlinedLabel("Button", headerStyle, Color.yellow, Color.black, GUILayout.Width(rowSize));
                OutlinedLabel("Count", headerStyle, Color.yellow, Color.black, GUILayout.Width(rowSize));
                OutlinedLabel("Per " + time + "s", headerStyle, Color.yellow, Color.black, GUILayout.Width(rowSize));
            }
            GUILayout.EndHorizontal();

            // Table
            foreach (Keypress t in trackers)
            {
                GUILayout.BeginHorizontal();
                {
                    OutlinedLabel(t.trackedKey.ToString(), textStyle, Color.white, Color.black, GUILayout.Width(rowSize));
                    OutlinedLabel(t.pressCount.ToString(), textStyle, Color.white, Color.black, GUILayout.Width(rowSize));
                    OutlinedLabel(t.pressAvg.ToString(), textStyle, Color.white, Color.black, GUILayout.Width(rowSize));
                }
                GUILayout.EndHorizontal();
            }

            //if (GUILayout.Button("Export to CSV"))
            //{
            //    Debug.Log("No implementation because i dum");
            //}
        }
        GUILayout.EndVertical();
    }
    #endregion

    #region OnGUI Helpers
    public void OutlinedLabel(string text, GUIStyle style, Color foreground, Color background, params GUILayoutOption[] options)
    {
        OutlinedLabel(new GUIContent(text), style, foreground, background, options);
    }

    public void OutlinedLabel(GUIContent content, GUIStyle style, Color foreground, Color background, params GUILayoutOption[] options)
    {
        style.normal.textColor = background;

        Rect textRect = GUILayoutUtility.GetRect(content, style, options);

        textRect.x--;
        textRect.y--;

        GUI.Label(textRect, content, style);
        textRect.x++;
        GUI.Label(textRect, content, style);
        textRect.x++;
        GUI.Label(textRect, content, style);
        textRect.y++;
        GUI.Label(textRect, content, style);
        textRect.y++;
        GUI.Label(textRect, content, style);
        textRect.x--;
        GUI.Label(textRect, content, style);
        textRect.x--;
        GUI.Label(textRect, content, style);
        textRect.y--;
        GUI.Label(textRect, content, style);
        textRect.x++;

        style.normal.textColor = foreground;
        GUI.Label(textRect, content, style);
    }
    #endregion
    #endregion
    #endregion

    #region Utilities
    private void setVisible()
    {
        if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Backspace))
        {
            visible = !visible;
        }
    }
    #endregion
}
