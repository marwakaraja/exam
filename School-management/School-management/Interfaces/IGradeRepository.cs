using School_management.DTO;
using schoolManagement.Models;

namespace School_management.Interfaces
{
    public interface IGradeRepository
    {
        IList<Grade> GetGrades();
        Grade GetGrade(int ID);
        Grade InsertGrade(Grade objGarde);
        Grade UpdateGrade(int GradeId, Grade objGrade);
        Grade DeleteGrade(int GradeID);

        IList<Video> GetVideos(int GradeID);
        Video GetVideo(int GradeID, int VideoId);

        Video InsertVideo( Video objVideo);
        string UpdateVideo( int GradeID, int VideoId, VideoObj objVideo);
        Video DeleteVideo(int GradeID , int VideoId);

    }
}
