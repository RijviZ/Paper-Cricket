using UnityEngine;

public class MoodButton : MonoBehaviour
{
    public string mood;
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<MoodButton>();
        foreach(MoodButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(121, 121, 121, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<RotatePitch>().HitMode(mood);
    }
}
