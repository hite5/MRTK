using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.MixedReality.Toolkit.UI
{
    public class SpeedTest : MonoBehaviour
    {
        [SerializeField]
        public Text timerText;
        private float startTime;
        private bool endGame = false;
        public void StartGame()
        {
            startTime = Time.time;
        }
        public void Update()
        {
            while (endGame)
            {
                return;
            }
            float t = Time.time - startTime;

            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }

        public void End()
        {

        }
    }
}
