using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Myra;
using Myra.Graphics2D.UI;
using MonoGame.Extended.Serialization;
using Microsoft.Xna.Framework.Graphics;



namespace Galacta_Tec.Datos
{
    public class MemoUsuario
    {
        public string usuario;
        public string nombre;
        public string correoElectronico;
        public string foto;
        public string nave;
        public string cancion;

        // Constructor
        public MemoUsuario(string usuario, string nombre, string correoElectronico,
                        string foto, string nave, string cancion)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.correoElectronico = correoElectronico;
            this.foto = foto;
            this.nave = nave;
            this.cancion = cancion;
        }
    }

    public class Puntaje
    {
        public string Usuario;
        public int Puntos;
    }
    
    public class SistemaGuardado
    {
        private Game _game;
        private static SistemaGuardado _instancia;
        private List<MemoUsuario> _listaUsuarios = new List<MemoUsuario>();
        private List<Puntaje> _mejoresPuntajes = new List<Puntaje>();
        public static SistemaGuardado Instancia(Game game)
        {
            if (_instancia == null)
            {
                _instancia = new SistemaGuardado(game);
            }
            return _instancia;
            
        }

        private SistemaGuardado(Game game)
        {
            _game = game;
            _listaUsuarios = _LoadUsuarios();
            _mejoresPuntajes = _LoadPuntajes();
        }

        private List<MemoUsuario> _LoadUsuarios()
        {
            try
            {
                string path = Environment.CurrentDirectory;
                path = Path.Combine(path,"..", "..", "Game", "Datos", "usuarios.json");
                string archivo = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<MemoUsuario>>(archivo);
            }
            catch 
            {
                return new List<MemoUsuario>();
            }
        }

        private bool _SaveUsuarios()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory,"..", "..", "Game", "Datos", "usuarios.json");
                string contenido = JsonSerializer.Serialize(_listaUsuarios, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, contenido);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private List<Puntaje> _LoadPuntajes()
        {
            try
            {
                string path = Environment.CurrentDirectory;
                path = Path.Combine(path,"..", "..", "Datos", "puntajes.json");
                string archivo = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Puntaje>>(archivo);
            }
            catch 
            {
                return new List<Puntaje>();
            }
        }

        private bool _SavePuntajes()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory,"..", "..", "Datos", "puntajes.json");
                string contenido = JsonSerializer.Serialize(_listaUsuarios, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, contenido);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddUsuario
        (
            string usuario,
            string nombre,
            string correoElectronico,
            string foto,
            string nave, 
            string cancion
        )
        {
            List<MemoUsuario> backup = new List<MemoUsuario>(_listaUsuarios);
            _listaUsuarios.Add(new MemoUsuario(usuario, nombre, correoElectronico, foto, nave, cancion));
            if (_SaveUsuarios())
            {
                return true;
            }
            else
            {
                _listaUsuarios = backup;
                return false;
            }

        }
    }
}