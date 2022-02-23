using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace KeysAny
{
    class Program
    {
        static void Main(string[] args)
        {

            var files = CreateFileOfUiCollectionForTest();
            var documents = CreateDocumentPhotoCollectionForTest();

            Console.WriteLine("file names...............:");
            files.ForEach(x=>Console.WriteLine(x.FileName));

            Console.WriteLine("--------------------------");

            Console.WriteLine("documents urls...............:");
            documents.ForEach(x => Console.WriteLine(x.Url));

           
            Console.WriteLine();
            Console.WriteLine("splited names from url...:");
            Console.WriteLine("--------------------------");
            foreach (var item in documents)
            {
                var element = item.Url?.Split('/').Last();

                Console.WriteLine(element);
            }

            var keys = files.Select(x => new { x?.FileName });
            documents.RemoveAll(x => keys.Any(k => k.FileName == x.Url?.Split('/').Last()));

            Console.WriteLine();
            Console.WriteLine("unique url based on file name and document name...:");
            Console.WriteLine("--------------------------");
            documents.ForEach(x=>Console.WriteLine(x.Url));

            files = null;
            documents = null;

            //---------------------------


            var files1 = CreateFileOfUiCollectionForTest();
            var documents1 = CreateDocumentPhotoCollectionForTest();

            var docKeys = documents1.Select(x => new { x.Url });

            files1.RemoveAll(x => docKeys.Any(k => k.Url?.Split('/').Last() == x.FileName));

            Console.WriteLine();
            Console.WriteLine("unique file name based on document url...:");
            Console.WriteLine("--------------------------");
            files1.ForEach(x => Console.WriteLine(x.FileName));

        }
        
        public static List<FileOfUi> CreateFileOfUiCollectionForTest()
        {
            var file1 = new FileOfUi { FileName = "anatoli1" };
            var file2 = new FileOfUi { FileName = "anatoli21" };
            var file3 = new FileOfUi { FileName = "anatoli3" };
            var file4 = new FileOfUi { FileName = "anatoli42" };
            return new List<FileOfUi> { file1, file2, file3, file4 };
        }

        public static List<DocumentPhoto> CreateDocumentPhotoCollectionForTest()
        {
            var doc1 = new DocumentPhoto { DocumentType = "passport1", Url = "localhost:5000/cdn/anatoli1" };
            var doc2 = new DocumentPhoto { DocumentType = "passport2", Url = "localhost:5000/cdn/anatoli2" };
            var doc3 = new DocumentPhoto { DocumentType = "passport3", Url = "localhost:5000/cdn/anatoli3" };
            var doc4 = new DocumentPhoto { DocumentType = "passport4", Url = "localhost:5000/cdn/anatoli4" };
            return new List<DocumentPhoto> { doc1, doc2, doc3, doc4 };
        }
    }

    public class DocumentPhoto
    {
        public string DocumentType { get; set; }
        public string Url { get; set; }
    }

    public class FileOfUi
    {
        public string FileName { get; set; }
    }
}
