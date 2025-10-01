using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    public class DagboksPost
    {
        public DateTime Datum { get; set; }
        public string Titel { get; set; }
        public string Text { get; set; }

        public DagboksPost(DateTime datum, string titel, string text)
        {
            Datum = datum;
            Titel = titel;
            Text = text;
        }
    }
}