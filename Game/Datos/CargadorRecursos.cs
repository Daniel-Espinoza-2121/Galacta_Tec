using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Resources;
using Myra.Graphics2D.UI;
using MonoGame;
using System.Diagnostics.Tracing;

namespace Galacta_Tec.Datos
{
    /*
    patrones de diseño usados:
    factory method
    singleton
    
    */
    public abstract class ResourceFactory
    {
        public abstract object Load(string path);
    }
    public class TextureFactory : ResourceFactory
    {
        private GraphicsDevice graphicsDevice;

        public TextureFactory(GraphicsDevice gd)
        {
            graphicsDevice = gd;
        }

        public override object Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return Texture2D.FromStream(graphicsDevice, stream);
            }
        }
    }
    public class SongFactory : ResourceFactory
    {
        public override object Load(string path)
        {
            return Song.FromUri(Path.GetFileNameWithoutExtension(path), new Uri(path));
        }
    }

    public class ResourceLoader
    {
        public static ResourceLoader _instance;
        private Game _game;
        private GraphicsDevice _gd;
        private TextureFactory _textureFactory;
        private SongFactory _songFactory;
        private Dictionary<string, Texture2D> _Textures;

        public enum Options
        {
            Image,
            Audio,
            ExistingTexture,
        }

        private ResourceLoader(GraphicsDevice gd, Game game)
        {
            _game = game;
            _gd = gd;
            _textureFactory = new TextureFactory(gd);
            _songFactory = new SongFactory();
            _Textures = new Dictionary<string, Texture2D>();
        }
        public static ResourceLoader _Instance(GraphicsDevice gd = null, Game game = null)
        {
            if (_instance == null) 
            {
                if (gd == null) throw new NotSupportedException();
                _instance = new ResourceLoader(gd, game);
            }
            return _instance;
        }

        public object LoadResource(Options option, string path)
        {
            switch (option)
            {
                case Options.Image:
                    return _textureFactory.Load(path);
                case Options.Audio:
                    return _songFactory.Load(path);
                case Options.ExistingTexture:
                    return GetTexture2D(path);
                default:
                    throw new NotSupportedException();
            }
        }

        private Texture2D GetTexture2D(string name)
        {
            if (!_Textures.ContainsKey(name))
            {
                _Textures[name] = _game.Content.Load<Texture2D>(name);
            }
            return _Textures[name];
        }
    }
}