namespace School_management.Interfaces
{
    public interface IFileRepository
    {

        string SaveFile(IFormFile file);
        bool DeleteFile(string filename);
        byte[] GetFile(string filesName);

        string SaveImage(IFormFile file);
        bool DeleteImage(string filename);
        byte[] GetImage(string filesName);


    }
}
