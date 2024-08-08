using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to your TextMeshPro object
    public float speed = 1.0f; // Speed of the color change
    public float colorOffset = 0.1f; // Offset between each character's color

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }
    }

    void Update()
    {
        // Get the text information
        textMeshPro.ForceMeshUpdate();
        TMP_TextInfo textInfo = textMeshPro.textInfo;

        // Iterate through each character
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (textInfo.characterInfo[i].isVisible)
            {
                // Calculate the color based on time and character index
                float t = Mathf.Repeat((Time.time * speed) + (i * colorOffset), 1);
                Color rainbowColor = Color.HSVToRGB(t, 1, 1);

                // Apply the color to the character vertex colors
                int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                textInfo.meshInfo[0].colors32[vertexIndex + 0] = rainbowColor;
                textInfo.meshInfo[0].colors32[vertexIndex + 1] = rainbowColor;
                textInfo.meshInfo[0].colors32[vertexIndex + 2] = rainbowColor;
                textInfo.meshInfo[0].colors32[vertexIndex + 3] = rainbowColor;
            }
        }

        // Update the mesh with the new colors
        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}
