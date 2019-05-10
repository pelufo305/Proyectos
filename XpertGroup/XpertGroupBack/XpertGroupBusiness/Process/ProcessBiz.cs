using System;
using System.Collections.Generic;
using XpertGroupBusiness.Models;
using System.IO;

using System.Text;


namespace XpertGroupBusiness.Process
{
    public class ProcessBiz
    {
        public void Process(string strServerPath)
        {

            //Se obtienen los archivos de la carpeta que se encuentra en el API
            DirectoryInfo dInfo = new DirectoryInfo(strServerPath);
            List<Classification> oListItem = new List<Classification>();
            string strMessage = string.Empty;


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

            //se serializa el modelo a formato JSON
            //JavaScriptSerializer jss = new JavaScriptSerializer()
            //{
            //    MaxJsonLength = int.MaxValue
            //};




        }


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
