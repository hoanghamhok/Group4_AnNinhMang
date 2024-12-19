using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANM_tuan5
{
    public class DES
    {
        
            public string FileKQ_1 { get; set; }
            public string BanMaDes { get; set; }
            public string BanRoDes { get; set; }
        string[] MangKhoa = new string[16];
        // Ma trận E (hoán vị mở rộng)
        int[,] E = {
                    { 32,  1,  2,  3,  4,  5 },
                    {  4,  5,  6,  7,  8,  9 },
                    {  8,  9, 10, 11, 12, 13 },
                    { 12, 13, 14, 15, 16, 17 },
                    { 16, 17, 18, 19, 20, 21 },
                    { 20, 21, 22, 23, 24, 25 },
                    { 24, 25, 26, 27, 28, 29 },
                    { 28, 29, 30, 31, 32,  1 }};
        string PhepDichBit(string STR, int SoBit)
        {
            string str = "";
            if (SoBit == 1)
            {
                for (int i = 0; i < STR.Length - 1; i++)
                {
                    str += STR[i + 1];
                }
                str += STR[0];
            }
            else
            {
                for (int i = 1; i < STR.Length - 1; i++)
                {
                    str += STR[i + 1];
                }
                str += STR[0];
                str += STR[1];
            }
            return str;
        }
        public string HoanViPC_1(string input)
        {
            // Bảng hoán vị PC-1
            int[] PC1 = {
        57, 49, 41, 33, 25, 17,  9,
         1, 58, 50, 42, 34, 26, 18,
        10,  2, 59, 51, 43, 35, 27,
        19, 11,  3, 60, 52, 44, 36,
        63, 55, 47, 39, 31, 23, 15,
         7, 62, 54, 46, 38, 30, 22,
        14,  6, 61, 53, 45, 37, 29,
        21, 13,  5, 28, 20, 12,  4
    };

            // Kết quả sau hoán vị
            StringBuilder result = new StringBuilder();

            foreach (int index in PC1)
            {
                result.Append(input[index - 1]); // Trừ 1 vì mảng bắt đầu từ 0
            }

            return result.ToString();
        }
        public string HoanViPC_2(string input)
        {
            // Bảng hoán vị PC-2
            int[] PC2 = {
        14, 17, 11, 24,  1,  5,
         3, 28, 15,  6, 21, 10,
        23, 19, 12,  4, 26,  8,
        16,  7, 27, 20, 13,  2,
        41, 52, 31, 37, 47, 55,
        30, 40, 51, 45, 33, 48,
        44, 49, 39, 56, 34, 53,
        46, 42, 50, 36, 29, 32
    };

            // Kết quả sau hoán vị
            StringBuilder result = new StringBuilder();

            foreach (int index in PC2)
            {
                result.Append(input[index - 1]); // Trừ 1 vì mảng bắt đầu từ 0
            }

            return result.ToString();
        }

        public void HamTaoKhoa(string Khoa) // Dau vao la khoa nhi phan
        {
            Khoa = HoanViPC_1(Khoa);
            string C = Khoa.Substring(0, 28);
            string D = Khoa.Substring(28, 28);
            for (int i = 0; i < 16; i++)
            {
                if (i == 0 || i == 1 || i == 8 || i == 15)
                {
                    C = PhepDichBit(C, 1);
                    D = PhepDichBit(D, 1);
                }
                else
                {
                    C = PhepDichBit(C, 2);
                    D = PhepDichBit(D, 2);
                }
                MangKhoa[i] = HoanViPC_2(C + D);
            }
        }
        string HopMoRongE(string STR)
        {
            string str = "";
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                    str += STR[E[i, j] - 1];
            }
            return str;
        }
        string HopTheViS(string STR, int[,] Mang)
        {
            string str_1 = "";
            string str_2 = "";
            double b;
            int Hang = 0;
            Hang = int.Parse(STR[0].ToString()) * 2 +
            int.Parse(STR[STR.Length - 1].ToString());
            b = int.Parse(STR[1].ToString()) * Math.Pow(2,
            3) + int.Parse(STR[2].ToString()) *
            Math.Pow(2, 2) +
            int.Parse(STR[3].ToString()) * Math.Pow(2,
            1) + int.Parse(STR[4].ToString());
            str_1 = b.ToString();
            int Cot = Convert.ToInt32(str_1);
            str_2 = Mang[Hang, Cot].ToString();
            str_2 = Convert.ToString(Mang[Hang, Cot], 2);
            return str_2.PadLeft(4, '0');
        }
        public string PhepXOR(string str1, string str2)
        {
            // Kiểm tra độ dài hai chuỗi có bằng nhau hay không
            if (str1.Length != str2.Length)
            {
                throw new ArgumentException("Hai chuỗi nhị phân phải có độ dài bằng nhau để thực hiện phép XOR.");
            }

            StringBuilder result = new StringBuilder();

            // Thực hiện XOR từng bit
            for (int i = 0; i < str1.Length; i++)
            {
                result.Append(str1[i] == str2[i] ? '0' : '1');
            }

            return result.ToString();
        }
        public string HoanViP(string input)
        {
            // Bảng hoán vị P
            int[] P = {
        16,  7, 20, 21, 29, 12, 28, 17,
        1,  15, 23, 26,  5, 18, 31, 10,
        2,  8, 24, 14, 32, 27,  3,  9,
        19, 13, 30,  6, 22, 11,  4, 25
    };

            // Kết quả sau hoán vị
            StringBuilder result = new StringBuilder();

            // Thực hiện hoán vị theo bảng P
            foreach (int index in P)
            {
                result.Append(input[index - 1]); // Trừ 1 vì chỉ số mảng bắt đầu từ 0
            }

            return result.ToString();
        }
        // Các bảng S1 đến S8 trong DES
        int[,] S1 = {
    { 14, 4, 13, 1, 2, 15, 11, 8, 16, 5, 3, 10, 6, 12, 9, 0 },
    { 15, 1, 8, 14, 13, 4, 7, 11, 2, 12, 9, 5, 3, 10, 6, 0 },
    { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 8, 2, 4 },
    { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 15, 4 }
};
        // Bảng S2
        int[,] S2 = {
    { 15, 1, 8, 14, 13, 4, 7, 11, 2, 12, 9, 5, 3, 10, 6, 0 },
    { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 },
    { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 9, 3, 15, 6, 2 },
    { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 9, 5, 0, 14, 12 }
};

        // Bảng S3
        int[,] S3 = {
    { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 8, 2, 4 },
    { 3, 14, 4, 9, 8, 15, 10, 1, 2, 7, 5, 11, 12, 0, 6, 13 },
    { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 9, 0, 14, 2 },
    { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 9, 5, 0, 14, 12 }
};

        // Bảng S4
        int[,] S4 = {
    { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 15, 4 },
    { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 15, 8, 2, 6 },
    { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 9, 0, 14, 2 },
    { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 9, 5, 0, 14, 12 }
};

        // Bảng S5
        int[,] S5 = {
    { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 },
    { 14, 11, 2, 12, 4, 7, 13, 1, 5, 14, 8, 15, 6, 9, 3, 10 },
    { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 9, 10, 4, 5, 3, 0 },
    { 8, 6, 4, 15, 9, 11, 7, 3, 1, 14, 10, 13, 12, 5, 0, 2 }
};

        // Bảng S6
        int[,] S6 = {
    { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 },
    { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 },
    { 9, 14, 15, 5, 2, 8, 12, 7, 3, 10, 1, 13, 4, 11, 0, 6 },
    { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 8, 0, 13, 6 }
};

        // Bảng S7
        int[,] S7 = {
    { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 },
    { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 15, 8, 6, 2 },
    { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 9, 5, 0, 15, 8, 6 },
    { 11, 8, 15, 12, 5, 9, 0, 14, 10, 1, 7, 2, 13, 4, 3, 6 }
};

        // Bảng S8
        int[,] S8 = {
    { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 },
    { 1, 15, 13, 8, 10, 3, 4, 14, 7, 11, 9, 12, 5, 0, 6, 2 },
    { 10, 1, 13, 15, 14, 12, 5, 8, 9, 3, 11, 4, 7, 2, 6, 0 },
    { 7, 13, 2, 10, 15, 0, 3, 12, 8, 4, 9, 14, 5, 1, 11, 6 }
};

        // Tương tự cho S2, S3, ..., S8 (các bảng S tiếp theo sẽ có cấu trúc tương tự)

        string Ham_f(string STR, string Key) //Ham Feitel
        {
            string str = "";
            str = PhepXOR(HopMoRongE(STR), Key);
            string[] MangString = new string[8];
            //Chia thanh 6 chuoi con
            for (int i = 0; i < str.Length; i += 6)
            {
                MangString[i / 6] = str.Substring(i, 6);
            }
            //Dua qua cac hop the vi S-box
            MangString[0] = HopTheViS(MangString[0], S1);
            MangString[1] = HopTheViS(MangString[1], S2);
            MangString[2] = HopTheViS(MangString[2], S3);
            MangString[3] = HopTheViS(MangString[3], S4);
            MangString[4] = HopTheViS(MangString[4], S5);
            MangString[5] = HopTheViS(MangString[5], S6);
            MangString[6] = HopTheViS(MangString[6], S7);
            MangString[7] = HopTheViS(MangString[7], S8);
            str = "";
            for (int i = 0; i < 8; i++)
            {
                str += MangString[i];
            }
            //Hoan vi P
            str = HoanViP(str);
            return str;
        }
        //Ma Hoa DES 
        public string ChuyenDoiASCIISangNhiPhan(string ASC)
        {
            StringBuilder str = new StringBuilder();
            foreach (char c in ASC.ToCharArray())
            {
                str.Append(Convert.ToString(c,
                2).PadLeft(8, '0'));
            }
            return str.ToString();
        }
        public string DoiNhiPhanSangThapPhan(string binary)
        {
            int decimalValue = Convert.ToInt32(binary, 2); // Chuyển từ nhị phân sang thập phân
            return decimalValue.ToString(); // Trả về kết quả dưới dạng chuỗi
        }

        public string DoiNhiPhanSangHex(string NhiPhan)
        {
            string str = "";
            List<string> stringList = new List<string>();
            for (int i = 0; i < NhiPhan.Length; i += 8)
            {
                stringList.Add(NhiPhan.Substring(i, 8));
            }
            for (int i = 0; i < NhiPhan.Length / 8; i++)
            {
                stringList[i] = DoiNhiPhanSangThapPhan(stringList[i]);
                stringList[i]
                = Convert.ToInt32(stringList[i]).ToString("X").PadLeft(2,'0');
            }
            for (int i = 0; i < NhiPhan.Length / 8; i++)
            {
                str += stringList[i];
            }
            return str;
        }
        public string HoanViIP(string input)
        {
            // Bảng hoán vị IP
            int[] IP = {
        58, 50, 42, 34, 26, 18, 10,  2,
        60, 52, 44, 36, 28, 20, 12,  4,
        62, 54, 46, 38, 30, 22, 14,  6,
        64, 56, 48, 40, 32, 24, 16,  8,
        57, 49, 41, 33, 25, 17,  9,  1,
        59, 51, 43, 35, 27, 19, 11,  3,
        61, 53, 45, 37, 29, 21, 13,  5,
        63, 55, 47, 39, 31, 23, 15,  7
    };

            // Kết quả sau hoán vị
            StringBuilder result = new StringBuilder();

            // Thực hiện hoán vị theo bảng IP
            foreach (int index in IP)
            {
                result.Append(input[index - 1]); // Trừ 1 vì mảng bắt đầu từ 0
            }

            return result.ToString();
        }
        int[] IP_1 = {
    40, 8, 48, 16, 56, 24, 64, 32,
    39, 7, 47, 15, 55, 23, 63, 31,
    38, 6, 46, 14, 54, 22, 62, 30,
    37, 5, 45, 13, 53, 21, 61, 29,
    36, 4, 44, 12, 52, 20, 60, 28,
    35, 3, 43, 11, 51, 19, 59, 27,
    34, 2, 42, 10, 50, 18, 58, 26,
    33, 1, 41, 9, 49, 17, 57, 25
};

        string HoanViIP_1(string input)
        {
            // Logic để thực hiện hoán vị ngược
            string output = "";
            for (int i = 0; i < IP_1.Length; i++)
            {
                output += input[IP_1[i] - 1];
            }
            return output;
        }


        string Des(string BanRoNhiPhan) //Dau vao ban ro la nhi phan
        {
            FileKQ_1 = "";
            string str = "";
            StringBuilder STR = new StringBuilder();
            string L, R;
            string L_0, R_0;
            BanRoNhiPhan = HoanViIP(BanRoNhiPhan);
            STR.AppendLine("Hoan Vi IP: " + BanRoNhiPhan);
            L = BanRoNhiPhan.Substring(0, 32);
            STR.AppendLine("Nua trai: " + L);
            R = BanRoNhiPhan.Substring(32, 32);
            STR.AppendLine("Nua phai: " + R);
            for (int i = 0; i < 16; i++)
            {
                STR.AppendLine("Vong lap thu " + (i + 1));
                STR.AppendLine("Khoa K: " + MangKhoa[i]);
                L_0 = L;
                R_0 = R;
                L = R_0;
                STR.AppendLine("L[" + (i + 1) + "]: " + L);
                R = PhepXOR(L_0, Ham_f(R_0, MangKhoa[i]));
                STR.AppendLine("R[" + (i + 1) + "]: " + R);
            }
            str = HoanViIP_1(R + L);
            STR.AppendLine("Ban ma nhi phan: " + str);
            FileKQ_1 = STR.ToString();
            return str;
        }

        public void MaHoaDES(string BanRo, string KhoaK) // Dau vao ban ro, khoa la ki tu//
        {
            BanMaDes = "";
            StringBuilder STR = new StringBuilder();
            STR.AppendLine("Ban ro: " + BanRo);
            STR.AppendLine("Khoa: " + KhoaK);
            KhoaK = ChuyenDoiASCIISangNhiPhan(KhoaK);
            STR.AppendLine("Khoa nhi phan la: " + KhoaK);
            HamTaoKhoa(KhoaK);
            //Chia ban ro thanh cac khoi 64 bit
            if (BanRo.Length % 8 != 0)
            {
                while (BanRo.Length % 8 != 0)
                {
                    BanRo += "_";
                }
            }
            STR.AppendLine("Ban ma sau chuan hoa: " + BanRo);
            string[] MangBanRo = new string[BanRo.Length / 8];
            for (int i = 0; i < BanRo.Length / 8; i++)
            {
                MangBanRo[i] = BanRo.Substring(i * 8, 8);
                STR.AppendLine("MA HOA KHOI " + MangBanRo[i]);
                MangBanRo[i] =
                ChuyenDoiASCIISangNhiPhan(MangBanRo[i]);
                STR.AppendLine("Dang nhi phan: " + MangBanRo[i]);
                MangBanRo[i] = Des(MangBanRo[i]);
                STR.AppendLine(FileKQ_1);
                STR.AppendLine("Ban ma chuyen doi: " +
                DoiNhiPhanSangHex(MangBanRo[i]));
                BanMaDes += MangBanRo[i];
            }
            STR.AppendLine("BAN MA SAU MA HOA: " +
            DoiNhiPhanSangHex(BanMaDes));
            FileKQ_1 = STR.ToString();
        }
        public void GiaiMaDES(string Ban_Ma, string KhoaK)
        // Dau vao ban ma la nhi phan , khoa ki tu
        {
            BanRoDes = "";
            string[] MangThe = new string[16];
            StringBuilder STR = new StringBuilder();
            STR.AppendLine("Ban ma nhi phan: " + Ban_Ma);
            STR.AppendLine("Khoa: " + KhoaK);
            KhoaK = ChuyenDoiASCIISangNhiPhan(KhoaK);
            STR.AppendLine("Khoa nhi phan la: " + KhoaK);
            HamTaoKhoa(KhoaK);
            for (int j = 0; j < 16; j++)
            {
                MangThe[j] = MangKhoa[15 - j];
            }
            for (int j = 0; j < 16; j++)
            {
                MangKhoa[j] = MangThe[j];
            }
            //Chia ban ma thanh cac khoi 64 bit
            string[] MangBanMa = new string[Ban_Ma.Length /
            64];
            for (int i = 0; i < Ban_Ma.Length / 64; i++)
            {
                MangBanMa[i] = Ban_Ma.Substring(i * 64, 64);
                STR.AppendLine("Ma Hoa Khoi " + MangBanMa[i]);
                MangBanMa[i] = Des(MangBanMa[i]);
                STR.AppendLine("Ban ro nhi phan: " +
                MangBanMa[i]);
                BanRoDes += MangBanMa[i];
            }
            FileKQ_1 = STR.ToString();
        }
    }
}
