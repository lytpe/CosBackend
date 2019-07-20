using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Cos.Models.Mails;
using Cos.Services;
using System.ComponentModel.DataAnnotations;
namespace Cos.Controllers
{
    public class MailController:Controller
    {
        public IActionResult ShowMessages(){
            return View();
        }
        //后台请求 展示网站邮件信息
        [HttpGet]
        public JsonResult ShowMessageList(){
           BaseResultModel<List<Message>> result=MailService.GetMailList();
           return Json(result);
        }
        //前台请求 添加顾客邮件
        [HttpPost]
        public JsonResult AddMessage(Message message){
           BaseResultModel<Message> m=MailService.SetMail(message);
           return Json(m);
        }
        //后台请求 删除邮件
        [HttpPost]
        public JsonResult DeleteMessage(string id){
           BaseResultModel<Message> m=MailService.DeleteMessages(id);
           return Json(m);
        }
    }
}