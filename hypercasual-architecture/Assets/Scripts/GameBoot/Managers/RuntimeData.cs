namespace GameBoot.Managers
{
	public class RuntimeData
	{
		public int SceneIndex { get; set; }
		
		public RuntimeData()
		{
			GameController.RuntimeEvents.OnLoadLevel += ResetData;
		}

		void ResetData()
		{
			
		}
	}
}