using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    private void Start()
    {
        // Choose a random color from red, blue, and green
        Color randomColor = GetRandomColor();

        // Set the enemy's color
        GetComponent<Renderer>().material.color = randomColor;
    }

    Color GetRandomColor()
    {
        int colorIndex = Random.Range(0, 3);

        switch (colorIndex)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.blue;
            case 2:
                return Color.green;
            default:
                return Color.white;
        }
    }
}