using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Cos.Services;
using Cos.Models.RichAndArticles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Cos.Controllers
{
    public class RichArticleController:Controller
    {
        private IHostingEnvironment _env;
        public RichArticleController(IHostingEnvironment env){
            _env=env;
        }
        //前台根据页面类型获取富文本中大图和介绍，参照原系统页面左下角图片
        public JsonResult GetRichList(string type){
            BaseResultModel<List<SimpleArticle>> result=new BaseResultModel<List<SimpleArticle>>();
            result=RichArticleService.GetFrontRichList(type);
            return Json(result);
        }
        //后台根据页面类型获取富文本中的 简短介绍
        public JsonResult GetRichArticleList(PaginationModel pageList){
            PaginationResultModel<SimpleArticle> result=new PaginationResultModel<SimpleArticle>();
            result=RichArticleService.GetRichList(pageList);
            return Json(result);
        }

        //添加富文本
        [HttpPost]
        public JsonResult AddRichArticle(SimpleArticle simpleArticle){
            BaseResultModel<SimpleArticle> result=new BaseResultModel<SimpleArticle>();
            result=RichArticleService.SetRichArticle(simpleArticle);
            return Json(result);
        }
        //用于修改富文本
        [HttpPost]
        public JsonResult UpdateRichArticle(SimpleArticle simpleArticle){
            BaseResultModel<SimpleArticle> result=new BaseResultModel<SimpleArticle>();
            result=RichArticleService.UpdateRichArticle(simpleArticle);
            return Json(result);
        }
            
        //用于上传多个图片
        [HttpPost]
        public  JsonResult AddPicList(List<IFormFile> files){
            var filelist = Request.Form.Files;
            long size = filelist.Sum(f => f.Length);
            string webRootPath = _env.WebRootPath;
            string contentRootPath = _env.ContentRootPath;
            foreach (var formFile in filelist)
            {
                if (formFile.Length > 0)
                {
                    //string fileExt = GetFileExt(formFile.FileName); //文件扩展名，不含“.”
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位

                    string url=Request.Host.Value;
                    //string requestPath="https://"+url+"/images/courses/"+fileName;
                   // string newFileName = System.Guid.NewGuid().ToString() + ".jpg"; //随机生成新的文件名
                    //var filePath = webRootPath +"/images/" + formFile.FileName;
                    var filePath="http://"+url+"/images/" +formFile.FileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                         formFile.CopyToAsync(stream);
                    }
                }
            }
            return Json(new { count = filelist.Count, size });
        }
    }
}