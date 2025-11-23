using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Galacta_Tec.Entidades;

namespace Galacta_Tec.Core
{
    public class Jugador
    {
        string Usuario;
        string Nombre;
        string CorreoElectronico;
        //Texture2D Foto;
        NaveJugador Nave;
        Song Cancion;
        public int puntaje = 0;

        public Jugador(
            string usuario,
            string nombre,
            string correoElectronico,
            Texture2D foto,
            Texture2D nave,
            Song cancion)
        {
            Usuario = usuario;
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Nave = new NaveJugador(new Vector2(-100, -100), nave, false);
            Cancion = cancion;
        }
    }
    
}