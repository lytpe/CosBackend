using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Cos.Models.ScrollPictures;
using Cos.Services;
using System.ComponentModel.DataAnnotations;
namespace Cos.Controllers
{
    public class ScrollPicController:Controller
    {
        //获取轮播图信息
        public JsonResult GetPics()
        {
            BaseResultModel<List<ScrollPicture>> sps=ScrollPicService.GetPicList();
            return Json(sps);
        }
        //添加单个轮播图
        [HttpPost]
        public  JsonResult AddPic(ScrollPicture sp)
        {
            BaseResultModel<ScrollPicture> scroll=ScrollPicService.AddScrollPic(sp);
            return Json(scroll);
        
        }
        //添加多个轮播图
        [HttpPost]
        public  JsonResult AddPicList(List<ScrollPicture> sps)
        {
            BaseResultModel<List<ScrollPicture>> sp=ScrollPicService.AddScrollPicList(sps);
            return Json(sp);
        }
        
    }
}