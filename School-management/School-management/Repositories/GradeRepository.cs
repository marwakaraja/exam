using Microsoft.EntityFrameworkCore;
using School_management.DataAccess;
using School_management.DTO;
using School_management.Interfaces;
using schoolManagement.Models;

namespace School_management.Repositories
{
    public class GradeRepository : IGradeRepository
    {

        private readonly MyAppContext context;
        private readonly IFileRepository fileRepository;

        public GradeRepository(MyAppContext context , IFileRepository fileRepository)
        {
            this.context = context;
            this.fileRepository = fileRepository;
        }

        public Grade DeleteGrade(int GradeID)
        {
            var Grade = context.Courses
                .Find(GradeID);
            if (Grade == null)
            {
                return null;
            }

            context.Courses.Remove(Grade);
            context.SaveChanges();

            return Grade;
        }

        public Video DeleteVideo(int GradeID, int VideoId)
        {

            var video = context.Videos.Where(v=>v.GradeId== GradeID && v.VideoId== VideoId).FirstOrDefault();

            if (video == null)
            {
                return null;
            }

            context.Videos.Remove(video);
            context.SaveChanges();

            return video;

        }

        public Grade GetGrade(int ID)
        {

            var Grade = context.Courses.Include(g => g.Videos).Where(g => g.GradeId== ID).FirstOrDefault();
            if (Grade == null)
            { return null; }
            return Grade;
        }

        public IList<Grade> GetGrades()
        {
            return context.Courses.Include(g => g.Videos).ToList();
        }

        public IList<Video> GetVideos(int GradeID)
        {
             return  context.Videos.Where(v => v.GradeId == GradeID ).ToList();
            
            
        }

        public Grade InsertGrade(Grade objGarde)
        {
            context.Courses.Add(objGarde);
            context.SaveChanges();

            return (objGarde);
        }

        public Video InsertVideo( Video objVideo)
        {
            context.Videos.Add(objVideo);
            context.SaveChanges();

            return (objVideo);
        }

        public Video InsertVideo(int GradeID, Grade objVideo)
        {
            throw new NotImplementedException();
        }

        public Grade UpdateGrade(int GradeId, Grade objGrade)
        {

            var grade = context.Courses
               .Find(GradeId);
            if (grade == null)
            {
                return null;
            }

            grade.Name= objGrade.Name;
            grade.Description= objGrade.Description;

            context.Courses.Update(grade);
            context.SaveChanges();
            return grade;



        }

       

        Video IGradeRepository.GetVideo(int GradeID, int VideoId)
        {
            var video = context.Videos.Where(v => v.GradeId == GradeID && v.VideoId == VideoId).FirstOrDefault();
            if (video == null)
                return null;
            return video;
        }


        string IGradeRepository.UpdateVideo(int GradeID, int VideoId, VideoObj video)
        {
            var currentvideo = context.Videos.Where(v => v.GradeId == GradeID && v.VideoId == VideoId).FirstOrDefault();
            
            if (currentvideo == null) return null;

            fileRepository.DeleteFile(currentvideo.VideoUrl);


            var filename = fileRepository.SaveFile(video.VideoFile);

            
            currentvideo.VideoTitle = video.VideoTitle;
            currentvideo.VideoUrl = filename;
            context.SaveChanges();
            
            return filename;
        }
    }
}
