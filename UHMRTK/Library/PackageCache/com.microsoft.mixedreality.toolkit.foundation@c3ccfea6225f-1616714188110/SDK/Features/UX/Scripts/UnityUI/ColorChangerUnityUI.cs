// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.UI
{
    [AddComponentMenu("Scripts/MRTK/Examples/ColorChangerUnityUI")]
    public class ColorChangerUnityUI : MonoBehaviour
    {
        [SerializeField]
        private Graphic graphic;
        public Text timerText;
        public Text ScoreTracker;
        private float startTime;
        private bool endGame = true;
        public GameObject[] buttons;
        public GameObject[] switches;
        private int randButton;
        public int goal;
        private int numberOfPressedButtons;
        private string pressedButtonsToString;

        public void StartGame()
        {
            numberOfPressedButtons = 0;
            if (!endGame)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(true);
                    switches[i].SetActive(false);
                }
                ScoreTracker.text = numberOfPressedButtons.ToString();
            }
            timerText.color = Color.white;
            endGame = false;
            startTime = Time.time;
            randButton = Random.Range(0, buttons.Length);
            buttons[randButton].SetActive(false);
            switches[randButton].SetActive(true);
            

        }

        public void Update()
        {
            if (endGame)
            {
                return;
            }
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }

        public void DoNothing()
        {
            return;
        }

        public void Push()
        {
            numberOfPressedButtons++;
            ScoreTracker.text = numberOfPressedButtons.ToString();
            if (numberOfPressedButtons < goal)
            {
                buttons[randButton].SetActive(true);
                switches[randButton].SetActive(false);

                randButton = Random.Range(0, buttons.Length);
                buttons[randButton].SetActive(false);
                switches[randButton].SetActive(true);
            }
            else 
            { 
                End();
            }
        }

        private void End()
        {
            endGame = true;
            timerText.color = Color.yellow;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
                switches[i].SetActive(false);
            }
        }
    }
}
