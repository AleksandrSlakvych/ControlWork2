using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork2
{
    abstract class File
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }

        public File() { }

        public override string ToString()
        {
            string result = "";
            result += $"\t{Name}.{Extension}\n\t\tExtention: {Extension}\n\t\tSize: {Size}\n\t\t";
            return result;
        }
        public abstract void Pars(string newInfo);
    }

    class TextFile : File
    {
        public string Content { get; set; }

        public TextFile() { }

        public override void Pars(string result)
        {
            string[] fileInfo = result.Split(new char[] { ':', '.', ';', '(', ')' });
            Name = fileInfo[1];
            Extension = fileInfo[2];
            Size = fileInfo[3];
            Content = fileInfo[5];
        }

        public override string ToString()
        {
            string result = "";
            result += base.ToString() + $"Content: {Content}";
            return result;
        }
    }

    class MovieFile : File
    {
        public string Lenght { get; set; }
        public string Resolution { get; set; }


        public MovieFile() { }

        public override void Pars(string result)
        {
            string[] fileInfo = result.Split(new char[] { ':', '.', ';', '(', ')' });
            Name = fileInfo[1];
            Name += fileInfo[2];
            Extension = fileInfo[3];
            Size = fileInfo[4];
            Resolution = fileInfo[6];
            Lenght = fileInfo[7];
        }

        public override string ToString()
        {
            return base.ToString() + $"Resolution: {Resolution}\n\t\tLenght: {Lenght}";
        }
    }

    class ImageFile : File
    {
        public string Resolution { get; set; }

        public ImageFile() { }

        public override void Pars(string result)
        {
            string[] fileInfo = result.Split(new char[] { ':', '.', ';', '(', ')' });
            Name = fileInfo[1];
            Extension = fileInfo[2];
            Size = fileInfo[3];
            Resolution = fileInfo[5];
        }

        public override string ToString()
        {
            return base.ToString() + $"Resolution: {Resolution}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"Text:file.txt(6B);Some string content
Image:img.bmp(19MB);1920x1080
Text:data.txt(12B);Another string
Text:data1.txt(7B);Yet another string
Movie:logan.2017.mkv(19GB);1920x1080;2h12m";

            var strToFile = s.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            List<File> files = new List<File>();

            foreach (var item in strToFile)
            {
                if (item.StartsWith("Text:"))
                {
                    TextFile f = new TextFile();
                    f.Pars(item);
                    files.Add(f);
                }
                if (item.StartsWith("Image:"))
                {
                    ImageFile f = new ImageFile();
                    f.Pars(item);
                    files.Add(f);
                }

                if (item.StartsWith("Movie:"))
                {
                    MovieFile f = new MovieFile();
                    f.Pars(item);
                    files.Add(f);
                }
            }
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
