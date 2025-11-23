using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Graphics;
using Galacta_Tec.Core;

namespace Galacta_Tec.Entidades
{
    
    public class NaveJugador : Entidad, IEntity
    {
        public Jugador Owner;
        public Sprite Sprite {get; private set; }
        public Vector2 Posicion;
        public float Velocidad = 300;
        public bool Active = false;
        
        public NaveJugador(Vector2 posicionInical, Texture2D texture, bool Active)
        {
            _tag = TypeEntity.NaveJugador;
            Sprite = new Sprite(texture);
            Posicion = posicionInical;
            Sprite.Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Posicion);
        }

        public override void recibirDaño(int daño)
        {
            
        }

        public void AplicarBonus()
        {
            
        }

        public IShapeF Bounds
        {
            get {return new RectangleF(Posicion, new SizeF(Sprite.TextureRegion.Width, Sprite.TextureRegion.Height)); }
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (!Active) return;
            Entidad entidad = (Entidad)collisionInfo.Other;
            TypeEntity tag = entidad._tag;
            switch (tag)
            {
                case TypeEntity.BalaEnemiga:
                    this.recibirDaño(0);
                    break;
                case TypeEntity.Bonus:
                    this.AplicarBonus();
                    break;
                default:
                    break;
            }
        }
    }
}