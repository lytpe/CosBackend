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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Cos.Controllers
{
    public class ScrollPicController:Controller
    {
        private IHostingEnvironment _env;
        public ScrollPicController(IHostingEnvironment env){
            _env=env;
        }
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
        public  JsonResult AddPicList(string data)
        {
            List<ScrollPicture> sps= (List<ScrollPicture>)JsonConvert.DeserializeObject(data);

            BaseResultModel<List<ScrollPicture>> sp=ScrollPicService.AddScrollPicList(sps);
            return Json(sp);
        }
        //用于删除轮播图
        [HttpPost]
        public JsonResult DeletePic(string id){
            BaseResultModel<ScrollPicture> sp=ScrollPicService.DeleteScrollPic(id);
            return Json(sp);
        }
        //用于上传轮播图
        [HttpPost]
        public  JsonResult AddPicture(List<IFormFile> files){
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
                    var filePath = webRootPath +"/images/" + formFile.FileName;
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