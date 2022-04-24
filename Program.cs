using System.Net;

int TestCasesCount;
List<List<int>> liTakeOut = new List<List<int>>();
List<List<int>> liDineIn = new List<List<int>>();
List<List<int>> liServed = new List<List<int>>();
string url = "https://raw.githubusercontent.com/himesh-suthar/raocodefestv1.0/main/mayurbhajiya_input.txt";
WebClient webClient = new WebClient();
using (Stream stream = webClient.OpenRead(url))
{
    using (StreamReader streamReader = new StreamReader(stream))
    {
        TestCasesCount = Convert.ToInt32(streamReader.ReadLine());
        while (!streamReader.EndOfStream)
        {
            string TakeOut = streamReader.ReadLine().Replace("[", "").Replace("]", "");
            string DineIn = streamReader.ReadLine().Replace("[", "").Replace("]", "");
            string Served = streamReader.ReadLine().Replace("[", "").Replace("]", "");
            liTakeOut.Add(TakeOut.Split(",").Select(int.Parse).ToList());
            liDineIn.Add(DineIn.Split(",").Select(int.Parse).ToList());
            liServed.Add(Served.Split(",").Select(int.Parse).ToList());
        }
    }
}
for (int i = 0; i < TestCasesCount; i++)
{
    List<int> liServ = liServed[i];
    int TakeOutIndex = 0;
    int DineInIndex = 0;
    int Index = 0;
    bool IsValid = false;
    foreach (int iServ in liServ)
    {
        IsValid = false;
        if (TakeOutIndex < liTakeOut[i].Count)
        {
            if (iServ == liTakeOut[i][TakeOutIndex])
            {
                IsValid = true;
                TakeOutIndex++;
            }
        }
        if (DineInIndex < liDineIn[i].Count)
        {
            if (iServ == liDineIn[i][DineInIndex])
            {
                IsValid = true;
                DineInIndex++;
            }
        }
        if (!IsValid)
        {
            Console.WriteLine("Invalid");
            break;
        }
    }
    if (IsValid)
    {
        Console.WriteLine("Valid");
    }
    Index++;
}