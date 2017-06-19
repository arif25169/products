using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Web;

namespace ProductsDomain.Exceptions
{
    public class DuplicateEntryException : Exception
    {
        private readonly string _fieldName;

        public string FieldName { get
            {
                return _fieldName;
            }
        }

        public override string Message {
            get
            {
                string displayName = Regex.Replace(FieldName, "(\\B[A-Z])", " $1");
                return String.Format("{0} must be unique", displayName);
            }
        }

        public DuplicateEntryException(string fieldName)
        {
            _fieldName = fieldName;
        }
    }
}