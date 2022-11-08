﻿using System.ComponentModel.DataAnnotations;

namespace BlazorNhiber1.Data
{
    public class SinhVienSearchModel
    {
        [Display(Name = "No.")]
        public int stt { get; set; }
        [Display(Name = "Tên sinh viên")]
        public string ten { get; set; }
        [Display(Name = "Tuổi")]
        public string gioitinh { get; set; }
        [Display(Name = "Giới tính")]
        public int tuoi { get; set; }
        [Display(Name = "Điểm toán")]
        public float diemtoan { get; set; }
        [Display(Name = "Điểm Anh")]
        public float diemvan { get; set; }
        [Display(Name = "Điểm văn")]
        public float diemanh { get; set; }
        [Display(Name = "Điểm trung bình")]
        public float diemtb { get; set; }
        [Display(Name = "Học lực")]
        public string hocluc { get; set; }
        public int id;
    }
}

