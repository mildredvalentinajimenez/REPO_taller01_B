using System;
using System.IO; 
using System.Text;

namespace Persistencia01
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==== TALLER SECCION B =====");
            Console.WriteLine("=== SISTEMA DE GESTIÓN EDUCATIVA IUJO ===\n");

            string registroBruto = " ID_777; Jose Cadenas; EXAMEN_FINAL.PDF; 95 ";

            string dataLimpia = registroBruto.Trim(); 
            string[] partes = dataLimpia.Split(';'); 

            string id = partes[0].Trim();
            string nombre = partes[1].Trim().ToUpper(); 
            string archivo = partes[2].Trim().ToLower(); 
            string nota = partes[3].Trim();

            string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
            string rutaReportes = Path.Combine(rutaRaiz, "Reportes");

            if (!Directory.Exists(rutaReportes)) {
                Directory.CreateDirectory(rutaReportes);
            }

            string archivoTexto = Path.Combine(rutaReportes, "notas.txt");
            using (StreamWriter sw = new StreamWriter(archivoTexto, true)) {
                sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm}] ESTUDIANTE: {nombre} | NOTA: {nota}");
            }

            FileInfo info = new FileInfo(archivoTexto);
            Console.WriteLine($"\n[ESTADÍSTICAS] El archivo de notas pesa: {info.Length} bytes.");

            Console.WriteLine("\n=== PROCESO FINALIZADO. ===");
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey(true);
        }
    }
}
