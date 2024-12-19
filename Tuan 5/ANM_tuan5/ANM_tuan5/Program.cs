using System.Text;

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
