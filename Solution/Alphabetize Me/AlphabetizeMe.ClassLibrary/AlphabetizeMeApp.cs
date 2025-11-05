using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlphabetizeMe.ClassLibrary
{
    public class AlphabetizeMeApp
    {
        string _inputStream = null;
        List<string> _temporaryList = null;
        List<string> _originalList = null;
        List<string> _alphabatisedList = null;
        string _newLineDesignation = "\r\n";

        public List<string> ConvertStreamToList(string stream, string dataSeperator)
        {
            _inputStream = stream;

            if (_inputStream.Contains(dataSeperator))
            {
                if (!_inputStream.Contains(","))
                {
                    stream = stream.Replace(dataSeperator, ",");
                }

                string[] stringArray = stream.Split(',');
                return _originalList = stringArray.ToList();
            }

            return _originalList;
        }

        public List<string> ConvertReturnNewLineToList(string stream)
        {
            _inputStream = stream;

            if (_inputStream.Contains("\r\n"))
            {
                stream = stream.Replace("\r\n", ",");
                string[] stringArray = stream.Split(',');
                return _originalList = stringArray.ToList();
            }

            return _originalList;
        }

        public List<string> ConvertCsvToList(string stream)
        {
            _inputStream = stream;

            if (_inputStream.Contains(","))
            {
                string[] stringArray = stream.Split(',');
                return _originalList = stringArray.ToList();
            }

            return _originalList;
        }

        public List<string> ConvertTsvToList(string stream)
        {
            _inputStream = stream;

            if (_inputStream.Contains("\t"))
            {
                stream = stream.Replace("\t", ",");
                string[] stringArray = stream.Split(',');
                return _originalList = stringArray.ToList();
            }

            return _originalList;
        }

        public List<string> AlphabetizeMe(List<string> list)
        {
            _originalList = list;
            _originalList.Sort();
            _alphabatisedList = _originalList;
            _originalList = list;

            return _alphabatisedList;
        }

        public bool CheckUserInput(string stream)
        {
            _inputStream = stream;

            if (string.IsNullOrEmpty(_inputStream)) { return false; }
            if (_inputStream.Contains(",")) { return false; }
            if (_inputStream.Contains("\t")) { return false; }
            if (_inputStream.Contains("\r\n")) { return true; }
            if (_inputStream.Contains("%0D%0A")) { return true; }

            if (_inputStream.Contains(_newLineDesignation)) { return true; }

            return false;
        }
    }
}
