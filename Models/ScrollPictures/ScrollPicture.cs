using System;
namespace Cos.Models.ScrollPictures{
    public class ScrollPicture{
        public int Id{get;set;}
        public string PicName{get;set;}
        public string ImgUrl{get;set;}
        public string ImgSubmitDate{get;set;}
        //上传图片用户
        public string UserName{get;set;}
    }
}