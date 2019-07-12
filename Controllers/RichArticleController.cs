using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Cos.Models.RichAndArticles;
using Cos.Services;
using System.ComponentModel.DataAnnotations;
namespace Cos.Controllers
{
    public class RichArticleController:Controller
    {
        //根据页面类型获取文章列表
        public  JsonResult GetArticleList(string type){
            BaseResultModel<List<Article>> result=new BaseResultModel<List<Article>>();
            result=RichArticleService.GetArticleList(type);
            return Json(result);
        }

        //根据页面类型获取富文本中大图和介绍，参照原系统页面左下角图片
        public JsonResult GetRichArticle(string type){
            BaseResultModel<SimpleArticle> result=new BaseResultModel<SimpleArticle>();
            result=RichArticleService.GetRichArticle(type);
            return Json(result);
        }
        //根据页面类型获取富文本中的 简短介绍
        public JsonResult GetRichArticleList(string type){
            BaseResultModel<List<SimpleArticle>> result=new BaseResultModel<List<SimpleArticle>>();
            result=RichArticleService.GetRichList(type);
            return Json(result);
        }

        //添加普通文章
        [HttpPost]
        public JsonResult AddArticle(Article article){
            BaseResultModel<Article> result=new BaseResultModel<Article>();
            result=RichArticleService.SetArticle(article);
            return Json(result);
        }
        //用于修改普通文章
        [HttpPost]
        public JsonResult UpdateArticle(Article article){
            BaseResultModel<Article> result=new BaseResultModel<Article>();
            result=RichArticleService.UpdateArticle(article);
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

    }
}