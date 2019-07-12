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
namespace Cos.Controllers
{
    public class ArticlesController:Controller
    {
        //获取首页文章列表
        public JsonResult GetArticlesList(string type){
            BaseResultModel<List<Article>> alist=new BaseResultModel<List<Article>>();
            alist=RichArticleService.GetArticleList(type);
            return Json(alist);
        }
        //获取富文本，该部分富文本包括大图和说明
        public JsonResult GetRich(string type){
            BaseResultModel<SimpleArticle> sa=RichArticleService.GetRichArticle(type);
            return Json(sa);
        }
        //获取富文本中 介绍列表
        public  JsonResult GetRichList(string type){
            BaseResultModel<List<SimpleArticle>> salist=RichArticleService.GetRichList(type);
            return Json(salist);
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
        //用于添加富文本
        [HttpPost]
        public JsonResult AddRichArticle(SimpleArticle a)
        {
           BaseResultModel<SimpleArticle> article=RichArticleService.SetRichArticle(a);
           return Json(article);
        }
        //用于修改富文本
        [HttpPost]
        public JsonResult UpdateRichArticle(SimpleArticle a)
        {
           BaseResultModel<SimpleArticle> article=RichArticleService.UpdateRichArticle(a);
           return Json(article);
        }
    }
}