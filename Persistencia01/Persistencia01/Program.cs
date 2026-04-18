using System;
using System.IO; 
using System.Text;

namespace Persistencia01
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Taller Seccion B ---");

            // Datos del estudiante para procesar
            string dato = " 102; Mildred_Jimenez; tarea_final.pdf; 20 ";
            string p1 = dato.Trim(); 
            string[] s = p1.Split(';'); 
            
            // Crear carpetas si no existen
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MisDatos", "Archivos");
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            // Guardar registro en el archivo de notas
            string f1 = Path.Combine(dir, "notas_finales.txt");
            using (StreamWriter sw = new StreamWriter(f1, true)) {
                sw.WriteLine("Alumno: " + s[1].Trim() + " | Calificacion: " + s[3].Trim());
            }

            // Desafio 1: Validar seguridad de la clave
            string miClave = "usuario; pass123";
            if (miClave.Contains("123")) {
                string f2 = Path.Combine(dir, "alerta.txt");
                File.WriteAllText(f2, "alerta de seguridad: clave muy facil");
            }

            // Desafio 2: Copiar archivo byte a byte con FileStream
            string origenImg = Path.Combine(dir, "imagen.jpg");
            string destinoImg = Path.Combine(dir, "imagen_nueva.jpg");
            
            if (!File.Exists(origenImg)) {
                File.WriteAllText(origenImg, "bin"); 
            }

            using (FileStream fs1 = new FileStream(origenImg, FileMode.Open))
            using (FileStream fs2 = new FileStream(destinoImg, FileMode.Create)) {
                fs1.CopyTo(fs2);
            }

            // Desafio 3: Buscar y borrar archivos mayores a 5KB
            DirectoryInfo info = new DirectoryInfo(dir);
            FileInfo[] lista = info.GetFiles();
            
            foreach (FileInfo archi in lista) {
                if (archi.Length > 5120) { 
                    Console.WriteLine("Quitando archivo pesado: " + archi.Name);
                    archi.Delete();
                }
            }

            Console.WriteLine("Proceso finalizado");
            Console.ReadKey(true);
        }
    }
}
