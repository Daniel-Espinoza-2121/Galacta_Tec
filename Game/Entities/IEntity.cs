using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collisions;

namespace Galacta_Tec.Entidades
{
    public enum TypeEntity
    {
        NaveJugador,
        NaveEnemiga,
        BalaJugador,
        BalaEnemiga,
        BalaEnemigaEspecial,
        Bonus,
        BonusEscudo,
        BonusPuntosDobles,
        BonusVidaExtra,
    }

    public interface IEntity : ICollisionActor
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);
    }

    public abstract class Entidad
    {
        public TypeEntity _tag;
        public abstract void recibirDaño(int daño);
    }

    public static class Rect
    {
        public static Texture2D CrearRectangulo(GraphicsDevice graphics, int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(graphics, width, height);

            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++)
                data[i] = color;

            texture.SetData(data);
            return texture;
        }
    }
}