using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KT01.Models
{
    public class BaiHat
    {
        [Display(Name = "Mã bài hát")]
        public int Ma { get; set; }
        [Display(Name = "Tên bài hát")]
        public string Ten { get; set; }
        [Display(Name = "Mã thể loại")]
        public int MaTL { get; set; }
        [Display(Name = "Mã nhạc sĩ")]
        public int MaNS { get; set; }
        public BaiHat(int m, string t, int mtl, int mns)
        {
            this.Ma = m;
            this.Ten = t;
            this.MaTL = mtl;
            this.MaNS = mns;
        }
    }
}