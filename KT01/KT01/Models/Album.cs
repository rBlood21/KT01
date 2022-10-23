using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KT01.Models
{
    public class Album
    {
       
        public int Ma { get; set; }
        [Display(Name = "Tên bài hát")]
        [Required(ErrorMessage = "Bắt buộc nhập trường này")]
        public string Ten { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { get; set; }
        public string AnhBia { get; set; }
        public Album(int m, string t, DateTime n, string a)
        {
            this.Ma = m;
            this.Ten = t;
            this.NgayTao = n;
            this.AnhBia = "/Contents/Image_QLBH/" + a;
        }
    }
}