using UnityEngine;
using UnityEngine.UI;

public class PromptForSourceCode : MonoBehaviour
{
    // Reference to the buttons that dismiss the prompt
    public Button ignoreForSessionButton;
    public Button neverShowAgainButton;

    void Start()
    {
        Debug.Log("Starting PromptControl script...");

        // Check if the prompt has been permanently dismissed
        if (PlayerPrefs.GetInt("PromptDismissed", 0) == 1)
        {
            Debug.Log("Prompt has been permanently dismissed. Deactivating...");
            gameObject.SetActive(false);
            return;
        }

        // The game object should be active if the prompt has not been dismissed
        Debug.Log("Prompt has not been dismissed. Activating...");
        gameObject.SetActive(true);

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
}
