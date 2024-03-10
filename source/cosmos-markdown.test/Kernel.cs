using System;
using CosmosTTF;
using PrismAPI.Graphics;
using Cosmos.Core.Memory;
using PrismAPI.Hardware.GPU;

namespace cosmos_markdown.test
{
    public class Kernel : Cosmos.System.Kernel
    {
        static Display Screen = Display.GetDisplay(1080, 1920);

        protected override void BeforeRun()
        {
            try
            {
                Screen.Clear(Color.White);
                Screen.Update();
                
                Renderer.RenderMarkdownDocument(Screen, Resources.Markdown, new Font(Resources.Regular, Resources.Bold, Resources.Italic, Resources.BoldItalic));

                Screen.Update();
            }
            catch (Exception ex)
            {
                Screen.IsEnabled = false;
                Console.WriteLine(ex);
            }
        }

        protected override void Run() => Heap.Collect();
    }
}
