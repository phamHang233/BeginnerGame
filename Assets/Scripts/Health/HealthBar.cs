
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private UnityEngine.UI.Image currentHealthImg;
    [SerializeField] private UnityEngine.UI.Image startHealthImg;
    private void Awake()
    {
    }

    private void Update()
    {
        currentHealthImg.fillAmount = playerHealth.currentHealth / 10;
    }
}
