using System;
namespace Internship
{
    public interface IFileChooser
    {
        bool FindFile(string fileName);
    }
    public interface IFileLoader
    {
        void LoadFile(string fileName);
    }
    public class FileChooser : IFileChooser
    {
        public bool FindFile(string fileName)
        {
            if (fileName == "NewFile.docx")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class FileLoader : IFileLoader
    {
        public void LoadFile(string fileName)
        {
            Console.WriteLine("\nLoading " + fileName + "\n");
        }
    }
    public class WordFacade
    {
        private readonly IFileChooser _fileChooser;
        private readonly IFileLoader _fileLoader;
        public WordFacade(IFileChooser fileChooser, IFileLoader fileLoader)
        {
            _fileChooser = fileChooser;
            _fileLoader = fileLoader;
        }
        public bool OpenFile(string fileName)
        {
            if (_fileChooser.FindFile(fileName))
            {
                Console.WriteLine("\nFile Requested: " + fileName + "\n");
                _fileLoader.LoadFile(fileName);
                return true;
            }
            else
            {
                Console.WriteLine("\nCould not open file: " + fileName + "\n");
                return false;
            }
        }
    }
    public class FacadeDemo
    {
        public void designPatternDemo()
        {
            FileChooser fileChooser = new FileChooser();
            FileLoader fileLoader = new FileLoader();
            WordFacade word = new WordFacade(fileChooser, fileLoader);

            string fileName = "NewFile.docx";
            word.OpenFile(fileName);
        }
    }
}