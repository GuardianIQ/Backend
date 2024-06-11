namespace backend_guardianiq.API.Devices.Domain.Models;

public class Device
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Ubication { get; set; }
    public string Imagen { get; set; }
}