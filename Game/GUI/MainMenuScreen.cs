using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Myra;
using Myra.Graphics2D.UI;

namespace Galacta_Tec.GUI
{
    public class MainMenuScreen : GameScreen
    {
        private SpriteBatch _spriteBatch;
        private Desktop _desktop;

        public MainMenuScreen(Game game) : base(game) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MyraEnvironment.Game = Game;

            var grid = new Grid
            {
                RowSpacing = 10,
                ColumnSpacing = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            grid.ColumnsProportions.Add(Proportion.Auto);
            grid.RowsProportions.Add(Proportion.Auto);
            grid.RowsProportions.Add(Proportion.Auto);

            var titulo = new Label
            {
                Text = "Galacta Tec",
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetRow(titulo, 1);
            Grid.SetColumnSpan(titulo, 1);
            grid.Widgets.Add(titulo);

            var jugar = new Button
            {
                Content = new Label
                {
                  Text = "Jugar"
                },
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Grid.SetRow(jugar, 2);
            Grid.SetColumnSpan(jugar, 1);
            grid.Widgets.Add(jugar);
            
            
            

            _desktop = new Desktop();
            _desktop.Root = grid;
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