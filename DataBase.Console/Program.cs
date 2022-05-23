using PgServiceDB;

DbCore db = new DbCore();
db.DbName = "TestDb";
db.DbAddress = @"C:\Users\Reza Keshvari\Desktop\farslearn project\DataBase\DataBase.Console\bin\Debug\net6.0\DbFolder\";
db.IsChanged = true;
List<Column> studentCal = new List<Column>();
studentCal.Add(new Column
{
    Name = "Name"
});
studentCal.Add(new Column
{
    Name = "Phone"
});
Tabel studentTB = new Tabel()
{
    Name = "student",
    Columns = studentCal
};

List<Column> TeacherCal = new List<Column>();
TeacherCal.Add(new Column
{
    Name = "TeacherName"
});
TeacherCal.Add(new Column
{
    Name = "Income"
});
Tabel TeacherTB = new Tabel()
{
    Name = "Teacher",
    Columns = TeacherCal
};
db.Tabels.Add(studentTB);
db.Tabels.Add(TeacherTB);
db.Create();
//List<string> data = new List<string>();
//var rand = new Random().Next(100);
//var rand1 = new Random().Next(2000);
//data.Add("Reza " + rand);
//data.Add(rand1.ToString());
//db.Add(TeacherTB, data);
//var GetAllData = db.GetAll(TeacherTB);
//foreach(var item in GetAllData)
//{
//    Console.WriteLine(item[0]);
//    Console.WriteLine(item[1]);
//}
//string id = Console.ReadLine();
//db.Delete(TeacherTB,id);
//var GetAllData1 = db.GetAll(TeacherTB);

//foreach (var item in GetAllData1)
//{
//    Console.WriteLine(item[0]);
//    Console.WriteLine(item[1]);
//}
//string id1 = Console.ReadLine();
//var result = db.GetOne(TeacherTB, id1);
//Console.WriteLine(result[1]);
//Console.WriteLine(result[2]);
var GetAllData = db.GetAll(TeacherTB);
foreach (var item in GetAllData)
{
    Console.WriteLine(item[0]);
    Console.WriteLine(item[1]);
}

Console.WriteLine("done");