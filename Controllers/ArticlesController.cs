using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Cos.Services;
using Cos.Models.RichAndArticles;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Cos.Controllers
{
    public class ArticlesController:Controller
    {
         private IHostingEnvironment _env;
        public ArticlesController(IHostingEnvironment env){
            _env=env;
        }
        //获取首页文章列表
        public JsonResult GetArticlesList(){
            BaseResultModel<List<Article>> alist=new BaseResultModel<List<Article>>();
            alist=RichArticleService.GetArticleList();
            return Json(alist);
        }
        //用于添加文章
        [HttpPost]
        public JsonResult AddArticle(Article a)
        {
           BaseResultModel<Article> article=RichArticleService.SetArticle(a);
           return Json(article);
        }
        //用于修改文章
        [HttpPost]
        public JsonResult UpdateArticle(Article a)
        {
           BaseResultModel<Article> article=RichArticleService.UpdateArticle(a);
           return Json(article);
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
                
                    //string newFileName = System.Guid.NewGuid().ToString() + ".jpg"; //随机生成新的文件名
                    var filePath = webRootPath +"/images/" +formFile.FileName;
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