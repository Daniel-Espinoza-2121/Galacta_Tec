using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Galacta_Tec.Patrones
{
    public abstract class Patron
    {
        protected int PuntoActual = 0;
        protected List<Vector2> WayPoints = new List<Vector2>();
        public bool Ciclico { get; protected set; } = true;
        public float Velocidad { get; protected set; } = 200f;
        
        protected int Width;
        protected int Height;
        protected float MargenSeguridad = 50f;

        public Patron(Vector2 centro, int width, int height)
        {
            Width = width;
            Height = height;
            GenerarPatron(centro, width, height);
        }

        protected abstract void GenerarPatron(Vector2 centro, int width, int height);
        
        public virtual void SiguientePunto()
        {
            if (WayPoints.Count == 0) return;
            
            PuntoActual += 1;
            
            if (Ciclico)
            {
                PuntoActual %= WayPoints.Count;
            }
            else
            {
                if (PuntoActual >= WayPoints.Count)
                {
                    PuntoActual = WayPoints.Count - 1;
                }
            }
        }

        public Vector2 GetPuntoActual()
        {
            if (WayPoints.Count == 0)
                return Vector2.Zero;
                
            return WayPoints[PuntoActual];
        }

        public bool HaTerminado()
        {
            return !Ciclico && PuntoActual >= WayPoints.Count - 1;
        }

        public void Reiniciar()
        {
            PuntoActual = 0;
        }

        protected Vector2 ClampPunto(Vector2 punto)
        {
            return new Vector2(
                MathHelper.Clamp(punto.X, MargenSeguridad, Width - MargenSeguridad),
                MathHelper.Clamp(punto.Y, MargenSeguridad, Height - MargenSeguridad)
            );
        }
    }

    // 1️⃣ Patrón Circular
    public class PatronCircular : Patron
    {
        public PatronCircular(Vector2 centro, int width, int height) 
            : base(centro, width, height) 
        {
            Velocidad = 160f;
            Ciclico = true;
        }

        protected override void GenerarPatron(Vector2 centro, int width, int height)
        {
            float radio = 200f;
            int puntos = 16;
            
            for (int i = 0; i < puntos; i++)
            {
                float angulo = MathHelper.ToRadians((360f / puntos) * i);
                float x = centro.X + (float)System.Math.Cos(angulo) * radio;
                float y = centro.Y + (float)System.Math.Sin(angulo) * radio;
                
                WayPoints.Add(ClampPunto(new Vector2(x, y)));
            }
        }
    }

    // 2️⃣ Patrón ZigZag (Horizontal)
    public class PatronZigZag : Patron
    {
        public PatronZigZag(Vector2 centro, int width, int height) 
            : base(centro, width, height) 
        {
            Velocidad = 180f;
            Ciclico = true;
        }

        protected override void GenerarPatron(Vector2 centro, int width, int height)
        {
            int numZigs = 6;
            float yInicio = MargenSeguridad + 100;
            float yFin = height - MargenSeguridad - 100;
            float incrementoY = (yFin - yInicio) / (numZigs - 1);
            
            // Bajar en zigzag
            for (int i = 0; i < numZigs; i++)
            {
                float x = (i % 2 == 0) 
                    ? MargenSeguridad + 100 
                    : width - MargenSeguridad - 100;
                float y = yInicio + (i * incrementoY);
                
                WayPoints.Add(new Vector2(x, y));
            }
            
            // Subir en zigzag (para hacer el patrón cíclico)
            for (int i = numZigs - 2; i > 0; i--)
            {
                float x = (i % 2 == 0) 
                    ? MargenSeguridad + 100 
                    : width - MargenSeguridad - 100;
                float y = yInicio + (i * incrementoY);
                
                WayPoints.Add(new Vector2(x, y));
            }
        }
    }

    // 3️⃣ Patrón en V
    public class PatronV : Patron
    {
        public PatronV(Vector2 centro, int width, int height) 
            : base(centro, width, height) 
        {
            Velocidad = 180f;
            Ciclico = true;
        }

        protected override void GenerarPatron(Vector2 centro, int width, int height)
        {
            float margen = MargenSeguridad + 50;
            
            // Centro superior
            WayPoints.Add(new Vector2(centro.X, margen));
            
            // Izquierda medio
            WayPoints.Add(new Vector2(margen, height / 2f));
            
            // Centro inferior
            WayPoints.Add(new Vector2(centro.X, height - margen));
            
            // Derecha medio
            WayPoints.Add(new Vector2(width - margen, height / 2f));
            
            // Volver al centro superior
            WayPoints.Add(new Vector2(centro.X, margen));
        }
    }

    // 4️⃣ Patrón Horizontal (Ida y Vuelta)
    public class PatronHorizontal : Patron
    {
        public PatronHorizontal(Vector2 centro, int width, int height) 
            : base(centro, width, height) 
        {
            Velocidad = 200f;
            Ciclico = true;
        }

        protected override void GenerarPatron(Vector2 centro, int width, int height)
        {
            float y = centro.Y;
            
            // Ir a la izquierda
            WayPoints.Add(new Vector2(MargenSeguridad + 50, y));
            
            // Ir a la derecha
            WayPoints.Add(new Vector2(width - MargenSeguridad - 50, y));
        }
    }

    // 5️⃣ Patrón Cuadrado
    public class PatronCuadrado : Patron
    {
        public PatronCuadrado(Vector2 centro, int width, int height) 
            : base(centro, width, height) 
        {
            Velocidad = 190f;
            Ciclico = true;
        }

        protected override void GenerarPatron(Vector2 centro, int width, int height)
        {
            float lado = 300f;
            float mitadLado = lado / 2f;
            
            // Esquina superior izquierda
            WayPoints.Add(ClampPunto(new Vector2(centro.X - mitadLado, centro.Y - mitadLado)));
            
            // Esquina superior derecha
            WayPoints.Add(ClampPunto(new Vector2(centro.X + mitadLado, centro.Y - mitadLado)));
            
            // Esquina inferior derecha
            WayPoints.Add(ClampPunto(new Vector2(centro.X + mitadLado, centro.Y + mitadLado)));
            
            // Esquina inferior izquierda
            WayPoints.Add(ClampPunto(new Vector2(centro.X - mitadLado, centro.Y + mitadLado)));
        }
    }
}