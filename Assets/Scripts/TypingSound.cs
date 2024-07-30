using UnityEngine;
using TMPro;

public class TypingSound : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to your TMP Input Field
    public AudioSource audioSource;    // Reference to your AudioSource

    private AudioClip keyUpClip;        // AudioClip for key up
    private AudioClip keyDownClip;      // AudioClip for key down

    private string previousText;

    private void Start()
    {
        // Load audio clips from Resources
        keyUpClip = Resources.Load<AudioClip>("Sound/ui/keyup");
        keyDownClip = Resources.Load<AudioClip>("Sound/ui/keydown");

        // Initialize previous text
        previousText = inputField.text;
    }

    private void OnEnable()
    {
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnDisable()
    {
        inputField.onValueChanged.RemoveListener(OnValueChanged);
    }

    private void OnValueChanged(string text)
    {
        // Determine if backspace was used
        if (text.Length < previousText.Length)
        {
            // Backspace was pressed
            audioSource.clip = keyDownClip;
        }
        else
        {
            // Key was pressed
            audioSource.clip = keyUpClip;
        }

        // Update previous text
        previousText = text;

        // Play the sound effect
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
