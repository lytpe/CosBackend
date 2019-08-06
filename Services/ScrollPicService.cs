using System;
using System.Linq;
using Cos.Models;
using Cos.Models.ScrollPictures;
using System.Collections;
using System.Collections.Generic;
namespace Cos.Services
{
    public class ScrollPicService
    {
        private static CDBContext _cDBContext;
        public ScrollPicService(CDBContext CDBContext){
           _cDBContext=CDBContext;
        }
        //添加轮播图片
        public static BaseResultModel<ScrollPicture> AddScrollPic(ScrollPicture sp){
            BaseResultModel<ScrollPicture> result=new BaseResultModel<ScrollPicture>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    ScrollPicture scrollpicture=new ScrollPicture();
                    scrollpicture.PicName=sp.PicName;
                    scrollpicture.ImgUrl=sp.ImgUrl;
                    scrollpicture.ImgSubmitDate=sp.ImgSubmitDate;
                    scrollpicture.UserName=sp.UserName;
                    _cDBContext.Sc.Add(scrollpicture);
                    _cDBContext.SaveChanges();
                    result.status=1;
                    result.Data=null;
                    result.message="轮播图添加成功";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
            }
            return result;
        }
        //一次添加多个轮播图
        public static BaseResultModel<List<ScrollPicture>> AddScrollPicList(List<ScrollPicture> sp){
            BaseResultModel<List<ScrollPicture>> result=new BaseResultModel<List<ScrollPicture>>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    for(int i=0;i<sp.Count;i++)
                    {
                        ScrollPicture scrollpicture=new ScrollPicture();
                        scrollpicture.PicName=sp[i].PicName;
                        scrollpicture.ImgUrl=sp[i].ImgUrl;
                        scrollpicture.ImgSubmitDate=sp[i].ImgSubmitDate;
                        scrollpicture.UserName=sp[i].UserName;
                        _cDBContext.Sc.Add(scrollpicture);
                    }
                    _cDBContext.SaveChanges();
                    result.status=1;
                    result.Data=null;
                    result.message="多张轮播图添加成功";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
            }
            return result;
        }
        public static  PaginationResultModel<ScrollPicture> GetPicList(PaginationModel pageList){
             PaginationResultModel<ScrollPicture> result=new  PaginationResultModel<ScrollPicture>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    List<ScrollPicture> sps=new List<ScrollPicture>();
                    sps=_cDBContext.Sc.Skip((pageList.Index-1)*pageList.Size).Take(pageList.Size).ToList();
                    result.Total=_cDBContext.Sc.Count();
                    result.status=1;
                    result.Data=sps;
                    result.message="获取轮播图添加成功";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
               result.Total=0;
            }
            return result;
        }
        public static BaseResultModel<ScrollPicture> DeleteScrollPic(string Id){
            int id=Int32.Parse(Id);
            BaseResultModel<ScrollPicture> result=new BaseResultModel<ScrollPicture>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    ScrollPicture sps=new ScrollPicture();
                    sps=_cDBContext.Sc.FirstOrDefault(p=>p.Id==id);
                    _cDBContext.Remove(sps);
                    _cDBContext.SaveChanges();
                    result.status=1;
                    result.Data=null;
                    result.message="删除轮播图添加成功";
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