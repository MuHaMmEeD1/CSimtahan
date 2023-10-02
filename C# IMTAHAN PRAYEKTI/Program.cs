using System;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace C__IMTAHAN_PRAYEKTI
{

    class Program
    {
        //--------------{
        static List<Vacancies> vacancieses = new List<Vacancies>();

        static List<Employer> employers = new List<Employer>();

        static List<Worker> workers = new List<Worker>();
        //--------------}

        //--------------{
        static int kimlikSecer = 0;
        static int _kimlikIndex_ = 0;

        static string name = " ";
        static string phone = " ";

        static bool YoxlaNameAndPhone = true;

        static List<string> Katagoriy = new List<string>() { "Hekim", "Massin ustasi", "Programist", "Cix" };
        //--------------}

        static bool basla = true;
        static void doldur()
        {
            vacancieses = JsonSerializer.Deserialize<List<Vacancies>>(File.ReadAllText("../../../Vacancies.json"));
            employers = JsonSerializer.Deserialize<List<Employer>>(File.ReadAllText("../../../Employer.json"));
            workers = JsonSerializer.Deserialize<List<Worker>>(File.ReadAllText("../../../Worker.json"));

        }

        static void save()
        {
            File.WriteAllText("../../../Vacancies.json", JsonSerializer.Serialize(vacancieses, new JsonSerializerOptions() { WriteIndented = true }));
            File.WriteAllText("../../../Employer.json", JsonSerializer.Serialize(employers, new JsonSerializerOptions() { WriteIndented = true }));
            File.WriteAllText("../../../Worker.json", JsonSerializer.Serialize(workers, new JsonSerializerOptions() { WriteIndented = true }));
        }

        static void employer()
        {
            Thread.Sleep(2000);
            Console.Clear();

            int sec = 1;

            string[] arrSecim = new string[8] { "Show my workers", "Show my vacancieses", "Add vacancies", "Delete vacancies", "Delete my worker", "Save", "Ise bas vurna workers", "Cix" };

            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n\n\n                          Employer");
                Console.WriteLine("\t----------------------------------------------\n\t|                                            |");

                for (int i = 0; i < arrSecim.Length; i++)
                {
                    int bosluq = 39 - arrSecim[i].Length;

                    if (i + 1 == sec)
                    {
                        Console.Write($"\t|     {{{arrSecim[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                        Console.WriteLine("|");
                    }
                    else { Console.Write($"\t|     {arrSecim[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                }

                Console.WriteLine("\t|                                            |\n\t----------------------------------------------\n");


                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (sec > 1) { sec--; }
                    else if (sec == 1) { sec = arrSecim.Length; }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (sec < arrSecim.Length) { sec++; }
                    else if (sec == arrSecim.Length) { sec = 1; }
                }
                else if (keyInfo.Key == ConsoleKey.Enter) { break; }

            }

            

            if (sec == 1) { for (int i = 0; i < employers[_kimlikIndex_].Workers.Count; i++) { employers[_kimlikIndex_].Workers[i].show(); } }
            else if (sec == 2) { for (int i = 0; i < employers[_kimlikIndex_].Vacanciess.Count; i++) { employers[_kimlikIndex_].Vacanciess[i].show(); } }
            else if (sec == 3)
            {

                string[] arr1 = new string[4] { "12","00", "12","00"};
                string[] arr2 = new string[4] { " ^","  ", "  ","  "};
                string[] secimlerEm = new string[8] { "Katagory", "Is Vaxti", "Is Yeri", "Salary", "Nece Nefer Axdarilir", "Is Gunleri Hefde", "Cix", "Creat" };

                string katagory = "";
                string isVaxti = "";
                string isYeri = "";
                int salary = 0;
                int NeceIsciAxtarilir = 0;
                
                Guid id = Guid.NewGuid();

                int[] hefdeninGunleri = null;

                void yazKatagory()
                {
                    int kat_ = 1;

                    while (true)
                    {
                        Console.Clear();
                        
                        Console.WriteLine("\n\n\n                          Katagory");
                        Console.WriteLine("\t---------------------------------------------\n\t|                                            |");

                        for (int i = 0; i < Katagoriy.Count; i++)
                        {
                            int bosluq = 39 - Katagoriy[i].Length;

                            if (i + 1 == kat_)
                            {
                                Console.Write($"\t|     {{{Katagoriy[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                Console.WriteLine("|");
                            }
                            else { Console.Write($"\t|     {Katagoriy[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                        }

                        Console.WriteLine("\t|                                            |\n\t----------------------------------------------\n");


                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            if (kat_ > 1) { kat_--; }
                            else if (kat_ == 1) { kat_ = Katagoriy.Count; }
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (kat_ < Katagoriy.Count) { kat_++; }
                            else if (kat_ == Katagoriy.Count) { kat_ = 1; }
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter) { if (secimlerEm[0][secimlerEm[0].Length - 1] != '+') { secimlerEm[0] += " +"; }   katagory = Katagoriy[kat_-1]; break; }

                    }

                }
                void yazIsVaxti() {

                    int Vaxt1 = 0;
                    


                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\n                 İs Vaxdi ");
                        Console.WriteLine("\t---------------------------\n\t|                         |");

                        Console.WriteLine("\t|      -------------      |");
                        Console.WriteLine($"\t|      |{arr1[0]}:{arr1[1]}\\{arr1[2]}:{arr1[3]}|      |");
                        Console.WriteLine("\t|      -------------      |");

                        Console.WriteLine($"\t|       {arr2[0]} {arr2[1]} {arr2[2]} {arr2[3]}       |\n\t---------------------------\n");


                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {

                            void _vaxt(int i)
                            {
                                if (arr1[i] == "00") { arr1[i] = "01"; }
                                else if (arr1[i] == "01") { arr1[i] = "02"; }
                                else if (arr1[i] == "02") { arr1[i] = "03"; }
                                else if (arr1[i] == "03") { arr1[i] = "04"; }
                                else if (arr1[i] == "04") { arr1[i] = "05"; }
                                else if (arr1[i] == "05") { arr1[i] = "06"; }
                                else if (arr1[i] == "06") { arr1[i] = "07"; }
                                else if (arr1[i] == "07") { arr1[i] = "08"; }
                                else if (arr1[i] == "08") { arr1[i] = "09"; }
                                else if (arr1[i] == "09") { arr1[i] = "10"; }
                                else if (arr1[i] == "10") { arr1[i] = "11"; }
                                else if (arr1[i] == "11") { arr1[i] = "12"; }
                                else if (arr1[i] == "12") { arr1[i] = "13"; }
                                else if (arr1[i] == "13") { arr1[i] = "14"; }
                                else if (arr1[i] == "14") { arr1[i] = "15"; }
                                else if (arr1[i] == "15") { arr1[i] = "16"; }
                                else if (arr1[i] == "16") { arr1[i] = "17"; }
                                else if (arr1[i] == "17") { arr1[i] = "18"; }
                                else if (arr1[i] == "18") { arr1[i] = "19"; }
                                else if (arr1[i] == "19") { arr1[i] = "20"; }
                                else if (arr1[i] == "20") { arr1[i] = "21"; }
                                else if (arr1[i] == "21") { arr1[i] = "22"; }
                                else if (arr1[i] == "22") { arr1[i] = "23"; }
                                else if (arr1[i] == "23") { arr1[i] = "00"; }
                            }

                            void _deyqe(int i)
                            {

                                if (arr1[i] == "00") { arr1[i] = "10"; }
                                else if ( arr1[i] == "10") { arr1[i] = "20"; }
                                else if ( arr1[i] == "20") { arr1[i] = "30"; }
                                else if ( arr1[i] == "30") { arr1[i] = "40"; }
                                else if ( arr1[i] == "40") { arr1[i] = "50"; }
                                else if ( arr1[i] == "50") { arr1[i] = "00"; }
          
                            }

                            if (Vaxt1 == 0 || Vaxt1 == 2) { _vaxt(Vaxt1); }

                            else
                            {
                                _deyqe(Vaxt1);
                            }



                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {

                            void _vaxt(int i)
                            {
                                if (arr1[i] == "00") { arr1[i] = "23"; }
                                else if (arr1[i] == "23") { arr1[i] = "22"; }
                                else if (arr1[i] == "22") { arr1[i] = "21"; }
                                else if (arr1[i] == "21") { arr1[i] = "20"; }
                                else if (arr1[i] == "20") { arr1[i] = "19"; }
                                else if (arr1[i] == "19") { arr1[i] = "18"; }
                                else if (arr1[i] == "18") { arr1[i] = "17"; }
                                else if (arr1[i] == "17") { arr1[i] = "16"; }
                                else if (arr1[i] == "16") { arr1[i] = "15"; }
                                else if (arr1[i] == "15") { arr1[i] = "14"; }
                                else if (arr1[i] == "14") { arr1[i] = "13"; }
                                else if (arr1[i] == "13") { arr1[i] = "12"; }
                                else if (arr1[i] == "12") { arr1[i] = "11"; }
                                else if (arr1[i] == "11") { arr1[i] = "10"; }
                                else if (arr1[i] == "10") { arr1[i] = "09"; }
                                else if (arr1[i] == "09") { arr1[i] = "08"; }
                                else if (arr1[i] == "08") { arr1[i] = "07"; }
                                else if (arr1[i] == "07") { arr1[i] = "06"; }
                                else if (arr1[i] == "06") { arr1[i] = "05"; }
                                else if (arr1[i] == "05") { arr1[i] = "04"; }
                                else if (arr1[i] == "04") { arr1[i] = "03"; }
                                else if (arr1[i] == "03") { arr1[i] = "02"; }
                                else if (arr1[i] == "02") { arr1[i] = "01"; }
                                else if (arr1[i] == "01") { arr1[i] = "00"; }
                            } 
                            
                            void _deyqe(int i)
                            {

                                if (arr1[i] == "00") { arr1[i] = "50"; }
                                else if (arr1[i] == "50") { arr1[i] = "40"; }
                                else if (arr1[i] == "40") { arr1[i] = "30"; }
                                else if (arr1[i] == "30") { arr1[i] = "20"; }
                                else if (arr1[i] == "20") { arr1[i] = "10"; }
                                else if (arr1[i] == "10") { arr1[i] = "00"; }



                            }

                            if (Vaxt1 == 0 || Vaxt1 == 2) { _vaxt(Vaxt1); }

                            else
                            {
                                _deyqe(Vaxt1);
                            }

                        }
                        else if (keyInfo.Key == ConsoleKey.LeftArrow)
                        {
                            if (Vaxt1 > 0) { arr2[Vaxt1] = "  "; Vaxt1--; arr2[Vaxt1] = " ^"; }
                            else if (Vaxt1 == 0) { arr2[Vaxt1] = "  "; Vaxt1 = 3; arr2[Vaxt1] = " ^"; }
                        }
                        else if (keyInfo.Key == ConsoleKey.RightArrow)
                        {
                            if (Vaxt1 < 3) { arr2[Vaxt1] = "  "; Vaxt1++; arr2[Vaxt1] = " ^"; }
                            else if (Vaxt1 == 3) { arr2[Vaxt1] = "  "; Vaxt1 = 0;  arr2[Vaxt1] = " ^"; }
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter) { if (secimlerEm[1][secimlerEm[1].Length - 1] != '+') { secimlerEm[1] += " +"; } break; }

                    }

                    

                    isVaxti = $"{arr1[0]}:{arr1[1]}\\{arr1[2]}:{arr1[3]}";

                }
                void yazIsYeri() { Console.Write("is yeri: "); isYeri = Console.ReadLine(); if (secimlerEm[2][secimlerEm[2].Length - 1] != '+') { secimlerEm[2] += " +"; } }
                void yazSalary()
                {
                    Console.Write("is masi: ");
                    try { salary = int.Parse(Console.ReadLine()); if (!(salary > 0)) { Console.WriteLine("salary 0 dan boyuuk olmalidi"); return; } if (secimlerEm[3][secimlerEm[3].Length - 1] != '+') { secimlerEm[3] += " +"; if (secimlerEm[3][secimlerEm[3].Length - 1] != '+') { secimlerEm[3] += " +"; } } }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
                void yazNeceNeferAxdarilir()
                {
                    Console.Write("nece nefer isci axtarilir: ");
                    
                    try { NeceIsciAxtarilir = int.Parse(Console.ReadLine()); } catch (Exception e) { Console.WriteLine(e.Message);  return; }
                    if (!(salary > 0)) { Console.WriteLine("adam sayi 0 dan boyuuk olmalidi"); return; }
                    if (secimlerEm[4][secimlerEm[4].Length - 1] != '+') { secimlerEm[4] += " +"; }
                }
                void yazHefdeGunleri(){

                    List<int> hefGun = new();
                    string[] gunH_ = new string[8] { "1 ci gun", "2 ci gun", "3 cu gun", "4 cu gun", "5 ci gun", "6 ci gun", "7 ci gun", "Cix" };
                    int gunSayi = 1;

                    void yhg()
                    {
                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("\n\n\n             Hefdenin Gunleri");
                            Console.WriteLine("\t---------------------------------\n\t|                               |");

                            for (int i = 0; i < gunH_.Length; i++)
                            {
                                if (i == 7) { Console.WriteLine("\t|                               |"); }
                                int bosluq = 26 - gunH_[i].Length;

                                if (i + 1 == gunSayi)
                                {
                                    Console.Write($"\t|     {{{gunH_[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                    Console.WriteLine("|");
                                }
                                else { Console.Write($"\t|     {gunH_[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                            }

                            Console.WriteLine("\t|                               |\n\t---------------------------------\n");


                            ConsoleKeyInfo keyInfo = Console.ReadKey();

                            if (keyInfo.Key == ConsoleKey.UpArrow)
                            {
                                if (gunSayi > 1) { gunSayi--; }
                                else if (gunSayi == 1) { gunSayi = gunH_.Length; }
                            }
                            else if (keyInfo.Key == ConsoleKey.DownArrow)
                            {
                                if (gunSayi < gunH_.Length) { gunSayi++; }
                                else if (gunSayi == gunH_.Length) { gunSayi = 1; }
                            }
                            else if (keyInfo.Key == ConsoleKey.Enter) { break; }; 
                            
                        }



                        if (gunSayi == 8)
                        {
                            hefdeninGunleri = new int[hefGun.Count];
                            hefGun.Sort(); for (int i = 0; i < hefGun.Count; i++)
                            {
                                hefdeninGunleri[i] = hefGun[i]; 

                                if (secimlerEm[5][secimlerEm[5].Length - 1] != '+')
                                {
                                    secimlerEm[5] += " +";
                                }
                                return; 
                            } 
                        }
                        else
                        {
                            string[] yn = new string[2] { "Yes", "No" };
                            int _ynSay = 1;

                            while (true)
                            {
                                Console.Clear();

                                Console.WriteLine("\n\n\n                Is Var");
                                Console.WriteLine("\t------------------------------\n\t|                            |");

                                for (int i = 0; i < yn.Length; i++)
                                {
                                    int bosluq = 23 - yn[i].Length;

                                    if (i + 1 == _ynSay)
                                    {
                                        Console.Write($"\t|     {{{yn[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                        Console.WriteLine("|");
                                    }
                                    else { Console.Write($"\t|     {yn[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                                }

                                Console.WriteLine("\t|                            |\n\t------------------------------\n");


                                ConsoleKeyInfo keyInfo = Console.ReadKey();

                                if (keyInfo.Key == ConsoleKey.UpArrow)
                                {
                                    if (_ynSay > 1) { _ynSay--; }
                                    else if (_ynSay == 1) { _ynSay = yn.Length; }
                                }
                                else if (keyInfo.Key == ConsoleKey.DownArrow)
                                {
                                    if (_ynSay < yn.Length) { _ynSay++; }
                                    else if (_ynSay == yn.Length) { _ynSay = 1; }
                                }
                                else if (keyInfo.Key == ConsoleKey.Enter) { break; };

                            }

                            if(_ynSay == 1)
                            {
                                bool yoxla = true;

                                for (int i = 0; i < hefGun.Count; i++)
                                {
                                    if (hefGun[i] == gunSayi) { yoxla = false; }
                                }

                                if (yoxla) { hefGun.Add(gunSayi); if (gunH_[gunSayi-1][gunH_[gunSayi].Length - 1] != '+') { gunH_[gunSayi-1] += " +"; } }
                            }
                            else
                            {

                                for (int i = 0; i < hefGun.Count; i++)
                                {
                                    if (hefGun[i] == gunSayi) { hefGun.RemoveAt(i); }
                                }


                            }
                            
                        }

                       


                        yhg();
                    }
                    yhg();

                    hefdeninGunleri = new int[hefGun.Count];

                    hefGun.Sort();

                    for (int i = 0; i < hefGun.Count; i++)
                    {
                        hefdeninGunleri[i] = hefGun[i];
                    }


                }

                bool creat()
                {
                    if (katagory != "" && isVaxti != "" && isYeri != "" && salary != 0 && NeceIsciAxtarilir != 0 && hefdeninGunleri.Length != 0)
                    {
                        vacancieses.Add(new Vacancies(employers[_kimlikIndex_].Id, id, katagory, isVaxti, isYeri, salary, NeceIsciAxtarilir, hefdeninGunleri));
                        employers[_kimlikIndex_].Vacanciess.Add(new Vacancies(employers[_kimlikIndex_].Id, id, katagory, isVaxti, isYeri, salary, NeceIsciAxtarilir, hefdeninGunleri));
                        return true;
                    }
                    else { try { throw new QeydiyatException(); } catch (QeydiyatException qe) { Console.WriteLine(qe.Message); Thread.Sleep(1500); return false; } }
                   
                }


                void employerStart()
                {
                    int sraSayi_ = 1;

                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\n                         Creat Vacanies ");
                        Console.WriteLine("\t---------------------------------------------\n\t|                                            |");

                        for (int i = 0; i < secimlerEm.Length; i++)
                        {
                            int bosluq = 39 - secimlerEm[i].Length;

                            if (i == 6) { Console.WriteLine("\t|                                            |"); }

                            if (i + 1 == sraSayi_)
                            {
                                Console.Write($"\t|     {{{secimlerEm[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                Console.WriteLine("|");
                            }
                            else { Console.Write($"\t|     {secimlerEm[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                        }

                        Console.WriteLine("\t|                                            |\n\t----------------------------------------------\n");


                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            if (sraSayi_ > 1) { sraSayi_--; }
                            else if (sraSayi_ == 1) { sraSayi_ = secimlerEm.Length; }
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (sraSayi_ < secimlerEm.Length) { sraSayi_++; }
                            else if (sraSayi_ == secimlerEm.Length) { sraSayi_ = 1; }
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter) { break; }

                    }


                    if(sraSayi_ == 1) { yazKatagory(); }
                    else if(sraSayi_ == 2) { yazIsVaxti(); }
                    else if(sraSayi_ == 3) { yazIsYeri(); }
                    else if(sraSayi_ == 4) { yazSalary(); }
                    else if(sraSayi_ == 5) { yazNeceNeferAxdarilir(); }
                    else if(sraSayi_ == 6) { yazHefdeGunleri(); }
                    else if(sraSayi_ == 7) { return; }
                    else if(sraSayi_ == 8) { 

                       if(creat()) { return; } 
                    }

                    employerStart();
                }

                employerStart();





            }
            else if (sec == 4)
            {

                for (int i = 0; i < employers[_kimlikIndex_].Vacanciess.Count; i++) { Console.WriteLine($"\n({i + 1}) sra sayi"); employers[_kimlikIndex_].Vacanciess[i].show(); }

                Console.Write("necencini silmek isteirsiz");

                int sraSayi = 0;

                try { sraSayi = int.Parse(Console.ReadLine()); } catch (Exception e) { Console.WriteLine(e.Message); return; }

                if (sraSayi <= employers[_kimlikIndex_].Vacanciess.Count) { employers[_kimlikIndex_].Vacanciess.RemoveAt(sraSayi); }
                else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); } }




            }
            else if (sec == 5)
            {


                for (int i = 0; i < employers[_kimlikIndex_].Workers.Count; i++) { Console.WriteLine($"\n({i + 1}) sra sayi"); employers[_kimlikIndex_].Workers[i].show(); }

                Console.Write("necencini silmek isteirsiz");

                int sraSayi = 0;

                try { sraSayi = int.Parse(Console.ReadLine()); } catch (Exception e) { Console.WriteLine(e.Message); return; }

                if (sraSayi <= employers[_kimlikIndex_].Workers.Count) { employers[_kimlikIndex_].Workers.RemoveAt(sraSayi); }
                else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); } }


            }
            else if (sec == 6) { save(); }
            else if (sec == 7)
            {

                int wrSay = 1;
                for (int i = 0; i < employers[_kimlikIndex_].Vacanciess.Count; i++)
                {

                    for (int w = 0; w < employers[_kimlikIndex_].Vacanciess[i].WorkerList.Count; w++)
                    {
                        Console.WriteLine($"\n({wrSay++}) sra sayi"); employers[_kimlikIndex_].Vacanciess[i].WorkerList[w].show();

                    }
                }




                Console.Write("\nsra sayina gore secim edin: ");
                int sraSec = 0;
                try { sraSec = int.Parse(Console.ReadLine()); } catch (Exception e) { Console.WriteLine(e.Message); return; }

                int sCount = 0;
                int III = 0;
                int WWW = 0;

                for (int i = 0; i < employers[_kimlikIndex_].Vacanciess.Count; i++)
                {
                    for (int w = 0; w < employers[_kimlikIndex_].Vacanciess[i].WorkerList.Count; w++)
                    {
                        sCount++;
                        if (sCount == sraSec) { III = i; WWW = w; break; }
                    }

                }

                if (sraSec <= sCount)
                {


                    Console.WriteLine("(1) ise al");
                    Console.WriteLine("(2) ise alma");
                    Console.WriteLine("(3) cix");

                    Console.Write("\nsecim edin: ");

                    string secSeci = Console.ReadLine();

                    if (secSeci == "1") { employers[_kimlikIndex_].Workers.Add(employers[_kimlikIndex_].Vacanciess[III].WorkerList[WWW]); employers[_kimlikIndex_].Vacanciess[III].WorkerList.RemoveAt(WWW); }
                    else if (secSeci == "2") { employers[_kimlikIndex_].Vacanciess[III].WorkerList.RemoveAt(WWW); }
                    else if (secSeci == "3") { return; }
                    else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); } }


                }
                else { try { throw new BeleBirWorkerYoxduException(); } catch (BeleBirWorkerYoxduException bbwye) { kimlikSecer = 0; Console.WriteLine(bbwye.Message); } }

            }
            else if (sec == 8) { kimlikSecer = 0; return; }
            else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); } }

        }

        static void worker()
        {

            Thread.Sleep(2000);
            Console.Clear();

            string[] secimlerW = new string[3] { "Is Tap", "Save", "Cix" };

            int sec = 1;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("\n\n\n                      Worker");
                Console.WriteLine("\t---------------------------------\n\t|                               |");

                for (int i = 0; i < secimlerW.Length; i++)
                {
                    int bosluq = 26 - secimlerW[i].Length;

                    if (i + 1 == sec)
                    {
                        Console.Write($"\t|     {{{secimlerW[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                        Console.WriteLine("|");
                    }
                    else { Console.Write($"\t|     {secimlerW[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                }

                Console.WriteLine("\t|                               |\n\t---------------------------------\n");


                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (sec > 1) { sec--; }
                    else if (sec == 1) { sec = secimlerW.Length; }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (sec < secimlerW.Length) { sec++; }
                    else if (sec == secimlerW.Length) { sec = 1; }
                }
                else if (keyInfo.Key == ConsoleKey.Enter) { break; }

            }



            if (sec == 1)
            {

                int sec_int = 1;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\n                      Is Axdar");
                    Console.WriteLine("\t---------------------------------\n\t|                               |");

                    for (int i = 0; i < Katagoriy.Count; i++)
                    {
                        int bosluq = 26 - Katagoriy[i].Length;

                        if (i == Katagoriy.Count - 1)
                        {
                            Console.WriteLine("\t|                               |");
                        }

                        if (i + 1 == sec_int)
                        {
                            Console.Write($"\t|     {{{Katagoriy[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                            Console.WriteLine("|");
                        }
                        else { Console.Write($"\t|     {Katagoriy[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                    }

                    Console.WriteLine("\t|                               |\n\t---------------------------------\n");


                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (sec_int > 1) { sec_int--; }
                        else if (sec_int == 1) { sec_int = Katagoriy.Count; }
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (sec_int < Katagoriy.Count) { sec_int++; }
                        else if (sec_int == Katagoriy.Count) { sec_int = 1; }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter) { break; }

                }





                void showKatagorieGore(string melumat)
                {
                    bool iciniYoxlayan = true;

                    if (melumat == "Cix") { return; }

                    for (int i = 0; i < vacancieses.Count; i++)
                    {
                        if (vacancieses[i].Kataqorisi == melumat) { iciniYoxlayan = false; Console.WriteLine($"Sra Nomresi {i + 1}"); vacancieses[i].show(); }
                    }

                    if (iciniYoxlayan) { Console.WriteLine("bu saede is yoxdu"); return; }

                    Console.Write("\nsra nomresine gore secim edin:");
                    int secim = 0;
                    try { secim = int.Parse(Console.ReadLine()); } catch (Exception ex) { Console.WriteLine(ex.Message); return; }

                    int sraSayinYoxla = -1;

                    for (int i = 0, bil = 0; i < vacancieses.Count; i++) { if (vacancieses[i].Kataqorisi == melumat) { bil++; } if (bil == secim) { sraSayinYoxla = i; break; } }

                    if (sraSayinYoxla > -1)
                    {

                        for (int i = 0; i < employers.Count; i++)
                        {
                            if (employers[i].Id == vacancieses[sraSayinYoxla].Id)
                            {

                                for (int e = 0; e < employers[i].Vacanciess.Count; e++)
                                {
                                    if (vacancieses[sraSayinYoxla].IdMy == employers[i].Vacanciess[e].IdMy)
                                    {
                                        employers[i].Vacanciess[e].WorkerList.Add(workers[_kimlikIndex_]);
                                        return;
                                    }
                                }

                            }
                        }
                    }
                    else { try { throw new BeleBirIsYoxduException(); } catch (BeleBirIsYoxduException bbiye) { Console.WriteLine(bbiye.Message); } }



                }

                if (sec_int == 0) { return; }

                for (int i = 0; i < Katagoriy.Count; i++)
                {
                    if (sec_int == i + 1)
                    {
                        showKatagorieGore(Katagoriy[i]);
                        return;
                    }
                }

                try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); }


            }
            else if (sec == 2) { save(); }
            else if (sec == 3) { kimlikSecer = 0; return; }
            else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); } }


        }

        static void secim()
        {
            string[] metinler = new string[5] { "Employer kimi gir", "Worker kimi gir", "Employer kimi qeydiyatdan kec", "Worker kimi qeydiyatdan kec", "Save" };

            if (kimlikSecer == 1 || kimlikSecer == 2) { } else { kimlikSecer = 0; }


            if (kimlikSecer == 0)
            {

                Console.Clear();
                kimlikSecer = 1;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\n                                 Menyu");
                    Console.WriteLine("\t------------------------------------------------------\n\t|                                                    |");

                    for (int i = 0; i < metinler.Length; i++)
                    {
                        int bosluq = 47 - metinler[i].Length;

                        if (i + 1 == kimlikSecer)
                        {
                            Console.Write($"\t|     {{{metinler[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                            Console.WriteLine("|");
                        }
                        else { Console.Write($"\t|     {metinler[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                    }

                    Console.WriteLine("\t|                                                    |\n\t------------------------------------------------------\n");


                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (kimlikSecer > 1) { kimlikSecer--; }
                        else if (kimlikSecer == 1) { kimlikSecer = metinler.Length; }
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (kimlikSecer < metinler.Length) { kimlikSecer++; }
                        else if (kimlikSecer == metinler.Length) { kimlikSecer = 1; }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter) { break; }

                }

                Thread.Sleep(2000);
                Console.Clear();

                YoxlaNameAndPhone = true;
            }
            else { YoxlaNameAndPhone = false; }


            if (kimlikSecer == 1)
            {

                if (YoxlaNameAndPhone)
                {
                    Console.Write("Name: "); name = Console.ReadLine();
                    Console.Write("Phone: "); phone = Console.ReadLine();
                }

                for (int i = 0; i < employers.Count; i++)
                {
                    if (employers[i].Name == name && employers[i].Phone == phone) { _kimlikIndex_ = i; employer(); secim(); return; }
                }

                try { throw new BeleBirEmployerYoxduException(); } catch (BeleBirEmployerYoxduException bbeye) { kimlikSecer = 0; Console.WriteLine(bbeye.Message); Thread.Sleep(1500); }

            }
            else if (kimlikSecer == 2)
            {

                if (YoxlaNameAndPhone)
                {
                    Console.Write("Name: "); name = Console.ReadLine();
                    Console.Write("Phone: "); phone = Console.ReadLine();
                }

                for (int i = 0; i < workers.Count; i++) { if (workers[i].Name == name && workers[i].Phone == phone) { _kimlikIndex_ = i; worker(); secim(); return; } }

                try { throw new BeleBirWorkerYoxduException(); } catch (BeleBirWorkerYoxduException bbwye) { kimlikSecer = 0; Console.WriteLine(bbwye.Message); Thread.Sleep(1500); }
            }
            else if (kimlikSecer == 3)
            {

                int tapIndex = 1;

                string name = "";
                string surname = "";
                string seher = "";
                string nomre = "";
                int age = 0;


                string[] _4 = new string[7] { "Name", "Surname", "Seher", "Nomre", "Age", "Cix", "Creat" };

                void yazName() { Console.Write("Name: "); name = Console.ReadLine(); if (_4[0][_4[0].Length - 1] != '+') { _4[0] += " +"; } }
                void yazSurname() { Console.Write("Surname: "); surname = Console.ReadLine(); if (_4[1][_4[1].Length - 1] != '+') { _4[1] += " +"; } }
                void yazSeher() { Console.Write("Seher: "); seher = Console.ReadLine(); if (_4[2][_4[2].Length - 1] != '+') { _4[2] += " +"; } }
                void yazNomre()
                {
                    while (true)
                    {

                        Console.Write("misal (000-000-00-00) nomre: "); nomre = Console.ReadLine();
                        try
                        {
                            if (nomre.Length == 13)
                            {
                                for (int i = 0; i < 13; i++)
                                {

                                    if (i == 0 || i == 1 || i == 2 || i == 4 || i == 5 || i == 6 || i == 8 || i == 9 || i == 11 || i == 12)
                                    {
                                        if ((int)nomre[i] > 47 && (int)nomre[i] < 58) { }
                                        else { throw new YanlisNomreException(); }
                                    }

                                    else if (i == 3 || i == 7 || i == 10)
                                    {
                                        if ((int)nomre[i] == '-') ;
                                        else { throw new YanlisNomreException(); };
                                    }

                                }

                                for (int i = 0; i < employers.Count; i++)
                                {
                                    if (employers[i].Phone == nomre) { throw new YanlisNomreException(); }
                                }

                            }
                            else { throw new YanlisNomreException(); }
                        }
                        catch (YanlisNomreException yne) { Console.WriteLine(yne.Message); Thread.Sleep(1500); return; }
                        if (_4[3][_4[3].Length - 1] != '+') { _4[3] += " +"; }
                        return;
                    }
                }
                void yazAge()
                {
                    while (true)
                    {
                        Console.Write("Age: ");
                        try { age = int.Parse(Console.ReadLine()); if (!(age > 0 && age < 100)) { Console.WriteLine("\tage 0 ve 100 arasinda ola biler"); continue; } if (_4[4][_4[4].Length - 1] != '+') { _4[4] += " +"; } break; } catch (Exception e) { Console.WriteLine(e.Message); Thread.Sleep(1500); return; }
                    }
                }


                void creatEle()
                {
                    
                    employers.Add(new Employer(Guid.NewGuid(), name, surname, seher, nomre, age));
                }



                void employerStart()
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\n                 Creat Employer");
                        Console.WriteLine("\t-----------------------------------------\n\t|                                       |");

                        for (int i = 0; i < _4.Length; i++)
                        {
                            if (i == 5)
                            {
                                Console.Write("\t|                                       |\n");
                            }
                            int bosluq = 34 - _4[i].Length;

                            if (i + 1 == tapIndex)
                            {
                                Console.Write($"\t|     {{{_4[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                Console.WriteLine("|");
                            }
                            else { Console.Write($"\t|     {_4[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                        }


                        Console.WriteLine("\t|                                       |\n\t-----------------------------------------\n");


                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            if (tapIndex > 1) { tapIndex--; }
                            else if (tapIndex == 1) { tapIndex = _4.Length; }
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (tapIndex < _4.Length) { tapIndex++; }
                            else if (tapIndex == _4.Length) { tapIndex = 1; }
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter) { break; }

                    }

                    if (tapIndex == 1) { yazName(); }
                    else if (tapIndex == 2) { yazSurname(); }
                    else if (tapIndex == 3) { yazSeher(); }
                    else if (tapIndex == 4) { yazNomre(); }
                    else if (tapIndex == 5) { yazAge(); }
                    else if (tapIndex == 6) { return; }
                    else if (tapIndex == 7)
                    {

                        if (name != "" && surname != "" && seher != "" && nomre != "" && age != 0)
                        {
                            creatEle(); return;
                        }
                        else { try { throw new QeydiyatException(); } catch (QeydiyatException qe) { Console.WriteLine(qe.Message); Thread.Sleep(1500); } }

                    }

                    employerStart();
                }

                employerStart();
            }
            else if (kimlikSecer == 4)
            {

                int tapIndex = 1;

                string name = "";
                string surname = "";
                string seher = "";
                string nomre = "";
                int age = 0;
                string ixtisas = "";
                string mekdeb = "";
                int inustutBali = -1;
                List<string> Bacariqlar = new List<string>();
                string mekan = "";
                List<string> Lenguvics = new List<string>();
                bool diplom = false;

                string[] _4 = new string[14] { "Name", "Surname", "Seher", "Nomre", "Age", "Ixtisas", "Mekdeb", "Inustut Bali", "Bacariqlar", "Yasadiqi Yer", "Bildiyi Diller", "Diplom", "Cix", "Creat" };

                void yazName() { Console.Write("Name: "); name = Console.ReadLine(); if (_4[0][_4[0].Length - 1] != '+') { _4[0] += " +"; } }
                void yazSurname() { Console.Write("Surname: "); surname = Console.ReadLine(); if (_4[1][_4[1].Length - 1] != '+') { _4[1] += " +"; } }
                void yazSeher() { Console.Write("Seher: "); seher = Console.ReadLine(); if (_4[2][_4[2].Length - 1] != '+') { _4[2] += " +"; } }
                void yazNomre()
                {
                    while (true)
                    {

                        Console.Write("misal (000-000-00-00) nomre: "); nomre = Console.ReadLine();
                        try
                        {
                            if (nomre.Length == 13)
                            {
                                for (int i = 0; i < 13; i++)
                                {

                                    if (i == 0 || i == 1 || i == 2 || i == 4 || i == 5 || i == 6 || i == 8 || i == 9 || i == 11 || i == 12)
                                    {
                                        if ((int)nomre[i] > 47 && (int)nomre[i] < 58) { }
                                        else { throw new YanlisNomreException(); }
                                    }

                                    else if (i == 3 || i == 7 || i == 10)
                                    {
                                        if ((int)nomre[i] == '-') ;
                                        else { throw new YanlisNomreException(); };
                                    }

                                }

                                for (int i = 0; i < workers.Count; i++)
                                {
                                    if (workers[i].Phone == nomre) { throw new YanlisNomreException(); }
                                }

                            }
                            else { throw new YanlisNomreException(); }
                        }
                        catch (YanlisNomreException yne) { Console.WriteLine(yne.Message); Thread.Sleep(1500); return; }
                        if (_4[3][_4[3].Length - 1] != '+') { _4[3] += " +"; }
                        return;
                    }
                }
                void yazAge()
                {
                    while (true)
                    {
                        Console.Write("Age: ");
                        try { age = int.Parse(Console.ReadLine()); if (!(age > 0 && age < 100)) { Console.WriteLine("\tage 0 ve 100 arasinda ola biler"); continue; } if (_4[4][_4[4].Length - 1] != '+') { _4[4] += " +"; } break; } catch (Exception e) { Console.WriteLine(e.Message); Thread.Sleep(1500); return; }
                    }
                }
                void yazIxtisas() { Console.Write("Ixtisas: "); ixtisas = Console.ReadLine(); if (_4[5][_4[5].Length - 1] != '+') { _4[5] += " +"; } }
                void yazMekdeb() { Console.Write("Oxduqu Mekdeb: "); mekdeb = Console.ReadLine(); if (_4[6][_4[6].Length - 1] != '+') { _4[6] += " +"; } }
                void yazInistutBali()
                {
                    while (true)
                    {
                        Console.Write("inustut bali: ");
                        try
                        {
                            inustutBali = int.Parse(Console.ReadLine());

                            if (!(inustutBali <= 700 && inustutBali >= 0)) { Console.WriteLine("inustut bali 0 ile 700 bal arasinda olmalidi"); Thread.Sleep(1500); return; }
                            if (_4[7][_4[7].Length - 1] != '+') { _4[7] += " +"; }
                            break;

                        }
                        catch (Exception e) { Console.WriteLine(e.Message); Thread.Sleep(1500); return; }
                    }
                }
                void yazBacariqlar()
                {
                    int bacariqSayi = 0;

                    while (true)
                    {
                        Console.Write("bacariq sayini qeyd edin: ");
                        try { bacariqSayi = int.Parse(Console.ReadLine()); break; } catch (Exception e) { Console.WriteLine(e.Message); Thread.Sleep(1500); return; }

                    }
                    Bacariqlar.Clear();


                    for (int i = 0; i < bacariqSayi; i++)
                    {
                        Console.Write("Bacariq qeyd edin: "); Bacariqlar.Add(Console.ReadLine());
                    }
                    if (_4[8][_4[8].Length - 1] != '+') { _4[8] += " +"; }
                }
                void yazMekan() { Console.Write("Yasadiqi yer: "); mekan = Console.ReadLine(); if (_4[9][_4[9].Length - 1] != '+') { _4[9] += " +"; } }
                void yazLengivic()
                {
                    int lenguvicSayi = 0;

                    while (true)
                    {
                        Console.Write("Nece dil bilirsiz: ");
                        try { lenguvicSayi = int.Parse(Console.ReadLine()); break; } catch (Exception e) { Console.WriteLine(e.Message); Thread.Sleep(1500); return; }
                    }

                    Lenguvics.Clear();

                    for (int i = 0; i < lenguvicSayi; i++)
                    {
                        Console.Write("Bildiynir dili qeyd edin: "); Lenguvics.Add(Console.ReadLine());
                    }
                    if (_4[10][_4[10].Length - 1] != '+') { _4[10] += " +"; }
                }
                void yazDiplom()
                {

                    while (true)
                    {

                        Console.WriteLine("(1) yes");
                        Console.WriteLine("(2) no");
                        Console.Write("\nsecim edin: ");

                        string sec1 = Console.ReadLine();
                        if (sec1 == "1") { diplom = true; if (_4[11][_4[11].Length - 1] != '+') { _4[11] += " +"; } break; }
                        else if (sec1 == "2") { diplom = false; if (_4[11][_4[11].Length - 1] != '+') { _4[11] += " +"; } break; }
                        try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { Console.WriteLine(bbsye.Message); Thread.Sleep(1500); return; }
                    }
                }


                void creatEle()
                {
                    workers.Add(new Worker(Guid.NewGuid(), name, surname, seher, nomre, age, new CV(ixtisas, mekdeb, inustutBali, Bacariqlar, mekan, Lenguvics, diplom)));
                }



                void workwrStart()
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\n                     Creat Worker");
                        Console.WriteLine("\t-----------------------------------------\n\t|                                       |");

                        for (int i = 0; i < _4.Length; i++)
                        {
                            if (i == 12)
                            {
                                Console.Write("\t|                                       |\n");
                            }
                            int bosluq = 34 - _4[i].Length;

                            if (i + 1 == tapIndex)
                            {
                                Console.Write($"\t|     {{{_4[i]}}} <- clik enter"); bosluq -= 16; for (int b = 0; b < bosluq; b++) { Console.Write(" "); }
                                Console.WriteLine("|");
                            }
                            else { Console.Write($"\t|     {_4[i]}"); for (int b = 0; b < bosluq; b++) { Console.Write(" "); } Console.WriteLine("|"); }


                        }


                        Console.WriteLine("\t|                                       |\n\t-----------------------------------------\n");


                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            if (tapIndex > 1) { tapIndex--; }
                            else if (tapIndex == 1) { tapIndex = _4.Length; }
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            if (tapIndex < _4.Length) { tapIndex++; }
                            else if (tapIndex == _4.Length) { tapIndex = 1; }
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter) { break; }

                    }

                    if (tapIndex == 1) { yazName(); }
                    else if (tapIndex == 2) { yazSurname(); }
                    else if (tapIndex == 3) { yazSeher(); }
                    else if (tapIndex == 4) { yazNomre(); }
                    else if (tapIndex == 5) { yazAge(); }
                    else if (tapIndex == 6) { yazIxtisas(); }
                    else if (tapIndex == 7) { yazMekdeb(); }
                    else if (tapIndex == 8) { yazInistutBali(); }
                    else if (tapIndex == 9) { yazBacariqlar(); }
                    else if (tapIndex == 10) { yazMekan(); }
                    else if (tapIndex == 11) { yazLengivic(); }
                    else if (tapIndex == 12) { yazDiplom(); }
                    else if (tapIndex == 13) { return; }
                    else if (tapIndex == 14)
                    {

                        if (name != "" && surname != "" && seher != "" && nomre != "" && age != 0 && ixtisas != "" && mekdeb != "" && inustutBali != -1 && Bacariqlar.Count != 0 && mekan != "" && Lenguvics.Count != 0)
                        {
                            creatEle(); return;
                        }
                        else { try { throw new QeydiyatException(); } catch (QeydiyatException qe) { Console.WriteLine(qe.Message); Thread.Sleep(1500); } }

                    }

                    workwrStart();
                }

                workwrStart();


            }
            else if (kimlikSecer == 5) { save(); }
            else { try { throw new BeleBirSecimYoxduException(); } catch (BeleBirSecimYoxduException bbsye) { kimlikSecer = 0; Console.WriteLine(bbsye.Message); } }

        }

        static void start()
        {

            if (basla) { basla = false; doldur(); }
            secim();



            start();
        }


        static void Main(string[] args)
        {

            start();
        }
    }

}
