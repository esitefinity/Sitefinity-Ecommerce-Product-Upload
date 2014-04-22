// Sitefinity Ecommerce Import products from CSV file.
// make sure you have created a folder called upload in the root of your web site
// you must also be logged-in to the Sitefinity backend for this product importer to work. 
// You must also have CSVHelper package installed.  Install Nuget http://nuget.codeplex.com into Visual Studio as an extension
// then select Search online, and search for CSV Helper.  Install the Add-on CSVHelper into Visual Studio and build project.
// You can read more about CSVHelper here http://nuget.org/packages/CsvHelper
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Samples.Ecommerce.ProductUpload.Util;
using Telerik.Sitefinity.Samples.Ecommerce.ProductUpload;
using Telerik.Sitefinity.Samples.Ecommerce.ProductUpload.Model;

namespace SitefinityWebApp.ProductsUpload
{
    public partial class CsvUploader : UserControl
    {
        public void btnVariationUpload_Click(object sender, EventArgs e)
        {
            UploadCsvFileAndTriggerProductVariationImport();
        }

        private void UploadCsvFileAndTriggerProductVariationImport()
        {
            string filePath = UploadFileAndGetFilePath(FileUpload2);

            UploadManager uploadManager = new UploadManager(new UploadConfig());

            ImportStatistic statistic =  uploadManager.ImportProductsVariationsFromCsvFile(filePath);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadCsvFileAndTriggerProductImport();
        }
        
        private void UploadCsvFileAndTriggerProductImport()
        {
            string filePath = UploadFileAndGetFilePath(FileUpload1);

            UploadManager uploadManager = new UploadManager(new UploadConfig());

            uploadManager.ImportProductsFromCsvFile(filePath);
        }
  
        private string UploadFileAndGetFilePath(FileUpload fileUpload)
        {
            string folderPath = Server.MapPath("~/Upload");

            IoHelper.ValidateFolderExsistence(folderPath);

            string filePath = folderPath + @"\" + fileUpload.FileName.ToString();

            IoHelper.ValidateFileExsistence(filePath);

            fileUpload.SaveAs(filePath);

            return filePath;
        }

    }
}