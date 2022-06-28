using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace EvaluacijaOcena
{
    /// <summary>Klasa koja sluzi za serijalizaciju/deserijalizaciju XML-a.</summary>
    /// <typeparam name="T">Parametar templejta koga treba serijalizovati/deserijalizovati.</typeparam>
    public static class XMLDeserialize<T> where T : IXMLDeserializable, new()
    {
        /// <summary>Funkcija koja prepoznaje da li je prosledjeni string XML ili putanja do fajla.</summary>
        /// <remarks>Ova funkcija koristi Factory projektni obrazac.</remarks>
        /// <param name="s4Deserialize">String koji moze biti XML ili putanja do fajla gde se nalazi XML.</param>
        /// <returns>Objekat koji je dobijen deserijalizacijom parametra.</returns>
        public static T readFromXML(string s4Deserialize)
        {
            TextReader tr;
            // Provera da li postoji fajl na datoj putanji.
            if(File.Exists(s4Deserialize)) {
                tr = new StreamReader(s4Deserialize);
            }
            // Provera da li je string XML.
            else if(s4Deserialize.TrimStart().StartsWith("<")) {
                tr = new StringReader(s4Deserialize);
            }
            // NullObject sablon.
            else {
                tr = new StringReader("");
            }
            return readFromTextReader(tr);
        }

        /// <summary>Parsovanje XML-a.</summary>
        /// <remarks>
        /// Ova funkcija koristi Adapter projektni obrazac. Adaptira dati XML za deserijalizaciju XmlSerializer -om.
        /// </remarks>
        /// <param name="reader">TextReader iz koga se cita i parsuje XML.</param>
        /// <returns>Objekat koji je dobijen parsovanjem XML-a.</returns>
        private static T readFromTextReader(TextReader reader)
        {
            string sFileText = reader.ReadToEnd();

            T obj4Deserilize = new T();

            #region Ciscenje roditeljskih tagova iz XML -a da bi se doslo do liste objekata koje treba deserijalizovati.
            string sTagName = obj4Deserilize.TagName;
            int nStartInd = sFileText.IndexOf(String.Format("<{0}>", sTagName));
            int nLastInd = sFileText.LastIndexOf(String.Format("</{0}>", sTagName));
            if(nStartInd < 0 || nLastInd < 0 || nLastInd - nStartInd + sTagName.Length + 3 < 0) {
                return new T();
            }
            sFileText = sFileText.Substring(nStartInd, nLastInd - nStartInd + sTagName.Length + 3);
            #endregion

            /// Formatiranje XML-a da sadrzi root tag i list tag.
            /// <example>
            ///     <Root>
            ///          <List>
            ///              Korisni sadrzaj XML -a
            ///          </List>
            ///     </Root>
            /// </example>
            sFileText = String.Format("<{0}>\r\n<{1}>\r\n{2}\r\n</{1}>\r\n</{0}>",
                Const.S_ROOT_NAME, Const.S_LIST_NAME, sFileText);
                     
            try {
                // Deserijalizacija XML-a.
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using(reader = new StringReader(sFileText)) {
                    obj4Deserilize = (T)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException) {
                // Ukoliko nije moguce deserijalizovati XML vraca se prazan objekat.
                obj4Deserilize = new T();
            }
            return obj4Deserilize;
        }

        /// <summary>Serijalizacija objekta u XML.</summary>
        /// <param name="obj">Objekat koji treba serijalizovati.</param>
        /// <param name="sFilePath">Putanja fajla gde treba sacuvati XML.</param>
        public static void save2XML(T obj, string sFilePath)
        {
            // Serijalizacija objekta
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using StringWriter strw = new StringWriter();
            serializer.Serialize(strw, obj);

            string sFileText = strw.ToString();

            #region Ceo region se moze zakomentarisati, ali je samo zbog lepseg ispisa u XML-u.
            string sHeader = "";
            int nIndexHeader = sFileText.IndexOf("<?xml");
            if(nIndexHeader >= 0) {
                sHeader = sFileText.Substring(nIndexHeader, sFileText.IndexOf("?>") + 2 - nIndexHeader);
                sFileText = sFileText.Substring(sFileText.IndexOf("?>") + 2);
            }
            if(sFileText.Contains(obj.TagName)) {
                sFileText = sHeader + "\r\n" + sFileText.Substring(sFileText.IndexOf(obj.TagName) - 1);
                sFileText = sFileText.Remove(sFileText.LastIndexOf(obj.TagName) + obj.TagName.Length + 1);
            }
            else {
                sFileText = sHeader;
            }

            sFileText = sFileText.Replace("\r\n    ", "\r\n");
            #endregion

            try {
                // Upis XML stringa u fajl.
                File.WriteAllText(sFilePath, sFileText);
            }
            catch (IOException) {
                ;
            }
        }
    }
}
