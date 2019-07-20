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
        
        [HttpPost]
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
                return "";
            }else{
                return "";
            }

        }


        [HttpPost]
        public async Task<JsonResult> Register(RegisterModel register){
            var user=new User{UserName=register.username};
            var result=await _userManager.CreateAsync(user,register.password);
            if(result.Succeeded){
                await _signManager.SignInAsync(user,false);
                return "";
            }
            else{
                return "";
            }
        }
    
    }
}