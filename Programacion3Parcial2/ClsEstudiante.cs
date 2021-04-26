using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programacion3Parcial2
{
    class ClsEstudiante:Comparador
    {
        public string apellidos { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string id { get; set; }
        //public int idAño { get; set; }
        public double notaLab1 { get; set; }
        public double notaLab2 { get; set; }
        public double notaLab3 { get; set; }
        public double notaLab4 { get; set; }

        public ClsEstudiante(string apellidos, string nombre, string correo, string id, double notaLab1, double notaLab2, double notaLab3, double notaLab4)
        {
            this.apellidos = apellidos;
            this.nombre = nombre;
            this.correo = correo;
            this.id = id;
            this.notaLab1 = notaLab1;
            this.notaLab2 = notaLab2;
            this.notaLab3 = notaLab3;
            this.notaLab4 = notaLab4;
        }

        public ClsEstudiante()
        {
        }

        public bool igualQue(object q)
        {
            ClsEstudiante aux = (ClsEstudiante)q;
            return correo.Equals(aux.correo);
            //return correo == aux.correo;
        }

        public bool menorQue(object q)
        {
            ClsEstudiante aux = (ClsEstudiante)q;
            char delimitador = '-';
            string[] auxId = id.Split(delimitador);
            string[] auxIdAnterior = aux.id.Split(delimitador);

            if (int.Parse(auxId[0]) < int.Parse(auxIdAnterior[0]))
            {
                return true;
            }
            else if (int.Parse(auxId[0]) == int.Parse(auxIdAnterior[0]))
            {
                if (int.Parse(auxId[1]) < int.Parse(auxIdAnterior[1]))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool mayorQue(object q)
        {
            ClsEstudiante aux = (ClsEstudiante)q;
            char delimitador = '-';
            string[] auxId = id.Split(delimitador);
            string[] auxIdAnterior = aux.id.Split(delimitador);

            if (int.Parse(auxId[0]) > int.Parse(auxIdAnterior[0]))
            {
                return true;
            }
            else if (int.Parse(auxId[0]) == int.Parse(auxIdAnterior[0]))
            {
                if (int.Parse(auxId[1]) > int.Parse(auxIdAnterior[1]))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override string ToString()
        {

            return  "" + id + "\t" + "   " + nombre + " " + apellidos + "\t"+ "\t" + correo + "" + Environment.NewLine;
        }
        public  string Mostrar()
        {

            return correo;
        }
    }
}
