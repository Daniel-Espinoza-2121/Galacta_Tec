using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Graphics;
using Galacta_Tec.Core;

namespace Galacta_Tec.Entidades
{
    
    public class BalaEnemiga : Entidad, IEntity
    {
        public Jugador Owner;
        public Sprite Sprite {get; private set; }
        public Vector2 Posicion;
        public float Velocidad = 700;
        public bool Active = false;
        
        public BalaEnemiga(Vector2 posicionInical, bool active, Texture2D texture)
        {
            _tag = TypeEntity.BalaEnemiga;
            Sprite = new Sprite(texture);
            Posicion = posicionInical;
            Sprite.Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            SetActive(active);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active) return;
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Posicion.Y += Velocidad * dt;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Posicion);
        }

        public void SetActive(bool value)
        {
            Active = value;
            Sprite.IsVisible = value;
        }

        public override void recibirDaño(int daño) {}

        public IShapeF Bounds
        {
            get {return new RectangleF(Posicion, new SizeF(Sprite.TextureRegion.Width, Sprite.TextureRegion.Height)); }
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (!Active) return;
            Entidad entidad = (Entidad)collisionInfo.Other;
            TypeEntity tag = entidad._tag;
            if (tag == TypeEntity.NaveJugador)
            {
                entidad.recibirDaño(1);
                SetActive(false);
                Posicion.X = -100;
                Posicion.Y = -100;
            }
        }
    }
}