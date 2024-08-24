using UnityEngine;
using TMPro;

public class BulletManager : MonoBehaviour
{
    public TextMeshProUGUI bulletCounterText; // Referencia al texto UI
    private int totalBulletCount = 0;

    private void Start()
    {
        UpdateBulletCounterText();
    }

    public void AddBullets()
    {
        totalBulletCount ++;
        UpdateBulletCounterText();
    }

    public void RestBullets()
    {
        totalBulletCount --;
        UpdateBulletCounterText();
    }

    public void UpdateBulletCounterText()
    {
        bulletCounterText.text = "Total Bullets: " + totalBulletCount.ToString();
    }
}
