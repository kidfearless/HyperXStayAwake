using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace HyperXStayAwake
{
	public class Program
	{
		public static async Task Main()
		{
			var generator = new SignalGenerator()
			{
				Gain = 0.05,
				Frequency = 1,
				Type = SignalGeneratorType.Sin
			};
			var sineWave = generator.Take(TimeSpan.MaxValue);
			using var player = new WaveOutEvent();
			player.Init(sineWave);
			player.Play();
			await Task.Delay(-1);
		}
	}
}
