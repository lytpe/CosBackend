using System;
using Cos.Models;
using Cos.Models.RichAndArticles;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Cos.Services
{
    public class RichArticleService
    {
        //后台获取文章类型
        public static PaginationResultModel<Article> GetArticleList(PaginationModel pageList)
        {
           PaginationResultModel<Article> result=new PaginationResultModel<Article>();
           try{
               using(CDBContext _cDBContext=new CDBContext()){
                    List<Article> messages=_cDBContext.Ar.Skip((pageList.Index-1)*pageList.Size).Take(pageList.Size).ToList();
                    result.Total=_cDBContext.Ar.Count();
                    result.status = 1;
                    result.Data = messages;
                    result.message = "获取数据成功！";
               }
           }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
               result.Total=0;
           }
            return result; 
        }
        //前台根据页面获取文章列表
        public static BaseResultModel<List<Article>> GetFrontArticleList(string type){
            BaseResultModel<List<Article>> result=new BaseResultModel<List<Article>>();
            try{
               using(CDBContext _cDBContext=new CDBContext()){
                    List<Article> messages=_cDBContext.Ar.Where(p=>p.type==type).Take(3).ToList();
                    result.status = 1;
                    result.Data = messages;
                    result.message = "获取数据成功！";
               }
           }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result; 
        }
        //前台根据页面获取页面左下角图文
        public static BaseResultModel<Article> GetFrontArticle(string type){
             BaseResultModel<Article> result=new BaseResultModel<Article>();
              try{
               using(CDBContext _cDBContext=new CDBContext()){
                    Article messages=_cDBContext.Ar.FirstOrDefault(p=>p.type==type);
                    result.status = 1;
                    result.Data = messages;
                    result.message = "获取数据成功！";
               }
           }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result; 
        }
        //用于获取不同页面中富文本介绍
        public static BaseResultModel<List<SimpleArticle>> GetFrontRichList(string type)
        {
            BaseResultModel<List<SimpleArticle>> result=new BaseResultModel<List<SimpleArticle>>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                        result.status = 1;
                        result.Data = _cDBContext.Si.Where(p=>p.type.Equals(type)).Take(3).ToList();
                        result.message = "获取数据成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result;
        }
        //用于获取页面富文本列表
        public static PaginationResultModel<SimpleArticle> GetRichList(PaginationModel pageList){
            PaginationResultModel<SimpleArticle> result=new PaginationResultModel<SimpleArticle>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    List<SimpleArticle> s=new List<SimpleArticle>();
                    s=_cDBContext.Si.Skip((pageList.Index-1)*pageList.Size).Take(pageList.Size).ToList();
                    result.Total=_cDBContext.Si.Count();
                    result.status = 1;
                    result.Data = s;
                    result.message = "获取数据成功！";
                    
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
               result.Total=0;
           }
            return result;
        }
        //用于添加文章
        public static BaseResultModel<Article> SetArticle(Article article){
            BaseResultModel<Article> result=new BaseResultModel<Article>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    Article a=new Article();
                    a.UserName=article.UserName;
                    a.type=article.type;
                    a.ArticleContext=article.ArticleContext;
                    a.ArticleCreateDate=article.ArticleCreateDate;
                    a.ArticleImgUrl=article.ArticleImgUrl;
                    a.ArticleSideName=article.ArticleSideName;
                    a.ArticleUpdateDate=article.ArticleUpdateDate;
                    a.ArticleName=article.ArticleName;
                    _cDBContext.Ar.Add(a);
                    _cDBContext.SaveChanges();

                    result.status = 1;
                    result.Data = null;
                    result.message = "添加文章成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result;
        }
        //用于修改文章
        public static BaseResultModel<Article> UpdateArticle(Article article){
            BaseResultModel<Article> result=new BaseResultModel<Article>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    Article a=_cDBContext.Ar.FirstOrDefault(p=>p.Id.Equals(article.Id));
                    a.UserName=article.UserName;
                    a.type=article.type;
                    a.ArticleContext=article.ArticleContext;

                    a.ArticleSideName=article.ArticleSideName;
                    a.ArticleUpdateDate=article.ArticleUpdateDate;
                    a.ArticleName=article.ArticleName;
                    _cDBContext.Ar.Update(a);
                    _cDBContext.SaveChanges();

                    result.status = 1;
                    result.Data = null;
                    result.message = "更新文章成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result;

        }

        //用于添加富文章
        public static BaseResultModel<SimpleArticle> SetRichArticle(SimpleArticle simpleArticle){
             BaseResultModel<SimpleArticle> result=new BaseResultModel<SimpleArticle>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    SimpleArticle a=new SimpleArticle();
                    a.UserName=simpleArticle.UserName;
                    a.type=simpleArticle.type;
                    a.ArticleContext=simpleArticle.ArticleContext;
                    a.ArticleCreateDate=simpleArticle.ArticleCreateDate;
                    a.ArticleImgUrl=simpleArticle.ArticleImgUrl;
                    a.ArticleUpdateDate=simpleArticle.ArticleUpdateDate;
                    _cDBContext.Si.Add(a);
                    _cDBContext.SaveChanges();

                    result.status = 1;
                    result.Data = null;
                    result.message = "添加文章成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result;
        }
        //用于修改富文章
        public static BaseResultModel<SimpleArticle> UpdateRichArticle(SimpleArticle simpleArticle){
             BaseResultModel<SimpleArticle> result=new BaseResultModel<SimpleArticle>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    SimpleArticle a=_cDBContext.Si.FirstOrDefault(p=>p.Id==simpleArticle.Id);
                    a.UserName=simpleArticle.UserName;
                    a.type=simpleArticle.type;
                    a.ArticleContext=simpleArticle.ArticleContext;
                    a.ArticleUpdateDate=simpleArticle.ArticleUpdateDate;
                    _cDBContext.Si.Update(a);
                    _cDBContext.SaveChanges();
                    result.status = 1;
                    result.Data = null;
                    result.message = "更新文章成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
           }
            return result;
        }
    }
}