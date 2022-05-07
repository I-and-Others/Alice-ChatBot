using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    [SerializeField]
    private TextToSpeech textToSpeech;
    [SerializeField]
    private SpeechToText speechToText;

    void Update()
    {
        // Debug.LogWarning("STT Status: " + speechToText.GetStatus() + ", TTS Status: " + textToSpeech.GetStatus());
        // We check SpeechToText and TextToSpeech statuses to make control.
        if (speechToText.GetStatus() == SpeechToText.ProcessingStatus.Listening && textToSpeech.GetStatus() == TextToSpeech.SpeakingStatus.NotSpeaking)
        {
            speechToText.Active = true;
            speechToText.StartRecording();
        }
        else if(speechToText.GetStatus() == SpeechToText.ProcessingStatus.Talking && textToSpeech.GetStatus() == TextToSpeech.SpeakingStatus.NotSpeaking)
        {
            speechToText.SetStatus(SpeechToText.ProcessingStatus.Idle);
            speechToText.Active = false;
            speechToText.StopRecording();
            textToSpeech.StartTextToSpeech();
        }
    }
}
