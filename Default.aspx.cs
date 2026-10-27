using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculadoraJuan
{
    public partial class Calculadora : Page
    {
        // ViewState conserva estos valores entre los clics (postbacks).
        private double PrimerNumero
        {
            get { return ViewState["PrimerNumero"] == null ? 0 : (double)ViewState["PrimerNumero"]; }
            set { ViewState["PrimerNumero"] = value; }
        }
        private string Operacion
        {
            get { return (string)ViewState["Operacion"] ?? ""; }
            set { ViewState["Operacion"] = value; }
        }
        private bool NuevaEntrada
        {
            get { return ViewState["NuevaEntrada"] == null || (bool)ViewState["NuevaEntrada"]; }
            set { ViewState["NuevaEntrada"] = value; }
        }
        private bool SegundoIngresado
        {
            get { return ViewState["SegundoIngresado"] != null && (bool)ViewState["SegundoIngresado"]; }
            set { ViewState["SegundoIngresado"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LimpiarPantalla();
        }

        protected void Numero_Click(object sender, EventArgs e)
        {
            string digito = ((Button)sender).Text;
            Mensaje.Text = "";
            if (NuevaEntrada)
            {
                Pantalla.Text = "0";
                NuevaEntrada = false;
            }
            if (digito == ".")
            {
                if (!Pantalla.Text.Contains(".")) Pantalla.Text += ".";
            }
            else if (Pantalla.Text == "0") Pantalla.Text = digito;
            else if (Pantalla.Text.Length < 16) Pantalla.Text += digito;
            else Mensaje.Text = "Máximo 16 caracteres por número.";

            if (Operacion != "") SegundoIngresado = true;
        }

        protected void Operacion_Click(object sender, EventArgs e)
        {
            // Si hay dos números, resolvemos antes de encadenar otra operación.
            if (Operacion != "" && SegundoIngresado && !Calcular()) return;
            PrimerNumero = LeerNumero();
            Operacion = ((Button)sender).CommandArgument;
            NuevaEntrada = true;
            SegundoIngresado = false;
            Mensaje.Text = "Operación: " + ((Button)sender).Text + ". Ingresá el segundo número.";
        }

        protected void Igual_Click(object sender, EventArgs e)
        {
            if (Operacion == "") { Mensaje.Text = "Seleccioná una operación."; return; }
            if (!SegundoIngresado) { Mensaje.Text = "Ingresá el segundo número."; return; }
            Calcular();
        }

        private bool Calcular()
        {
            double segundoNumero = LeerNumero();
            double resultado;
            switch (Operacion)
            {
                case "+": resultado = PrimerNumero + segundoNumero; break;
                case "-": resultado = PrimerNumero - segundoNumero; break;
                case "*": resultado = PrimerNumero * segundoNumero; break;
                case "/":
                    if (segundoNumero == 0)
                    {
                        MostrarError("No se puede dividir entre cero.");
                        return false;
                    }
                    resultado = PrimerNumero / segundoNumero;
                    break;
                default: return false;
            }
            Operacion = "";
            SegundoIngresado = false;
            return MostrarResultado(resultado);
        }

        protected void Unaria_Click(object sender, EventArgs e)
        {
            if (Operacion != "" && !SegundoIngresado)
            {
                Mensaje.Text = "Ingresá el segundo número antes de aplicar la función.";
                return;
            }
            double numero = LeerNumero();
            double resultado;
            switch (((Button)sender).CommandArgument)
            {
                case "cuadrado": resultado = Math.Pow(numero, 2); break;
                case "exp": resultado = Math.Exp(numero); break;
                case "diez": resultado = Math.Pow(10, numero); break;
                default: return;
            }
            MostrarResultado(resultado);
        }

        private double LeerNumero()
        {
            // La pantalla utiliza siempre punto decimal, sin depender del idioma del equipo.
            return double.Parse(Pantalla.Text, CultureInfo.InvariantCulture);
        }

        private bool MostrarResultado(double resultado)
        {
            if (double.IsNaN(resultado) || double.IsInfinity(resultado))
            {
                MostrarError("El resultado es demasiado grande o no se puede calcular.");
                return false;
            }
            Pantalla.Text = resultado.ToString("G15", CultureInfo.InvariantCulture);
            NuevaEntrada = true;
            Mensaje.Text = "";
            return true;
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            // No se recortan resultados ni exponentes: el borrado edita la entrada actual.
            if (NuevaEntrada) return;
            string texto = Pantalla.Text;
            Pantalla.Text = texto.Length > 1 ? texto.Substring(0, texto.Length - 1) : "0";
            Mensaje.Text = "";
        }

        protected void Limpiar_Click(object sender, EventArgs e) { LimpiarPantalla(); }

        private void LimpiarPantalla()
        {
            PrimerNumero = 0;
            Operacion = "";
            SegundoIngresado = false;
            NuevaEntrada = true;
            Pantalla.Text = "0";
            Mensaje.Text = "";
        }

        private void MostrarError(string mensaje)
        {
            LimpiarPantalla();
            Mensaje.Text = mensaje;
        }
    }
}
