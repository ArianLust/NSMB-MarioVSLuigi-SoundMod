using UnityEngine;
using UnityEngine.UI;

public class PromptControlWithToggle : MonoBehaviour
{
    // Reference to the buttons that dismiss the prompt
    public Button ignoreForSessionButton;
    public Button neverShowAgainButton;

    // Reference to the toggle component
    public Toggle togglePrompt;

    void Start()
    {
        Debug.Log("Starting PromptControlWithToggle script...");

        // Check if the prompt has been permanently dismissed
        bool isPermanentlyDismissed = PlayerPrefs.GetInt("PromptDismissed", 0) == 1;

        if (isPermanentlyDismissed)
        {
            Debug.Log("Prompt has been permanently dismissed. Deactivating...");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Prompt has not been dismissed. Activating...");
            gameObject.SetActive(true);
        }

        // Add listeners to the buttons to handle dismissal
        if (ignoreForSessionButton != null)
        {
            ignoreForSessionButton.onClick.AddListener(IgnoreForSession);
        }
        else
        {
            Debug.LogWarning("Ignore for session button not assigned!");
        }

        if (neverShowAgainButton != null)
        {
            neverShowAgainButton.onClick.AddListener(NeverShowAgain);
        }
        else
        {
            Debug.LogWarning("Never show again button not assigned!");
        }

        // Add listener to the toggle component
        if (togglePrompt != null)
        {
            // Set initial state based on whether the prompt is permanently dismissed
            togglePrompt.isOn = !isPermanentlyDismissed;
            togglePrompt.onValueChanged.AddListener(delegate { TogglePrompt(togglePrompt.isOn); });
        }
        else
        {
            Debug.LogWarning("Toggle component not assigned!");
        }
    }

    void IgnoreForSession()
    {
        Debug.Log("Ignore for session button clicked. Dismissing prompt for this session...");
        // Deactivate the game object for the current session
        gameObject.SetActive(false);
    }

    void NeverShowAgain()
    {
        Debug.Log("Never show again button clicked. Dismissing prompt permanently...");
        // Set the flag to indicate the prompt has been permanently dismissed
        PlayerPrefs.SetInt("PromptDismissed", 1);
        PlayerPrefs.Save();

        // Deactivate the game object
        gameObject.SetActive(false);
    }

    void TogglePrompt(bool isOn)
    {
        Debug.Log($"Toggle changed: {isOn}");
        if (isOn)
        {
            Debug.Log("Restoring prompt state for future sessions...");
            // Reset the flag to allow the prompt to show again in future sessions
            PlayerPrefs.SetInt("PromptDismissed", 0);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("Setting prompt to be permanently dismissed...");
            // Set the flag to indicate the prompt has been permanently dismissed
            PlayerPrefs.SetInt("PromptDismissed", 1);
            PlayerPrefs.Save();
        }
    }
}
