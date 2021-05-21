using GameBoot.Managers;
using UnityEngine;

namespace GameBoot
{
	public static class GameController
	{
		public static RuntimeEvents RuntimeEvents { get; private set; }
		public static RuntimeData RuntimeData { get; private set; }
		public static SceneLoader SceneLoader { get; private set; }
		public static ResourcesData ResourcesData { get; private set; }
		public static GlobalPrefabsSpawner GlobalPrefabsSpawner { get; private set; }
		
		static MonoGameController monoGameController;
		
		[RuntimeInitializeOnLoadMethod]
		public static void Initialize()
		{
			RuntimeEvents = new RuntimeEvents();
			RuntimeData = new RuntimeData();
			SceneLoader = new SceneLoader();
			ResourcesData = new ResourcesData();
			GlobalPrefabsSpawner = new GlobalPrefabsSpawner();
			
			monoGameController = Object.Instantiate(new GameObject()).AddComponent<MonoGameController>();
			Object.DontDestroyOnLoad(monoGameController);
		}

		public static void Update()
		{
			
		}
	}
}