using System;
using Cos.Models;
using Cos.Models.Mails;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Cos.Services
{
    public class MailService{

        // private static CDBContext _cDBContext;
        // public MailService(CDBContext CDBContext){
        //    _cDBContext=CDBContext;
        // }
        //展示邮件列表
       public static BaseResultModel<List<Message>> GetMailList(){
            BaseResultModel<List<Message>> result=new BaseResultModel<List<Message>>();
            try{
                using(CDBContext cb=new CDBContext()){
                    List<Message> mss=new List<Message>();
                    mss=cb.Me.ToList();
                    result.status = 1;
                    result.Data =mss;
                    result.message = "获取数据成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
            }
            return result;
        }
        //添加邮件信息
        public static BaseResultModel<Message> SetMail(Message message){
            BaseResultModel<Message> result=new BaseResultModel<Message>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    Message ms=new Message();
                    ms.Name=message.Name;
                    ms.Phone=message.Phone;
                    ms.Email=message.Email;
                    ms.Infos=message.Infos;
                    ms.SubmitDate=DateTime.Now.ToString();
                    _cDBContext.Me.Add(ms);
                    _cDBContext.SaveChanges();
                    result.status = 1;
                    result.Data=ms;
                    result.message = "邮件提交成功！";
                }
            }catch(Exception ex){
               result.status=0;
               result.Data=null;
               result.message=ex.ToString();
            }
            return result; 
        } 
        public static BaseResultModel<Message> DeleteMessages(string Id){
            int id=Int32.Parse(Id);
            BaseResultModel<Message> result=new BaseResultModel<Message>();
            try{
                using(CDBContext _cDBContext=new CDBContext()){
                    Message ms=new Message();
                    ms=_cDBContext.Me.FirstOrDefault(p=>p.Id==id);
                    _cDBContext.Remove(ms);
                    _cDBContext.SaveChanges();
                    result.status = 1;
                    result.Data=null;
                    result.message = "邮件删除成功！";
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
