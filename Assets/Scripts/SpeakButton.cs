using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeakButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Defining the components for SpeechToText and Animator.
    public SpeechToText speechToText;
    private Animator animator;
    private void Start() {
        animator = GetComponent<Animator>();
    }
    // We check if button is pressing animate the button and change the state for SpeechToText.
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("isPressed", true);
        speechToText.status = SpeechToText.ProcessingStatus.Listening;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("isPressed", false);
        speechToText.status = SpeechToText.ProcessingStatus.Thinking;
    }
}
