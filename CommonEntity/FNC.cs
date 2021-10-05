using Encryption;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Xml;



namespace CommonEntity
{
    public static class FNC
    {
        public static dynamic Conv(Object objVal, enDataType dataType)
        {
            String val = "0";
            if (objVal != null)
            {
                val = objVal.ToString();
            }
            if (objVal == DBNull.Value && dataType == enDataType.DATETIME)
            {
                return null;
            }
            dynamic result = 0;
            if (val.Length.Equals(0))
            {
                val = "0";
            }
            if (dataType == enDataType.DECIMAL)
            {
                result = Convert.ToDecimal(val);
            }
            if (dataType == enDataType.BOOL)
            {
                bool iVal;
                result = bool.TryParse(val.ToString(), out iVal);
                result = iVal;
            }
            if (dataType == enDataType.INT)
            {

                int iVal;
                Int32.TryParse(val.ToString().Replace(".00", "").ToString(), out iVal);
                result = iVal;
            }
            if (dataType == enDataType.DATETIME)
            {
                result = Convert.ToDateTime(val);
            }
            return result;
        }
        public static String GetDateInMMDDYYY(string date)
        {
            //	return date.Length < 9 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy",CultureInfo.InvariantCulture);
            return date.Length < 8 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
        public static String GetDateInMMDDYYYWindow(string date)
        {
            //	return date.Length < 9 ? "" : DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy",CultureInfo.InvariantCulture);
            return Convert.ToDateTime(date).ToString();
        }
        public static String EncryptData(string pinData)
        {
            clsTripleDES objEncrypt = new clsTripleDES();
            return objEncrypt.Encrypt(pinData, clsModule.Fk, clsModule.Sk);
        }
        public static String DecryptData(string pinData)
        {
            clsTripleDES objEncrypt = new clsTripleDES();
            return objEncrypt.Decrypt(pinData, clsModule.Fk, clsModule.Sk);
        }
        public static String CUrrentDateTime
        {
            get
            {
                return Convert.ToDateTime(DateTime.Now.ToString()).ToString("dd MM, yy - hh:mm:ss ttttt");
            }
        }
        public static DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                // Load the XmlTextReader from th   e stream
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader, XmlReadMode.InferSchema);
                if (xmlDS.Tables.Count > 1)
                {
                    if (xmlDS.Tables[1].Rows.Count > 0)
                    {
                        xmlDS = ConvertXMLToDataSet(xmlDS.Tables[1].Rows[0][0].ToString());

                    }
                }
                return xmlDS;
            }
            catch
            {
                return null;
            }
            finally
            {
                if ((reader != null))
                {
                    reader.Close();
                }
            }
        }
        public static String FileExtentionGet(String sAttchmentType)
        {

            var FilieExtention = "pictures.png";
            if (sAttchmentType == null)
                return FilieExtention;
            if (sAttchmentType .Contains("doc")) { FilieExtention = "word.png"; }
            if (sAttchmentType .Contains("xl")) { FilieExtention = "excel.png"; }
            if (sAttchmentType .Contains("pdf")) { FilieExtention = "file_pdf.png"; }
            return FilieExtention;
        }
    }
}
