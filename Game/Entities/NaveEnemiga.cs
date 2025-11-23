using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Graphics;

namespace Galacta_Tec.Entidades
{
    
    public class NaveEnemiga : Entidad, IEntity
    {
        public Sprite Sprite {get; private set; }
        public Vector2 Posicion;
        public float Velocidad = 300;
        public bool Active = false;
        
        public NaveEnemiga(Vector2 posicionInical, Texture2D texture, bool Active)
        {
            _tag = TypeEntity.NaveEnemiga;
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
                case TypeEntity.BalaJugador:
                    this.recibirDaño(0);
                    break;
                default:
                    break;
            }
        }
    }
}