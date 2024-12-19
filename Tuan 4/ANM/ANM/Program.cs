
using System.Text;

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
public void HamTaoKhoa(string Khoa) // Dau vao la khoa nhi phan
{
Khoa = HoanViPC_1 (Khoa);
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
        = Convert.ToInt32(stringList[i]).ToString("X").PadLeft(2, '0 ');
    }
    for (int i = 0; i < NhiPhan.Length / 8; i++)
    {
        str += stringList[i];
    }
    return str;
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
