using System;

namespace Galacta_Tec.Core
{
    public static class Program
    {
        [STAThread]  // ← Necesario para algunas APIs de Windows (ventanas, archivos, etc.)
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
