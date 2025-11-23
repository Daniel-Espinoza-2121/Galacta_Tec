using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Myra;
using Myra.Graphics2D.UI;

namespace Galacta_Tec.GUI
{
    public class SigInScreen : GameScreen
    {
        private SpriteBatch _spriteBatch;
        private Desktop _desktop;

        public SigInScreen(Game game) : base(game) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MyraEnvironment.Game = Game;

            //Contenedor proncipal
            var stackvertical = new VerticalStackPanel
            {
              ShowGridLines = false,
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center,
              Spacing = 10,
              Background = null,
            };
            
            //Nombre de usuario
            var LabelUsuario = new Label
            {
                Text = "Digite su usuario.",
            };
            stackvertical.Widgets.Add(LabelUsuario);

            var TextBoxUsuario = new TextBox();
            stackvertical.Widgets.Add(TextBoxUsuario);

            //Contraseña
            var LabelContraseña = new Label
            {
                Text = "Digite su contraseña.",
            };
            stackvertical.Widgets.Add(LabelContraseña);

            var TextBoxContraseña = new TextBox();
            stackvertical.Widgets.Add(TextBoxContraseña);

            //Contenedor de botones
            var StackHorizontal = new HorizontalStackPanel
            {
              ShowGridLines = true,
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center,
              Spacing = 10,
              Background = null,
            };
            stackvertical.Widgets.Add(StackHorizontal);
            
            //Cancelar
            var ButtonCancelar = new Button
            {
                Content = new Label
                {
                    Text = "Cancelar",
                },
            };
            StackHorizontal.Widgets.Add(ButtonCancelar);

            //Olvide la cantraseña
            var ButtonOlvido = new Button
            {
                Content = new Label
                {
                    Text = "Olvidé la contraseña",
                },
            };
            StackHorizontal.Widgets.Add(ButtonOlvido);

            //Registrar
            var ButtonRegistrar = new Button
            {
                Content = new Label
                {
                    Text = "Registrar nuevo usuario",
                },
            };
            StackHorizontal.Widgets.Add(ButtonRegistrar);

            //Aceptar
            var ButtonAceptar = new Button
            {
                Content = new Label
                {
                    Text = "Aceptar",
                },
            };
            StackHorizontal.Widgets.Add(ButtonAceptar);
            
            _desktop = new Desktop();
            _desktop.Root = stackvertical;
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _desktop.Render();
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _desktop.Render();
        }
    }
}