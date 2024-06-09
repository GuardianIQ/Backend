namespace backend_guardianiq.API.Devices.Models;

public class Device
{
    public int Id { get; set; }
    public string Tipo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Ubicacion { get; set; }
    public string Imagen { get; set; }
}