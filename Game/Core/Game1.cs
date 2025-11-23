using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Collisions;
using Galacta_Tec.Core;
using Galacta_Tec.GUI;
using Galacta_Tec.Entidades;
using Galacta_Tec.Datos;


namespace Galacta_Tec.Core;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private ScreenManager _ScreenManager;
    private readonly CollisionComponent _collisionComponent;
    private ResourceLoader _resourceLoader;

    int WindowWidth = 750;
    int WindowHeight = 500;

    BalaEnemiga bala;
    NaveJugador bala2;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _collisionComponent = new CollisionComponent(new RectangleF(75, 0, WindowWidth - 75, WindowHeight));
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = WindowWidth;
        _graphics.PreferredBackBufferHeight = WindowHeight;
        Window.Title = "Galacta Tec";
        Window.AllowUserResizing = false;
        _graphics.ApplyChanges();

        _ScreenManager = new ScreenManager();
        Components.Add(_ScreenManager);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _resourceLoader = ResourceLoader._Instance(_graphics.GraphicsDevice, this);
        
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        _ScreenManager.Update(gameTime);
        _collisionComponent.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.End();
        
        base.Draw(gameTime);
    }
}
