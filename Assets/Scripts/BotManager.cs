using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IBM.Cloud.SDK.Utilities;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    [SerializeField]
    private TextToSpeech textToSpeech;
    [SerializeField]
    private SpeechToText speechToText;
    [SerializeField]
    private IBMWatson ibmWatson;

    void Start() {
        Runnable.Run(ibmWatson.Welcome());
    }

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
            // Removing special characters from input text because IBM got stucks with special characters.
            // Reason behind it they are using the special characters for controlling language understanding YAML files.
            ibmWatson.SendQuestion(Regex.Replace(textToSpeech.textInput.text, @"[^0-9a-zA-Z\._]", " "));
        }

        if(ibmWatson.chatStatus == IBMWatson.ProcessingStatus.Processed)
        {
            ibmWatson.chatStatus = IBMWatson.ProcessingStatus.Idle;
            textToSpeech.StartTextToSpeech(ibmWatson.textResponse);
        }
            
    }
}
