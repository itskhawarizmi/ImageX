using Entities.Models;
using Extensions;
using Extensions.DataModels;
using Files;
using NReco.ImageGenerator;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace api_imagex_converter.Controllers
{
    [RoutePrefix("api/v1/imagex")]
    public class ImagexController : ApiController
    {
        #region Private Members

        /// <summary>
        /// A single instance from <see cref="IFileManager"/>.
        /// </summary>
        private readonly IFileManager fileManager;

        #endregion

        #region Constructor

        public ImagexController() { }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fileManager">A single instance parameter from <see cref="IFileManager"/></param>
        public ImagexController(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        #endregion


        [HttpGet]
        [Route("HtmlToJpgConverter")]
        public async Task<HttpResponseMessage> HtmlToJpgConverterAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Jpeg);

                imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Jpeg);

                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-jpg", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);

                return Response;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("HtmlToPngConverter")]
        public async Task<HttpResponseMessage> HtmlToPngConverterAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Png);

                imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Png);

                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-png", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);

                return Response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("HtmlToBmpConverter")]
        public async Task<HttpResponseMessage> HtmlToBmpConverterAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Bmp);

                imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Bmp);

                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/bmp");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-bmp", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);

                return Response;

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("HtmlToJpg")]
        public async Task<HttpResponseMessage> HtmlToJpgAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Jpeg);


                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                Response.Content.Headers.Add("Content-Disposition", "attachment; filename=imagex.jpg");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-jpg", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);

                return Response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("HtmlToPng")]
        public async Task<HttpResponseMessage> HtmlToPngAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Png);

                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                Response.Content.Headers.Add("Content-Disposition", "attachment; filename=imagex.png");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-png", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);

                return Response;

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }

        }

        [HttpPost]
        [Route("HtmlToBmp")]
        public async Task<HttpResponseMessage> HtmlToBmpAsync([FromBody] HtmlMetaObject htmlMetaObject)
        {
            try
            {
                HtmlToImageConverter imageX = new HtmlToImageConverter
                {
                    ToolPath = System.Web.HttpContext.Current.Server.MapPath(@"/3rdPartyTool"),
                    WkHtmlToImageExeName = "Client.exe"
                };

                byte[] imageByteObject = imageX.GenerateImage(htmlMetaObject.HtmlContent, ImageFormat.Bmp);

                HttpResponseMessage Response = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(imageByteObject)
                };

                Response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/bmp");
                Response.Content.Headers.Add("Content-Disposition", "attachment; filename=imagex.bmp");

                string rawImageObject = imageByteObject.ToStringBuilder();

                await fileManager.WriteImageByteObjectToFileAsync("imagex-bmp", FileFormat.TXT, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), rawImageObject);


                return Response;
            }
            catch(Exception ex)
            {
                throw new ArgumentException($"Error Message: {ex.Message}");
            }

        }

    }
}
