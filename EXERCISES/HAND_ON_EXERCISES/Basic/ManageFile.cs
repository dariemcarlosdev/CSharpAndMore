using System;
using System.Text;
using System.Buffers.Text;
using System.IO;

 namespace ExercisesLearning
{
    public class ManageFile
    {
    /*Write a C# program to create, write and find the size of a specified file in bytes.*/
    public void FileCWS()
    {

      var fileName = @"d:\Temp\FileCSharpTest.txt";
      var fileInfo = new FileInfo(fileName);
      try
      {
        //check if file exist, if so, delete it.
        if (File.Exists(fileName))
        {
          File.Delete(fileName);
        }

        //create new file
        using (var fs = File.Create(fileName))
        {
          //Add some text to file
          var text = new UTF8Encoding(true).GetBytes(
              @"fsdfffffffffffdasdasdasdssssssddddddddddddddddddddddddd
                ddddddddddddddddddddddddddddddddddddddddddddddddsssssssssss
                sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
                sssssssssssssssssssssssssssssasdddddddddddddddddddddddddddddddd
                dddddddddddddddddddasdasdasddaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
                For really long strings, I'd store it in XML (or a resource). For occasions
                 where it makes sense to have it in the code, I use the multiline string concatenation 
                 with the + operator. The only place I can think of where I do this, though, is in my unit
                  tests for code that reads and parses XML where I'm actually trying to avoid using an XML
                   file for testing. Since it's a unit test I almost always want to have the string right there
                    to refer to as well. In those cases I might segregate them all into a #region directive so I
                     can show/hide it as neededfsdfffffffffffdasdasdasdssssssddddddddddddddddddddddddd
                ddddddddddddddddddddddddddddddddddddddddddddddddsssssssssss
                sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
                sssssssssssssssssssssssssssssasdddddddddddddddddddddddddddddddd
                dddddddddddddddddddasdasdasddaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd
                For really long strings, I'd store it in XML (or a resource). For occasions
                 where it makes sense to have it in the code, I use the multiline string concatenation 
                 with the + operator. The only place I can think of where I do this, though, is in my unit
                  tests for code that reads and parses XML where I'm actually trying to avoid using an XML
                   file for testing. Since it's a unit test I almost always want to have the string right there
                    to refer to as well. In those cases I might segregate them all into a #region directive so I
                     can show/hide it as needed
                "
              );
          fs.Write(text, 0, text.Length);
          // Get File Name  
          string justFileName = fileInfo.Name;
          Console.WriteLine("File Name: {0}", justFileName);
          // Get file name with full path   
          string fullFileName = fileInfo.FullName;
          Console.WriteLine("File Name: {0}", fullFileName);
          // Get file extension   
          string extn = fileInfo.Extension;
          Console.WriteLine("File Extension: {0}", extn);
          // Get directory name   
          string directoryName = fileInfo.DirectoryName;
          Console.WriteLine("Directory Name: {0}", directoryName);
          // Get file size  
          long size = fileInfo.Length;
          Console.WriteLine("File Size in Bytes: {0}", size);
        }
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
    
