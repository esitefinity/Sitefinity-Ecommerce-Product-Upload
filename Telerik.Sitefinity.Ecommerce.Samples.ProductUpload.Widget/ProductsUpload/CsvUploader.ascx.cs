// Sitefinity Ecommerce Import products from CSV file.
// make sure you have created a folder called upload in the root of your web site
// you must also be logged-in to the Sitefinity backend for this product importer to work. 
// You must also have CSVHelper package installed.  Install Nuget http://nuget.codeplex.com into Visual Studio as an extension

using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Samples.Ecommerce.ProductUpload.Util;
using Telerik.Sitefinity.Samples.Ecommerce.ProductUpload;

namespace SitefinityWebApp.ProductsUpload
{
    public partial class CsvUploader : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadCsvFileAndTriggerProductImport();
        }
        
        private void UploadCsvFileAndTriggerProductImport()
        {
            string filePath = UploadFileAndGetFilePath();

            UploadManager uploadManager = new UploadManager(new UploadConfig { NumberOfColumns = 11 });

            uploadManager.ImportProductsFromCsvFile(filePath);
        }
  
        private string UploadFileAndGetFilePath()
        {
            string folderPath = Server.MapPath("~/Upload");

            IoHelper.ValidateFolderExsistence(folderPath);

            string filePath = folderPath + @"\" + FileUpload1.FileName.ToString();

            IoHelper.ValidateFileExsistence(filePath);

            FileUpload1.SaveAs(filePath);

            return filePath;
        }

    }
}