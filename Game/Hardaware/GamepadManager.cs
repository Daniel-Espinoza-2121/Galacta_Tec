using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading.Tasks;

namespace Galacta_Tec.Hardware
{
    public class GamePadManager
    {
        public static GamePadManager Instance {get; private set; }
        private GamePadState _estadoAnterior;
        private GamePadState _estadoActual;
        public Vector2 Direccion {get; private set; }
        public bool Gatillo {get; private set; }
        public bool BotonStart {get; private set; }
        public bool BotonA {get; private set; }
        public bool BotonB {get; private set; }
        public bool BotonX {get; private set; }
        
        private GamePadManager() {}

        public static void Initialize()
        {
            if (Instance == null) {Instance = new GamePadManager(); }
        }

        public void Update()
        {
            _estadoAnterior = _estadoActual;
            _estadoActual = GamePad.GetState(PlayerIndex.One);

            if (!_estadoActual.IsConnected)
            {
                Direccion = Vector2.Zero;
                Gatillo = false;
                BotonStart = false;
                BotonA = false;
                BotonB = false;
                BotonX = false;
                return;
            }

            Direccion = _estadoActual.ThumbSticks.Left;

            Gatillo = _estadoActual.Triggers.Right >= 0.5f;

            BotonStart = _estadoActual.Buttons.Start == ButtonState.Pressed && _estadoAnterior.Buttons.Start == ButtonState.Released;

            BotonA = _estadoActual.Buttons.A == ButtonState.Pressed && _estadoAnterior.Buttons.A == ButtonState.Released;

            BotonB = _estadoActual.Buttons.B == ButtonState.Pressed && _estadoAnterior.Buttons.B == ButtonState.Released;

            BotonX = _estadoActual.Buttons.X == ButtonState.Pressed && _estadoAnterior.Buttons.X == ButtonState.Released;

        }

        public async Task Vibrar()
        {
            GamePadState estado = GamePad.GetState(PlayerIndex.One);

            if (!estado.IsConnected) {return; }

            try
            {
                GamePad.SetVibration(PlayerIndex.One, 1.0f, 1.0f);
                await Task.Delay(500);
                GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en vibración: {ex.Message}");
            }
        }
    }
}