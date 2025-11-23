using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;

namespace Galacta_Tec.Hardware
{
    public class GamepadManager
    {
        public Vector2 Movimiento = new Vector2();
        public bool Disparar = false;
        public bool A = false;

        public GamepadManager() {}

        public void Update()
        {
            GamePadState estado = GamePad.GetState(PlayerIndex.One);
        }
    }
}