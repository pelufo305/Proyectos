using System;
using System.Collections.Generic;
using Bussines.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;


namespace Bussines.Process
{
    public class ProcessBiz
    {
        public string Process(string strServerPath)
        {

            //Se obtienen los archivos de la carpeta que se encuentra en el API
            DirectoryInfo dInfo = new DirectoryInfo(strServerPath);
            List<Classification> oListItem = new List<Classification>();
            string strMessage = string.Empty;
            string jsonData = string.Empty;

            //recorre los archivos
            foreach (FileInfo file in dInfo.GetFiles())
            {
                if (file.FullName.Contains("EQUNOSBOVINOS"))
                {
                    try
                    {
                        foreach (string line in File.ReadLines(String.Format(@"{0}", file.FullName), Encoding.UTF8))
                        {
                            oListItem.Add(GetItemModel(line));
                        }
                    }
                    catch (IOException ex)
                    {
                        strMessage = String.IsNullOrEmpty(ex.Message.ToString()) ? ex.InnerException.Message.ToString() : ex.Message.ToString();
                        oListItem.Add(GetItemModel(strMessage));
                    }


                }
            }


            FlatFile oFlatFile = new FlatFile();
            oFlatFile.Items = oListItem;

            ///se serializa el modelo a formato JSON
            JavaScriptSerializer jss = new JavaScriptSerializer()
            {
                MaxJsonLength = int.MaxValue
            };

            jsonData = jss.Serialize(oFlatFile);

            return jsonData;


        }

        //metodo que los convierte en el modelo que se necesita
        private Classification GetItemModel(string line)
        {
            Classification oClassificationModel = new Classification()
            {
                Type = line.Substring(0,1),
                Value = line.ToString()
            };

            return oClassificationModel;
        }


    }
}
