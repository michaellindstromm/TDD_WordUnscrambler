using System;
using System.IO;

namespace Unscrambler.CLI.Workers
{
    class FileReader
    {
        public string[] Read(string filename)
        {

            string[] fileContent;

            try
            {
                fileContent = File.ReadAllLines(filename);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return fileContent;
        }
    }
}