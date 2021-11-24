using System;
using System.Diagnostics;
using System.Threading;

namespace RayTracing
{
    class Program
	{
		static void SetWindow(int Width, int Height)
		{
            Console.SetWindowSize(Width, Height);
			Console.SetBufferSize(Width, Height);
        }
		private const int FPS = 60;
		private const int DELAY = 1000/FPS;

        static void draw()
        {
			int width = Console.LargestWindowWidth - 1;
			int height = Console.LargestWindowHeight - 1;
			SetWindow(width, height);
			float aspect = (float)width / height;
			float pixelAspect = 11.0f / 24.0f;
			char[] gradient = " .:!/r(l1Z4H9W8$@".ToCharArray();
			int gradientSize = gradient.Length - 2;

			var screen = new char[width * height];

			Stopwatch watch = new Stopwatch();
			watch.Restart();
			for (int t = 0; t < 10000; t++)
			{
				vec3 light = VecFunctions.norm(new vec3(-0.5f, 0.5f, -1.0f));
				vec3 spherePos = new vec3(0, 3, 0);
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						vec2 uv = new vec2(i, j) / new vec2(width, height) * 2.0f - 1.0f;
						uv.x *= aspect * pixelAspect;
						vec3 ro = new vec3(-6, 0, 0);
						vec3 rd = VecFunctions.norm(new vec3(2, uv));
						ro = VecFunctions.rotateY(ro, 0.25);
						rd = VecFunctions.rotateY(rd, 0.25);
						ro = VecFunctions.rotateZ(ro, t * 0.01);
						rd = VecFunctions.rotateZ(rd, t * 0.01);
						float diff = 1;
						for (int k = 0; k < 5; k++)
						{
							float minIt = 99999;
							vec2 intersection = VecFunctions.sphere(ro - spherePos, rd, 1);
							vec3 n = new vec3(0);
							float albedo = 1;
							if (intersection.x > 0)
							{
								vec3 itPoint = ro - spherePos + rd * intersection.x;
								minIt = intersection.x;
								n = VecFunctions.norm(itPoint);
							}
							vec3 boxN = new vec3(0);
							intersection = VecFunctions.box(ro, rd, new vec3(1), out boxN);
							if (intersection.x > 0 && intersection.x < minIt)
							{
								minIt = intersection.x;
								n = boxN;
							}
							intersection = new vec2(VecFunctions.plane(ro, rd, new vec3(0, 0, -1), 1f));
							if (intersection.x > 0 && intersection.x < minIt)
							{
								minIt = intersection.x;
								n = new vec3(0, 0, -1);
								albedo = 0.5f;
							}
							if (minIt < 99999)
							{
								diff *= (VecFunctions.dot(n, light) * 0.5f + 0.5f) * albedo;
								ro = ro + rd * (minIt - 0.01f);
								rd = VecFunctions.reflect(rd, n);
							}
							else break;
						}
						int color = (int)(diff * 20);
						color = (int)VecFunctions.clamp(color, 0, gradientSize);
						char pixel = gradient[color];
						screen[i + j * width] = pixel;
					}
				}
				screen[width * height - 1] = '\0';
				Thread.Sleep(DELAY - Math.Min(DELAY, (int)watch.ElapsedMilliseconds));
				watch.Restart();
				Console.SetCursorPosition(0, 0);
				Console.Write(screen);
			}
		}
		static void Main(string[] args)
		{
			draw();
		}
	}
}
