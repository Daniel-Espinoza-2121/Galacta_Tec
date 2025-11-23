using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Screens;
using Myra;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.File;

namespace Galacta_Tec.GUI
{
    public class SignUpScreen : GameScreen
    {
        private SpriteBatch _spriteBatch;
        private Desktop _desktop;

        public SignUpScreen(Game game) : base(game) { }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MyraEnvironment.Game = Game;

            //File dialog
            var FileDialog = new FileDialog(FileDialogMode.OpenFile);
            FileDialog.Title = "Seleccionar una imagen png";

            //Contenedor principal
            var grid = new Grid
            {
              ShowGridLines = false,
              HorizontalAlignment = HorizontalAlignment.Center,
              VerticalAlignment = VerticalAlignment.Center,
              RowSpacing = 10,
              ColumnSpacing = 10,
              Width = 400,
              Height = 450,
              Background = null,
            };
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Part));
            grid.ColumnsProportions.Add(new Proportion());
            for (int i = 0; i < 15; i++)
            {
                grid.RowsProportions.Add(new Proportion());
            }

            //Nombre de usuario
            var LabelUsuario = new Label
            {
                Text = "Digite su usuario.",
            };
            grid.Widgets.Add(LabelUsuario);
            Grid.SetRow(LabelUsuario, 0);
            Grid.SetColumn(LabelUsuario, 0);

            var TextBoxUsuario = new TextBox();
            grid.Widgets.Add(TextBoxUsuario);
            Grid.SetRow(TextBoxUsuario, 1);
            Grid.SetColumn(TextBoxUsuario, 0);

            //Correo
            var LabelCorreo = new Label
            {
                Text = "Digite su correo.",
            };
            grid.Widgets.Add(LabelCorreo);
            Grid.SetRow(LabelCorreo, 2);
            Grid.SetColumn(LabelCorreo, 0);

            var TextBoxCorreo = new TextBox();
            grid.Widgets.Add(TextBoxCorreo);
            Grid.SetRow(TextBoxCorreo, 3);
            Grid.SetColumn(TextBoxCorreo, 0);

            //Nombre
            var LabelNombre = new Label
            {
                Text = "Digite su Nombre completo.",
            };
            grid.Widgets.Add(LabelNombre);
            Grid.SetRow(LabelNombre, 4);
            Grid.SetColumn(LabelNombre, 0);

            var TextBoxNombre = new TextBox();
            grid.Widgets.Add(TextBoxNombre);
            Grid.SetRow(TextBoxNombre, 5);
            Grid.SetColumn(TextBoxNombre, 0);

            //Imagen de usario
            var LabelImagen = new Label
            {
                Text = "Digite la ruta de su foto de usuario.",
            };
            grid.Widgets.Add(LabelImagen);
            Grid.SetRow(LabelImagen, 6);
            Grid.SetColumn(LabelImagen, 0);

            var TextBoxImagen = new TextBox();
            grid.Widgets.Add(TextBoxImagen);
            Grid.SetRow(TextBoxImagen, 7);
            Grid.SetColumn(TextBoxImagen, 0);

            var ButtonImagen = new Button
            {
                Content = new Label
                {
                    Text = "Buscar..."
                }
            };
            grid.Widgets.Add(ButtonImagen);
            Grid.SetRow(ButtonImagen, 7);
            Grid.SetColumn(ButtonImagen, 1);
            ButtonImagen.Click += (s, e) =>
            {
                FileDialog.Filter = "*.png";
                FileDialog.Closed += (s, e) =>
                {
                    if (FileDialog.Result)
                    {
                        TextBoxImagen.Text = FileDialog.FilePath;
                    }
                };
                FileDialog.ShowModal(_desktop);
            };

            //Foto de nave
            var LabelNave = new Label
            {
                Text = "Digite la ruta de la foto de su nave.",
            };
            grid.Widgets.Add(LabelNave);
            Grid.SetRow(LabelNave, 8);
            Grid.SetColumn(LabelNave, 0);

            var TextBoxNave = new TextBox();
            grid.Widgets.Add(TextBoxNave);
            Grid.SetRow(TextBoxNave, 9);
            Grid.SetColumn(TextBoxNave, 0);
            
            var ButtonNave = new Button
            {
                Content = new Label
                {
                    Text = "Buscar..."
                }
            };
            grid.Widgets.Add(ButtonNave);
            Grid.SetRow(ButtonNave, 9);
            Grid.SetColumn(ButtonNave, 1);
            ButtonNave.Click += (s, e) =>
            {
                FileDialog.Filter = "*.png";
                FileDialog.Closed += (s, e) =>
                {
                    if (FileDialog.Result)
                    {
                        TextBoxNave.Text = FileDialog.FilePath;
                    }
                };
                FileDialog.ShowModal(_desktop);
            };
            
            //musica
            var LabelMusica = new Label
            {
                Text = "Digite la ruta de su canción preferida.",
            };
            grid.Widgets.Add(LabelMusica);
            Grid.SetRow(LabelMusica, 10);
            Grid.SetColumn(LabelMusica, 0);

            var TextBoxMusica = new TextBox();
            grid.Widgets.Add(TextBoxMusica);
            Grid.SetRow(TextBoxMusica, 11);
            Grid.SetColumn(TextBoxMusica, 0);

            var ButtonMusica = new Button
            {
                Content = new Label
                {
                    Text = "Buscar..."
                }
            };
            grid.Widgets.Add(ButtonMusica);
            Grid.SetRow(ButtonMusica, 11);
            Grid.SetColumn(ButtonMusica, 1);
            ButtonMusica.Click += (s, e) =>
            {
                FileDialog.Filter = "*.mp3";
                FileDialog.Closed += (s, e) =>
                {
                    if (FileDialog.Result)
                    {
                        TextBoxMusica.Text = FileDialog.FilePath;
                    }
                };
                FileDialog.ShowModal(_desktop);
            };

            //Contraseña
            var LabelContraseña = new Label
            {
                Text = "Digite su contraseña.",
            };
            grid.Widgets.Add(LabelContraseña);
            Grid.SetRow(LabelContraseña, 12);
            Grid.SetColumn(LabelContraseña, 0);

            var TextBoxContraseña = new TextBox();
            grid.Widgets.Add(TextBoxContraseña);
            Grid.SetRow(TextBoxContraseña, 13);
            Grid.SetColumn(TextBoxContraseña, 0);


            //Cancelar
            var ButtonCancelar = new Button
            {
                Content = new Label
                {
                    Text = "Cancelar",
                },
            };
            grid.Widgets.Add(ButtonCancelar);
            Grid.SetRow(ButtonCancelar, 14);
            Grid.SetColumn(ButtonCancelar, 0);

            //Aplicar
            var ButtonAceptar = new Button
            {
                Content = new Label
                {
                    Text = "Aceptar",
                },
            };
            grid.Widgets.Add(ButtonAceptar);
            Grid.SetRow(ButtonAceptar, 14);
            Grid.SetColumn(ButtonAceptar, 1);

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