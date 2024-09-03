using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Definir las rutas de origen
        string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string descargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        // Definir la ruta del USB (asegúrate de cambiar la letra de la unidad según tu configuración)
        string usb = "D:\\Roboto";

        // Crear las carpetas en el USB si no existen
        Directory.CreateDirectory(usb);
        Directory.CreateDirectory(Path.Combine(usb, "Documentos"));
        Directory.CreateDirectory(Path.Combine(usb, "Descargas"));

        // Copiar Documentos
        CopyFilesRecursively(new DirectoryInfo(documentos), new DirectoryInfo(Path.Combine(usb, "Documentos")));

        // Copiar Descargas
        CopyFilesRecursively(new DirectoryInfo(descargas), new DirectoryInfo(Path.Combine(usb, "Descargas")));

        Console.WriteLine("Archivos copiados con éxito.");
    }

    public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
    {
        foreach (DirectoryInfo dir in source.GetDirectories())
        {
            CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
        }
        foreach (FileInfo file in source.GetFiles())
        {
            file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }
    }
}
