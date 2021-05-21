using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBoot.Managers
{
	public class SceneLoader
	{
		public void SetScene(int sceneIndex)
		{
			GameController.RuntimeData.SceneIndex = sceneIndex;
			LoadCurrentScene();
		}
		
		public void LoadNextScene()
		{
			GameController.RuntimeData.SceneIndex++;
			LoadCurrentScene();
		}
		
		public void LoadPrevScene()
		{
			GameController.RuntimeData.SceneIndex--;
			LoadCurrentScene();
		}

		public void LoadCurrentScene()
		{
			GameController.RuntimeEvents.OnLoadLevel?.Invoke();
			SceneManager.LoadScene(GameController.RuntimeData.SceneIndex);
			Debug.Log("Loaded scene index: " + GameController.RuntimeData.SceneIndex);
		}

		public void LoadInitialScene()
		{
			SceneManager.LoadScene(GameController.RuntimeData.SceneIndex);
			Debug.Log("Loaded scene index: " + GameController.RuntimeData.SceneIndex);
		}
	}
}