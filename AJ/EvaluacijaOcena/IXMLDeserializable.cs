using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EvaluacijaOcena
{
    public interface IXMLDeserializable
    {
        /// <summary>Ime taga u kom se nalazi neki objekat nad kojim se vrsi serijalizacija/deserijalizacija.</summary>
        [XmlIgnore]
        public abstract string TagName { get; }
    }
}
