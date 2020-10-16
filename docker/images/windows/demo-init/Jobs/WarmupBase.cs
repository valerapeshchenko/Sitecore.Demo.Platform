﻿namespace Sitecore.Demo.Init.Jobs
{
	using System;
	using System.Net;
	using System.Threading.Tasks;

	public class WarmupBase: TaskBase
	{

		protected static async Task LoadUrl(string baseUrl, string path, WebClient client)
		{
			for (int i = 0; i < 10; i++)
			{
				try
				{
					Console.WriteLine($"{DateTime.UtcNow} Loading {baseUrl}{path}");
					await client.DownloadStringTaskAsync($"{baseUrl}/{path}");
					return;
				}
				catch (Exception ex)
				{
					// Ignore exceptions during warmup
					Console.WriteLine($"{DateTime.UtcNow} Failed to load {baseUrl}{path}: \r\n {ex}");
				}

				await Task.Delay(1000);
			}
		}
	}
}
