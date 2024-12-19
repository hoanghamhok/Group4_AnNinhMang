using System.Text;
using ANM_tuan5;
class Program { 
static void Main(string[] args)
{
    // Khởi tạo giá trị đầu vào
    string banRo = "HELLODES"; // Bản rõ (cần là chuỗi có độ dài chia hết cho 8)
    string khoaK = "MYSECRET"; // Khóa (cần là chuỗi 8 ký tự)

    Console.WriteLine("=== MÃ HÓA DES ===");
    // Tạo đối tượng lớp chứa các phương thức DES
    DES des = new DES();

    // Gọi phương thức mã hóa
    des.MaHoaDES(banRo, khoaK);

    // Hiển thị kết quả mã hóa
    Console.WriteLine("Kết quả mã hóa:");
    Console.WriteLine(des.FileKQ_1);

    Console.WriteLine("\n=== GIẢI MÃ DES ===");
    // Gọi phương thức giải mã
    des.GiaiMaDES(des.BanMaDes, khoaK);

    // Hiển thị kết quả giải mã
    Console.WriteLine("Kết quả giải mã:");
    Console.WriteLine(des.FileKQ_1);

    Console.WriteLine("\nChương trình kết thúc!");
}
}