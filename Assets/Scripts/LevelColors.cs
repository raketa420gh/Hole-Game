using UnityEngine;
using UnityEngine.UI;

public class LevelColors : MonoBehaviour
{
	[Header ("Materials & Sprites")]
	[SerializeField] private Material groundMaterial;
	[SerializeField] private Material objectMaterial;
	[SerializeField] private Material obstacleMaterial;
	[SerializeField] private SpriteRenderer groundBorderSprite;
	[SerializeField] private SpriteRenderer groundSideSprite;
	[SerializeField] private Image progressFillImage;
	[SerializeField] private SpriteRenderer backgroundFadeSprite;

	[Header ("Level Colors")]
	[Header ("Ground")]
	[SerializeField] private Color groundColor;
	[SerializeField] private Color bordersColor;
	[SerializeField] private Color sideColor;

	[Header ("Objects & Obstacles")]
	[SerializeField] private Color objectColor;
	[SerializeField] private Color obstacleColor;

	[Header ("UI (progress)")]
	[SerializeField] private Color progressFillColor;

	[Header ("Background")]
	[SerializeField] private Color cameraColor;
	[SerializeField] private Color fadeColor;

	private void OnValidate()
	{
		UpdateLevelColors();
	}

	public void UpdateLevelColors()
	{
		groundMaterial.color = groundColor;
		groundSideSprite.color = sideColor;
		groundBorderSprite.color = bordersColor;

		obstacleMaterial.color = obstacleColor;
		objectMaterial.color = objectColor;

		progressFillImage.color = progressFillColor;

		Camera.main.backgroundColor = cameraColor;
		backgroundFadeSprite.color = fadeColor;
	}
}
