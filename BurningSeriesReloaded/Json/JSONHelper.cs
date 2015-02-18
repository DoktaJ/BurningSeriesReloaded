using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace BurningSeriesReloaded
{
    public class JSONHelper
    {
        public static T FromString<T>(string input)
        {
         
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Es ist ein Fehler aufgetreten.");

                }

                dynamic jsonSerializer = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(input)))
                {
                       try
            {
                    return (T)jsonSerializer.ReadObject(ms);
            }
                       catch (Exception e)
                       {
                           MessageBox.Show("Es ist ein Fehler aufgetreten: " + Environment.NewLine + e.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return (T) jsonSerializer.ReadObject(ms);
                       }
                }
         
           
        }
    }
}
