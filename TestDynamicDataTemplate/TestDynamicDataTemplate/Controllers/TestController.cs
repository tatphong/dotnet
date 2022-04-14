using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestDynamicDataTemplate.OracleDB;

namespace TestDynamicDataTemplate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            DataTable data = new DBUtils().GetUserReader();
            string a = @"Kính g?i Qu? khách hàng {USER_NAME},
                        M? t kh? u tài kho?n Internet Banking {USER_ID}
                                    c? a Qu? khách s? h?t h?n vào ngày {EXPIRED_DATE}. Qu? khách vui l?ng thay đ? i trư? c khi h?t h?n đ? có th? ti? p t? c truy c?p d?ch v? Internet Banking. M? t kh? u c? a Qu? khách ph? i tuân th? chính sách c? a SAIGONBANK như sau:
                                    1.Nh ? ng trư ? ng đư ? c đánh d? u *là b? t bu? c nh? p.
                             2.Đ ? dài m ? t kh ? u t ? i thi ? u là 8 k? t?
                             3.Đ ? dài m ? t kh ? u t ? i đa là 20 k? t?
                             4.M ? t kh ? u b ? t bu ? c ph ? i ch ? a k ? t ? ch ? và s ?
                             5.Không th ? dùng l ? i 9 m ? t kh ? u trư ? c
                             6.M ? t kh ? u m ? i không đư ? c ch ? a các giá tr? c? a m? t kh? u c?.
                                                      Ví d ?: tentoi1234 thành tentoi12 không đư?c phép
                             7.M ? t kh ? u không đư? c ch? a t? password
                             8.M ? t kh ? u không đư? c bao g?m các k? t? đ? c bi? t như '^', '$', v.v.
                             9.M ? t kh ? u không th? gi?ng v?i tên đăng nh?p hi?n th?i c?a b?n
                             10.M ? t kh ? u m ? i không đư? c gi? ng v? i m? t kh? u hi? n th? i
                             11.M ? t kh ? u m ? i đư ? c t ? o có giá tr? cho 365 ngày
                             12.M ? t kh ? u phân bi? t ch? hoa v? i ch? thư?ng.
                        Khi m?t kh?u h?t h?n, Qu? khách không th? đăng nh?p đ? đ? i m? t kh? u đư? c n? a. Qu? khách vui l?ng liên h? t?ng đài 1900 55 55 11 đ? đư?c h? tr?.
                             Đây là email t? đ?ng t? h? th?ng Email SAIGONBANK.Vui l?ng không tr? l?i l?i Email này.
                        Trân tr?ng.
                        ";
            //data.Columns;
            //string b = a.Replace(data[]);

            List<string> fields = new List<string>();
            foreach(DataColumn item in data.Columns)

            {
                //fields.Add(item.ToString());
                a = a.Replace("{" + item + "}", data.Rows[0][item.ToString()].ToString());
            }
            return Ok(a);
        }
        public void aab(int a, int b)
    }
}
