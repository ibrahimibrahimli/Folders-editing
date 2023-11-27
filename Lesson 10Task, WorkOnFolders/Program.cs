

namespace Lesson_10Task__WorkOnFolders
{
    internal class Program
    {

        const string  MyDirectory = @"C:\Users\Ibrahim\Downloads";
        static void Main(string[] args)
        {
            SerachInDirectory();
            DeleteEmptyDirectories();
        }

        static void SerachInDirectory()
        {

            var directory = new DirectoryInfo(MyDirectory);
           var files = directory.GetFiles();

            foreach (var file in files)
            {
                
               string FileExtension = file.Extension;

                string? folderName;

                switch(FileExtension)
                {
                    case ".ico":
                    case ".png":
                    case ".jpg":
                    case ".jpeg":
                        folderName = "MyPictures";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;
                    case ".pdf":
                    case ".doc":
                    case ".docx":
                        folderName = "MyDocuments";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;
                    case ".mp3":
                        folderName = "MyMusics";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;
                    case ".mp4":
                        folderName = "MyVideos";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;
                    case ".exe":
                        folderName = "mySetups";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;

                    default:
                        folderName = "General";
                        CreateFolder(folderName);
                        MoveDestination(file, folderName);
                        break;
                    


                }
            }
        }

       

        static void CreateFolder(string FolderName)
        {
            
            
            string NewDirectory = Path.Combine(MyDirectory, FolderName);
            bool result = Directory.Exists(NewDirectory);
           
            if(!result)
            {
               Directory.CreateDirectory(NewDirectory);
            }
            
            
        }
        static void MoveDestination(FileInfo file, string folderName)
        {
            var destination = Path.Combine(MyDirectory, folderName, file.Name);
            file.MoveTo(destination);

        }

        static void DeleteEmptyDirectories()
        {
           var directories =  Directory.GetDirectories(MyDirectory);
            foreach (var directory in directories)
            {
                if(Directory.GetFiles(directory).Length == 0)
                {
                    Directory.Delete(directory, true);
                }
            }
        }


    }
}