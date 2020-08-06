﻿using System.IO;
using System.Text;

namespace NetExercise.BLL.Utils
{
    public sealed class EncodedStringWriter : StringWriter
    {
        public override Encoding Encoding { get; }

        public EncodedStringWriter(Encoding encoding)
        {
            Encoding = encoding;
        }
    }
}
