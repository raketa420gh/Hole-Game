using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
	[Header("Level Progress Bar")]
	[SerializeField] private TMP_Text nextLevelText;
	[SerializeField] private TMP_Text currentLevelText;
	[SerializeField] private Image progressFillImage;

	[Space]
	[Header("Level Complete Panel")]
	[SerializeField] private TMP_Text levelCompletedText;

	[Space]
	[Header("Fade")]
	[SerializeField] private Image fadePanel;

	public void Fade()
	{
		fadePanel.DOFade(0f, 1.5f).From(1f);
	}

	public void UpdateLevelProgressBar(float normalized)
	{
		progressFillImage.DOFillAmount(normalized, .25f);
	}

	public void ShowLevelCompletedPanel()
	{
		levelCompletedText.DOFade(1f, .6f).From(0f);
	}

	public void SetLevelText(int currentLevel)
	{
		currentLevelText.text = currentLevel.ToString();
		nextLevelText.text = (currentLevel + 1).ToString();
	}
}
