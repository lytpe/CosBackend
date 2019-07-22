using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cos.Models;
using Microsoft.AspNetCore.Identity;
using Cos.Services;
using Cos.Models.RichAndArticles;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace Cos.Controllers
{
    public class AccountController:Controller
    {
        private SignInManager<User> _signManager;
        private UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager,SignInManager<User>signInManager){
            _signManager=signInManager;
            _userManager=userManager;
        }
        
        public async Task<JsonResult> Logout(){
            await _signManager.SignOutAsync();
            BaseResultModel<string> resultModel=new BaseResultModel<string>();
            resultModel.status=1;
            resultModel.message="退出登录";
            resultModel.Data="成功退出登录";
            return Json(resultModel);
        }

        [HttpPost]
        public async Task<JsonResult> Login(LoginModel loginmodel){
            var result=await _signManager.PasswordSignInAsync(loginmodel.username,loginmodel.password,false,false);
            if(result.Succeeded){
                 BaseResultModel<string> resultModel=new BaseResultModel<string>();
                 resultModel.status=1;
                 resultModel.message="登录成功";
                 resultModel.Data=loginmodel.username;
                 return Json(resultModel);
            }else{
                 BaseResultModel<string> resultModel=new BaseResultModel<string>();
                 resultModel.status=0;
                 resultModel.message="登录失败,用户或密码错误";
                 resultModel.Data=null;
                 return Json(resultModel);
            }

        }


        [HttpPost]
        public async Task<JsonResult> Register(RegisterModel register){
            var user=new User{UserName=register.username};
            var result=await _userManager.CreateAsync(user,register.password);
            if(result.Succeeded){
                await _signManager.SignInAsync(user,false);
                 BaseResultModel<string> resultModel=new BaseResultModel<string>();
                 resultModel.status=1;
                 resultModel.message="注册成功";
                 resultModel.Data=register.username;
                 return Json(resultModel);
            }
            else{
                 BaseResultModel<string> resultModel=new BaseResultModel<string>();
                 resultModel.status=0;
                 resultModel.message="注册失败";
                 resultModel.Data=null;
                 return Json(resultModel);
            }
        }
    
    }
}